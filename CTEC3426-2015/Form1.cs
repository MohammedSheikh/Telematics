using System;
using System.Threading;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace CTEC3426_2015
{
    public partial class CTEC3426 : Form
    {
        delegate void SetTextCallback(string text);

        private Thread readThread = null;
        bool reading = false;

        SerialPort serialPort = new SerialPort();

        /* Default settings */
        string _PortName = "COM1";
        int _BaudRate = 115200;
        int _DataBits = 8;
        StopBits _StopBits = StopBits.One;
        Parity _Parity = Parity.None;

        string hash = "#";
        string outgoingID;
        //array holding the CAN message data
        int[] array = new int[7];
        string bytes = "00000000000000";
        //var to store current temp
        string currentTemp;
        int switchState;
        string switchByteOne;
        int tempByteOne;
        int tempByteTwo;
        decimal tempThreshold;
        bool tempSet = false;
        bool tempButton = false;

        public CTEC3426()
        {
            InitializeComponent();

            initMenu();
        }

        private void GUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            reading = false;
            this.readThread.Abort();
            serialPort.Close();
        }

        //method that sends remote commands by incorporating the serial port and hex data
        public void RemoteCommand()
        {
            int total = array.Sum();
            string hex = total.ToString("x2");
            sendCommand(serialPort, hash + outgoingID + hex + bytes);
        }

        private void CTEC3426_Load(object sender, EventArgs e)
        {
            //disable buttons upon form load
            btnMotorFwdRev.Enabled = false;
            lblMDirection.Text = "";
            btnOutgoing.Enabled = false;
            btnIncoming.Enabled = false;
            btnSetFilter.Enabled = false;
            btnSetMask.Enabled = false;
            btnBroadcast.Enabled = false;
            btnSetTemp.Enabled = false;
            btnControlTemp.Enabled = false;
        }

        /* Initialise the toolbar menu */
        public void initMenu()
        {
            foreach (string s in SerialPort.GetPortNames())
            {
                this.portNameComboBox.Items.Add(s);
            }
            foreach (string s in Enum.GetNames(typeof(Parity)))
            {
                this.parityComboBox.Items.Add(s);
            }
            foreach (string s in Enum.GetNames(typeof(StopBits)))
            {
                this.stopBitsComboBox.Items.Add(s);
            }
            this.portNameComboBox.Text = _PortName;
            this.baudRateTextBox.Text = _BaudRate.ToString();
            this.dataBitsTextBox.Text = _DataBits.ToString();
            this.stopBitsComboBox.Text = _StopBits.ToString();
            this.parityComboBox.Text = _Parity.ToString();
        }

        /* Methods related to each entry in the toolbar menu */
        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                setSerialPort();
                serialPort.Open();
            }
            catch (IOException open_exception)
            {
                Console.WriteLine("an error occured when opening the serial port");
            }
            this.readThread = new Thread(new ThreadStart(this.readThreadProcSafe));
            this.readThread.Start();
            reading = true;
            lblSMSMessage.Text = "";
            sendCommand(serialPort, "@");
        }

        // Writes a command with some optional data to the serial port
        public void sendCommand(SerialPort sp, String command, String payload = null)
        {
            sp.Write(command);
            if (payload != null)
            {
                sp.Write(payload);
            }
        }

        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void portNameComboBox_TextChanged(object sender, EventArgs e)
        {
            _PortName = portNameComboBox.Text;
        }

        private void baudRateTextBox_TextChanged(object sender, EventArgs e)
        {
            _BaudRate = Convert.ToInt32(baudRateTextBox.Text);
        }

        private void dataBitsTextBox_TextChanged(object sender, EventArgs e)
        {
            _DataBits = Convert.ToInt32(dataBitsTextBox.Text);
        }

        private void stopBitsToolStripMenuItem_TextChanged(object sender, EventArgs e)
        {
            _StopBits = (StopBits)Enum.Parse(typeof(StopBits), stopBitsComboBox.Text, true);
        }

        private void parityToolStripMenuItem_TextChanged(object sender, EventArgs e)
        {
            _Parity = (Parity)Enum.Parse(typeof(Parity), parityComboBox.Text, true);
        }

        /* Set values for the serial port */
        private void setSerialPort()
        {
            serialPort.PortName = _PortName;
            serialPort.BaudRate = _BaudRate;
            serialPort.DataBits = _DataBits;
            serialPort.StopBits = _StopBits;
            serialPort.Parity = _Parity;
        }

        /* Thread reading the serial port */
        private void readThreadProcSafe()
        {
            Byte[] data = new Byte[256];
            String line = "";

            while (reading)
            {
                try
                {
                    serialPort.Read(data, 0, data.Length);
                }
                catch (IOException read_exception)
                { }

                for (int i = 0; i < data.Length; i++)
                {
                    switch (data[i])
                    {
                        case (0):
                            break;
                        case (13): // carriage return
                            line += Convert.ToChar(data[i]);
                            if ((line.Contains("#")) && (!line.Contains("send")))
                                this.getCANbusData(line);
                            line = "";
                            break;
                        default:
                            line += Convert.ToChar(data[i]);
                            this.SetTerminal(Convert.ToString(Convert.ToChar(data[i])));
                            break;
                    }
                }
                Array.Clear(data, 0, data.Length);
            }
        }

        /* Add the line read on the serial port to the terminal window
        in a thread safe way */
        private void SetTerminal(string text)
        {
            if (this.terminal.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetTerminal);
                this.Invoke(d, new object[] { text });

            }
            else
            {
                terminal.AppendText(text);
            }
        }

        private void btnHeater_Click(object sender, EventArgs e)
        {
            ToggleHeater();
        }

        void ToggleHeater()
        {
            try
            {
                if (lblHStatus.Text == "Off")
                {
                    array[6] = 0x01;
                    RemoteCommand();
                    lblHStatus.Text = "On";
                }
                else
                {
                    array[6] = 0x00;
                    RemoteCommand();
                    lblHStatus.Text = "Off";
                }
            }
            catch (Exception ex)
            {
                lblSMSMessage.Text = "Please connect to the serial port";
            }
        }

        /* Sends the characters written in the terminal emulator to the serial port */
        private void terminal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (serialPort.IsOpen)
            {
                serialPort.Write(Convert.ToString(e.KeyChar));
                e.Handled = true;
            }
        }

        /* Make the data retrieve from the CANbus available to the form */
        private void getCANbusData(string text)
        {
            if (this.InvokeRequired)
            {
                SetTextCallback c = new SetTextCallback(getCANbusData);
                this.Invoke(c, new object[] { text });
            }
            else
            {
                string delimStr = "#";
                char[] delimiter = delimStr.ToCharArray();
                string[] raw = text.Split(delimiter);
                String identifier = raw[1].Remove(8);

                String dataStr = raw[1].Remove(0, 10);
                delimStr = " ";
                delimiter = delimStr.ToCharArray();
                String[] data = dataStr.Split(delimiter);

                /* The identifier and the data are now available to
                use safely in the form trhough the variables data and
                identifier. Just create a new method, and call it with
                identifier and data as parameters. */

                /* The data is stored in an array of string. Each string
                in the array represent a byte of data, with data[0] being
                the most significant byte and data[7] the least
                significant byte. Be careful though, you cannot use the
                data directly as it is encoded as a string. You should 
                first convert the string representation of the data into
                a variable of the relevant type (byte, integer, char, etc).
                For instance, the first byte contains information about
                the Motor, heater and the switches. If data[0] contains "11",
                you should convert this string into a byte which contains the
                value 0x11, or an integer which contains the value 17 to be able
                to manipulate it efficiently.
                I suggest you to have a look at the class Convert on MSDN.
                And Google is still you friend ;-) */

                /* /!\ This function will crash if you manage to retrieve a line
                starting with the character # and which doesn't contain the 
                appropriate number character. This case may occur if you use the
                terminal emulator to communicate directly to the GSM modem.
                Fixing this function is not my priority, so it will stay like
                that, but feel free to fix it yourself. */

                //I am maksing use of the 'data' var in the below method calls


                //call temp control method
                TempControl(data);

                //call keypad method
                int Key_Press = Convert.ToInt32(data[1]);
                Keypad(Key_Press);

                //call switch status method
                GetSwitchStatus(data);

                //call remote temp method
                GetRemoteTemp(data);

                
            }
        }

        void GetRemoteTemp(String[] data)
        {
            /*temp*/
            for (int i = 0; i < data.Length; i++)
            {
                String byteThree = Convert.ToString(data[2]);
                String byteFour = Convert.ToString(data[3]);
                //array 2 - byte 3 contains information about the temperature.

                //here converting the array of hex into int
                tempByteOne = int.Parse(byteThree, System.Globalization.NumberStyles.HexNumber);
                tempByteTwo = int.Parse(byteFour, System.Globalization.NumberStyles.HexNumber);
                currentTemp = Convert.ToString(tempByteOne + "." + tempByteTwo);
                lblTemp.Text = currentTemp;
            }
        }

        void GetSwitchStatus(String[] data)
        {
            /*swicthes*/
            for (int i = 0; i < data.Length; i++)
            {
                //byte zero contains switch info
                String byteZero = Convert.ToString(data[0]);

                //Converitng the hex into decimal which displays in the label
                switchState = int.Parse(byteZero, System.Globalization.NumberStyles.HexNumber);
                switchByteOne = Convert.ToString(switchState);
                //lblSMSMessage.Text = switchByteOne;

                //no switches
                if (switchByteOne == "0")
                {
                    array[0] = 0x00;

                    lblSwitch1OnOff.Text = "Off";
                    lblSwitch2OnOff.Text = "Off";
                    lblSwitch3OnOff.Text = "Off";
                    lblSwitch4OnOff.Text = "Off";
                }
                //switch one ON
                else if (switchByteOne == "1")
                {
                    array[0] = 0x01;
                    lblSwitch1OnOff.Text = "On";
                }
                //switch two ON
                else if (switchByteOne == "2")
                {
                    array[0] = 0x02;
                    lblSwitch2OnOff.Text = "On";
                }
                //switch three ON
                else if (switchByteOne == "4")
                {
                    array[0] = 0x04;
                    lblSwitch3OnOff.Text = "On";
                }
                //switch four ON
                else if (switchByteOne == "8")
                {
                    array[0] = 0x08;
                    lblSwitch4OnOff.Text = "On";
                }
            }
        }

        //method to control temp
        void TempControl(String[] data)
        {
            //temp control code that applies different behaviours depedning on temp

            for (int i = 1; i < data.Length; i++)
            {
                if (tempSet == true)
                {
                    //If current temp is lower than threshold, turn on heater

                    if (tempThreshold > tempByteOne && !string.IsNullOrEmpty(txtSetTemp.Text))
                    {
                        //heater ON status method
                        HeaterOn();
                        lblSMSMessage.Text = "Temp is below threshold (Heater is ON)";
                        RemoteCommand();
                    }

                    //If current temp is gretaer than threshold, motor turns on
                    else if (tempThreshold < tempByteOne)
                    {
                        //motor ON status method
                        MotorOn();
                        lblSMSMessage.Text = "Temp is above threshold (Motor is ON)";
                        RemoteCommand();
                    }
                    //if same temp
                    else if (tempThreshold == tempByteOne && !string.IsNullOrEmpty(txtSetTemp.Text))
                    {
                        NoMotorNoHeater();
                        lblSMSMessage.Text = "Temp is at threshold";
                        RemoteCommand();
                    }
                }
                else
                {
                    //NoMotorNoHeater();
                }
            }
        }

        void NoMotorNoHeater()
        {
            array[5] = 0x00;
            array[6] = 0x00;
            RemoteCommand();
        }

        //method switching on the heater
        void HeaterOn()
        {
            array[6] = 0x01;
            array[5] = 0x00;
            RemoteCommand();
            lblHStatus.Text = "On";
            lblMDirection.Text = "Off";
        }

        //method switching on the motor
        void MotorOn()
        {
            array[5] = 0x02;
            array[6] = 0x00;
           RemoteCommand();
            lblMStatus.Text = "On";
            lblHStatus.Text = "Off";
            lblMDirection.Text = "Forward";
        }

        //method that shows keypad status
        void Keypad(int PressedKey)
        {
            switch (PressedKey)
            {
                //keypad 0
                case 30:
                    lblKey.Text = "0";

                    break;
                //keypad 1
                case 31:
                    lblKey.Text = "1";

                    break;
                //keypad 2
                case 32:
                    lblKey.Text = "2";

                    break;
                //keypad 3
                case 33:
                    lblKey.Text = "3";

                    break;
                //keypad 4
                case 34:
                    lblKey.Text = "4";

                    break;
                //keypad 5
                case 35:
                    lblKey.Text = "5";

                    break;
                //keypad 6
                case 36:
                    lblKey.Text = "6";

                    break;
                //keypad 7
                case 37:
                    lblKey.Text = "7";

                    break;
                //keypad 8
                case 38:

                    lblKey.Text = "8";

                    break;
                //keypad 9
                case 39:
                    lblKey.Text = "9";

                    break;
                //keypad *
                case 53:
                    lblKey.Text = "*";

                    break;
                //keypad #
                case 48:
                    lblKey.Text = "#";

                    break;
                //default case
                default:
                    lblKey.Text = "No key pressed";
                    break;
            }
        }

        private void btnMotorOnOff_Click(object sender, EventArgs e)
        {
            ToggleMotor();
        }

        //toggle motor method
        void ToggleMotor()
        {
            try
            {
                if (lblMStatus.Text == "Off")
                {
                    array[5] = 0x02;
                    RemoteCommand();
                    lblMStatus.Text = "On";
                    btnMotorFwdRev.Enabled = true;
                    btnMotorFwdRev.Text = "Motor Reverse";
                    lblMDirection.Text = "Forward";
                }
                else
                {
                    array[5] = 0x00;
                    RemoteCommand();
                    lblMStatus.Text = "Off";
                    btnMotorFwdRev.Enabled = false;
                    btnMotorFwdRev.Text = "Motor (Fwd/Rev)";
                    lblMDirection.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblSMSMessage.Text = "Please connect to the serial port";
            }
        }

        private void btnLED1OnOff_Click(object sender, EventArgs e)
        {
            ToggleLED1();
        }

        private void btnLED2OnOff_Click(object sender, EventArgs e)
        {
            ToggleLED2();
        }

        private void btnLED3OnOff_Click(object sender, EventArgs e)
        {
            ToggleLED3();
        }

        private void btnLED4OnOff_Click(object sender, EventArgs e)
        {
            ToggleLED4();
        }

        void ToggleLED1()
        {
            try
            {                
                if (lblLED1OnOff.Text == "Off")
                {
                    array[0] = 0x10;
                    RemoteCommand();
                    lblLED1OnOff.Text = "On";
                }
                else
                {
                    array[0] = 0x00;
                    RemoteCommand();
                    lblLED1OnOff.Text = "Off";
                }
            }
            catch (Exception ex)
            {
                lblSMSMessage.Text = "Please connect to the serial port";
            }
        }

        void ToggleLED2()
        {
            try
            {
                if (lblLED2OnOff.Text == "Off")
                {
                    array[1] = 0x20;
                    RemoteCommand();
                    lblLED2OnOff.Text = "On";
                }
                else
                {
                    array[1] = 0x00;
                    RemoteCommand();
                    lblLED2OnOff.Text = "Off";
                }
            }
            catch (Exception ex)
            {
                lblSMSMessage.Text = "Please connect to the serial port";
            }
        }

        void ToggleLED3()
        {
            try
            {

                if (lblLED3OnOff.Text == "Off")
                {
                    array[2] = 0x40;
                    RemoteCommand();
                    lblLED3OnOff.Text = "On";
                }
                else
                {
                    array[2] = 0x00;
                    RemoteCommand();
                    lblLED3OnOff.Text = "Off";
                }
            }
            catch (Exception ex)
            {
                lblSMSMessage.Text = "Please connect to the serial port";
            }
        }

        void ToggleLED4()
        {
            try
            {
                if (lblLED4OnOff.Text == "Off")
                {
                    array[3] = 0x80;
                    RemoteCommand();
                    lblLED4OnOff.Text = "On";
                }
                else
                {
                    array[3] = 0x00;
                    RemoteCommand();
                    lblLED4OnOff.Text = "Off";
                }
            }
            catch (Exception ex)
            {
                lblSMSMessage.Text = "Please connect to the serial port";
            }
        }

        //Reset all fields/labels
        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                ClearFields();
                ClearLabels();
                ClearStatuses();
                if (lblOutgoingStatus.Text == "")
                {
                    sendCommand(serialPort, "@");
                }
                else
                {
                    sendCommand(serialPort, hash + lblOutgoingStatus.Text + "0000000000000000");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        //clear set statuses
        void ClearStatuses()
        {
            lblMaskStatus.Text = "";
            lblFilterStatus.Text = "";
            lblOutgoingStatus.Text = "";
            lblIncomingStatus.Text = "";
            lblBroadcastStatus.Text = "";
        }

        //clear text fields + reset buttons
        void ClearFields()
        {
            txtFilter.Text = "";
            txtMask.Text = "";
            txtBroadcastID.Text = "";
            txtOutgoing.Text = "";
            txtIncoming.Text = "";
            txtSMS.Text = "";
            btnMotorFwdRev.Text = "Motor (Fwd/Rev)";
            txtSMS.Text = "";
            btnOutgoing.Enabled = false;
            btnIncoming.Enabled = false;
            btnSetFilter.Enabled = false;
            btnSetMask.Enabled = false;
            btnBroadcast.Enabled = false;
            btnControlTemp.Enabled = false;
            lblSMSMessage.Text = "";
            txtSetTemp.Text = "";
            lblThreshold.Text = "";
        }

        //clear label statuses
        void ClearLabels()
        {
            lblTemp.Text = "0";
            lblHStatus.Text = "Off";
            lblMStatus.Text = "Off";
            lblMDirection.Text = "Off";
            lblSwitch1OnOff.Text = "Off";
            lblSwitch2OnOff.Text = "Off";
            lblSwitch3OnOff.Text = "Off";
            lblSwitch4OnOff.Text = "Off";
            lblLED1OnOff.Text = "Off";
            lblLED2OnOff.Text = "Off";
            lblLED3OnOff.Text = "Off";
            lblLED4OnOff.Text = "Off";
            lblMDirection.Text = "";
            lblSMSMessage.Text = "";
        }

        private void btnMotorFwdRev_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnMotorFwdRev.Text == "Motor Forward")
                {
                    array[5] = 0x02;
                    RemoteCommand();
                    btnMotorFwdRev.Text = "Motor Reverse";
                    lblMDirection.Text = "Forward";
                }
                else if (btnMotorFwdRev.Text == "Motor Reverse")
                {
                    array[5] = 0x06;
                    RemoteCommand();
                    btnMotorFwdRev.Text = "Motor Forward";
                    lblMDirection.Text = "Reverse";
                }
            }
            catch (Exception ex)
            {
                lblSMSMessage.Text = "Please connect to the serial port";
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                SendMessage();
            }
            catch (Exception ex)
            {
                lblSMSMessage.ForeColor = Color.Black;
                lblSMSMessage.Text = "Please connect to the serial port";
            }
        }

        //method that sends SMS message
        void SendMessage()
        {
            string number = txtSMS.Text;

            if (number.Length != 11)
            {
                lblSMSMessage.ForeColor = Color.Red;
                lblSMSMessage.Text = "Mobile Number needs to be 11 Chars";
            }
            else
            {
                lblSMSMessage.ForeColor = Color.Green;
                lblSMSMessage.Text = "SMS has been sent";
            }

            string heater = "";

            if (lblHStatus.Text == "Off")
            {
                heater = "Off";
            }
            else if (lblHStatus.Text == "On")
            {
                heater = "On";
            }

            string motor = "";

            if (lblMStatus.Text == "Off")
            {
                motor = "Off";
            }
            else if (lblMStatus.Text == "On")
            {
                motor = "On";
            }

            string motorDirection = "";

            if (lblMDirection.Text == "Forward")
            {
                motorDirection = "Fwd";
            }
            else if (lblMDirection.Text == "Reverse")
            {
                motorDirection = "Rev";
            }

            string ledOne = "";

            if (lblLED1OnOff.Text == "Off")
            {
                ledOne = "Off";
            }
            else if (lblLED1OnOff.Text == "On")
            {
                ledOne = "On";
            }

            string ledTwo = "";

            if (lblLED2OnOff.Text == "Off")
            {
                ledTwo = "Off";
            }
            else if (lblLED2OnOff.Text == "On")
            {
                ledTwo = "On";
            }

            string ledThree = "";

            if (lblLED3OnOff.Text == "Off")
            {
                ledThree = "Off";
            }
            else if (lblLED3OnOff.Text == "On")
            {
                ledThree = "On";
            }

            string ledFour = "";

            if (lblLED4OnOff.Text == "Off")
            {
                ledFour = "Off";
            }
            else if (lblLED4OnOff.Text == "On")
            {
                ledFour = "On";
            }

            string switchOne = "";

            if (lblSwitch1OnOff.Text == "Off")
            {
                switchOne = "Off";
            }
            else if (lblSwitch1OnOff.Text == "On")
            {
                switchOne = "On";
            }

            string switchTwo = "";

            if (lblSwitch2OnOff.Text == "Off")
            {
                switchTwo = "Off";
            }
            else if (lblSwitch2OnOff.Text == "On")
            {
                switchTwo = "On";
            }

            string switchThree = "";

            if (lblSwitch3OnOff.Text == "Off")
            {
                switchThree = "Off";
            }
            else if (lblSwitch3OnOff.Text == "On")
            {
                switchThree = "On";
            }

            string switchFour = "";

            if (lblSwitch4OnOff.Text == "Off")
            {
                switchFour = "Off";
            }
            else if (lblSwitch4OnOff.Text == "On")
            {
                switchFour = "On";
            }

            //concatenate the message with all the label contents
            string message =

                //current temp
                "T=" + lblTemp.Text + Environment.NewLine +
                //heater status
                "H=" + heater + Environment.NewLine +
                //LED's status
                "LEDs=" + ledOne + ", " + ledTwo + ", " + ledThree + ", " + ledFour + ", " + Environment.NewLine +
                //motor status
                "M=" + motor + ", " + "MD=" + motorDirection + Environment.NewLine +
                //switch status
                "S=" + switchOne + ", " + switchTwo + ", " + switchThree + ", " + switchFour;

            //send the message
            sendCommand(serialPort, "O");
            //send SMS command in text mode + do carriage return
            sendCommand(serialPort, "AT+CMGS=" + number + "\r");
            sendCommand(serialPort, "" + message + char.ConvertFromUtf32(26));
            sendCommand(serialPort, "" + char.ConvertFromUtf32(27));
            //reset the SMS text box
            txtSMS.Text = "";
        }

        //set CAN filter
        private void btnSetFilter_Click(object sender, EventArgs e)
        {
            SetCANFilter();
        }

        private void btnSetMask_Click(object sender, EventArgs e)
        {
            SetCANMask();
        }

        private void btnBroadcast_Click(object sender, EventArgs e)
        {
            SetBroadcastID();
        }

        private void btnOutgoing_Click(object sender, EventArgs e)
        {
            SetOutgoingID();
        }

        private void btnIncoming_Click(object sender, EventArgs e)
        {
            SetIncomingID();
        }

        void SetCANFilter()
        {
            try
            {
                if (txtFilter.Text.Length == 8)
                {
                    string canFilter = txtFilter.Text;
                    sendCommand(serialPort, "A" + canFilter);
                    lblFilterStatus.Text = txtFilter.Text.ToUpper();
                    btnSetFilter.Enabled = false;
                    txtFilter.Text = "";
                    ClearLabels();
                }
                else
                {
                    lblSMSMessage.Text = "Filter must be 8 chars";
                }
            }
            catch (Exception ex)
            {
                lblSMSMessage.Text = "Please connect to the serial port";
            }
        }

        void SetCANMask()
        {
            try
            {
                if(txtMask.Text.Length == 8)
                {
                    string canMask = txtMask.Text;
                    sendCommand(serialPort, "M" + canMask);
                    lblMaskStatus.Text = txtMask.Text.ToUpper();
                    btnSetMask.Enabled = false;
                    txtMask.Text = "";
                    ClearLabels();
                }
                else
                {
                    lblSMSMessage.Text = "Mask must be 8 chars";
                }
                
            }
            catch (Exception ex)
            {
                lblSMSMessage.Text = "Please connect to the serial port";
            }
        }

        void SetBroadcastID()
        {
            try
            {
                if(txtBroadcastID.Text.Length == 8)
                {
                    string broadcastID = txtBroadcastID.Text;
                    sendCommand(serialPort, "B" + broadcastID);
                    lblBroadcastStatus.Text = txtBroadcastID.Text.ToUpper();
                    btnBroadcast.Enabled = false;
                    txtBroadcastID.Text = "";
                    ClearLabels();
                }
                else
                {
                    lblSMSMessage.Text = "Broadcast ID must be 8 chars";
                }
                
            }

            catch (Exception ex)
            {
                lblSMSMessage.Text = "Please connect to the serial port";
            }
        }

        void SetOutgoingID()
        {
            try
            {
                if (txtOutgoing.Text.Length == 8)
                {
                    lblOutgoingStatus.Text = txtOutgoing.Text.ToUpper();
                    outgoingID = lblOutgoingStatus.Text;
                    btnOutgoing.Enabled = false;
                    txtOutgoing.Text = "";
                    ClearLabels();
                }
                else
                {
                    lblSMSMessage.Text = "Outgoing ID must be 8 chars";
                }
            }
            catch (Exception ex)
            {
                lblSMSMessage.Text = "Please connect to the serial port";
            }
        }

        void SetIncomingID()
        {
            try
            {
                if(txtIncoming.Text.Length == 8)
                {
                    string inputID = txtIncoming.Text;
                    sendCommand(serialPort, "E" , inputID);
                    lblIncomingStatus.Text = txtIncoming.Text.ToUpper();
                    btnIncoming.Enabled = false;
                    txtIncoming.Text = "";
                    ClearLabels();
                }
                else
                {
                    lblSMSMessage.Text = "Incoming ID must be 8 chars";
                }
            }

            catch (Exception ex)
            {
                lblSMSMessage.Text = "Please connect to the serial port";
            }
        }
        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            btnSetFilter.Enabled = true;
        }

        private void txtMask_TextChanged(object sender, EventArgs e)
        {
            btnSetMask.Enabled = true;
        }

        private void txtBroadcastID_TextChanged(object sender, EventArgs e)
        {
            btnBroadcast.Enabled = true;
        }

        private void txtOutgoing_TextChanged(object sender, EventArgs e)
        {
            btnOutgoing.Enabled = true;
        }

        private void txtIncoming_TextChanged(object sender, EventArgs e)
        {
            btnIncoming.Enabled = true;
        }

        private void btnSetTemp_Click(object sender, EventArgs e)
        {
            SetThreshold();
            btnControlTemp.Text = "Start Temp Control";
        }

        //set temperature threshold
        void SetThreshold()
        {
            bool validData = false;
            string setTemp = txtSetTemp.Text;
            try
            {
                tempThreshold = Convert.ToDecimal(setTemp);
                validData = true;
            }
            catch
            {
                lblSMSMessage.Text = "Threshold not in correct format";
            }

            if (validData == true)
            {
                lblThreshold.Text = "Current Temperature Threshold: " + setTemp;
                btnControlTemp.Enabled = true;
                lblSMSMessage.Text = "";
            }
        }

        private void txtSetTemp_TextChanged(object sender, EventArgs e)
        {
            btnSetTemp.Enabled = true;
        }

        private void btnControlTemp_Click(object sender, EventArgs e)
        {
                if (tempButton == true)
                {
                    btnControlTemp.Text = "Start / Stop Temp Control";
                    txtSetTemp.Text = "";
                    lblThreshold.Text = "";
                    btnSetTemp.Enabled = false;
                    tempButton = false;
                    tempSet = false;
                    lblSMSMessage.Text = "";
                    NoMotorNoHeater();
                    lblHStatus.Text = "Off";
                    lblMStatus.Text = "Off";
                    btnControlTemp.Enabled = false;

            }
                else if (tempButton == false)
                {
                    btnControlTemp.Text = "Stop Temp Control";
                    tempButton = true;
                    tempSet = true;
                }

        }
    }
}