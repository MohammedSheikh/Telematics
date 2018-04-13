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
        int[] array = new int[7];
        string Id;
        string bytes = "00000000000000";
        string conv;
        string test;
        int declare_value;
        int declare_value1;
        int templimit;
        bool temperatureprog = false;

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
            //array[0] = 0x00;
            //Remote_func();


        }

        public void Remote_func()
        {

            int cal = array.Sum();
            string hex = cal.ToString("x2");


            sendCommand(serialPort, "#" + lblBroadCastID.Text + hex + bytes);

        }

        private void CTEC3426_Load(object sender, EventArgs e)
        {
            btnMotorFwdRev.Enabled = false;
            lblMDirection.Text = "";
            btnOutgoing.Enabled = false;
            btnIncoming.Enabled = false;
            btnSetFilter.Enabled = false;
            btnSetMask.Enabled = false;
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
            try
            {
                if(lblBroadCastID.Text == "")
                {
                    if (lblHStatus.Text == "Off")
                    {
                        sendCommand(serialPort, "H");
                        lblHStatus.Text = "On";
                    }
                    else
                    {
                        sendCommand(serialPort, "C");
                        lblHStatus.Text = "Off";
                    }
                }
                else
                {
                    if (lblHStatus.Text == "Off")
                    {
                        array[6] = 0x01;
                        Remote_func();
                        //sendCommand(serialPort, hash + lblBroadCastID.Text + "0100000000000000");
                        lblHStatus.Text = "On";
                    }
                    else
                    {
                        array[6] = 0x00;
                        Remote_func();
                        //sendCommand(serialPort, hash + lblBroadCastID.Text + "0500000000000000");
                        lblHStatus.Text = "Off";
                    }
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

                /*kepyad*/
                int Key_Press = Convert.ToInt32(data[1]);

                switch (Key_Press)
                {

                    case 30:

                        txtFilter.Text = "0";
                        ChangeColor(Color.DarkRed);


                        break;

                    //case 31:

                    //    key_pressed_status.Text = "1";

                    //    break;

                    //case 32:

                    //    key_pressed_status.Text = "2";

                    //    break;

                    //case 33:

                    //    key_pressed_status.Text = "3";

                    //    break;

                    //case 34:

                    //    key_pressed_status.Text = "4";

                    //    break;

                    //case 35:

                    //    key_pressed_status.Text = "5";

                    //    break;

                    //case 36:

                    //    key_pressed_status.Text = "6";

                    //    break;

                    //case 37:

                    //    key_pressed_status.Text = "7";

                    //    break;

                    //case 38:

                    //    key_pressed_status.Text = "8";

                    //    break;


                    //case 39:

                    //    key_pressed_status.Text = "9";

                    //    break;


                    //case 53:

                    //    key_pressed_status.Text = "*";

                    //    break;


                    //case 48:

                    //    key_pressed_status.Text = "#";


                    //    break;

                    default:

                        lblSMSMessage.Text = "No key is being pressed";

                        break;

                }

                /*swicthes*/
                for (int i = 0; i < data.Length; i++)
                {
                    String b3 = Convert.ToString(data[0]);
                    //String b4 = Convert.ToString(data[3]);
                    //array 2 - byte 3 contains information about the temperature.

                    //Converitng the hex into decimal which displays in the label as 'tempstatus'
                    declare_value = int.Parse(b3, System.Globalization.NumberStyles.HexNumber);
                    //declare_value1 = int.Parse(b4, System.Globalization.NumberStyles.HexNumber);
                    test = Convert.ToString("0" + declare_value);
                    //lblTest.Text = test;
                    if (test == "00")
                    {
                        lblSwitch1OnOff.Text = "Off";
                        lblSwitch2OnOff.Text = "Off";
                        lblSwitch3OnOff.Text = "Off";
                        lblSwitch4OnOff.Text = "Off";
                    }
                    else if (test == "01")
                    {
                        lblSwitch1OnOff.Text = "On";
                        lblSwitch2OnOff.Text = "Off";
                        lblSwitch3OnOff.Text = "Off";
                        lblSwitch4OnOff.Text = "Off";

                        //lblTest.Text = "x";
                    }
                    else if (test == "02")
                    {
                        lblSwitch2OnOff.Text = "On";
                        lblSwitch1OnOff.Text = "Off";
                        lblSwitch3OnOff.Text = "Off";
                        lblSwitch4OnOff.Text = "Off";
                        //lblTest.Text = "x";
                    }
                    else if (test == "04")
                    {
                        lblSwitch3OnOff.Text = "On";
                        lblSwitch1OnOff.Text = "Off";
                        lblSwitch2OnOff.Text = "Off";
                        lblSwitch4OnOff.Text = "Off";
                        //lblTest.Text = "x";
                    }
                    else if (test == "08")
                    {
                        lblSwitch4OnOff.Text = "On";
                        lblSwitch1OnOff.Text = "Off";
                        lblSwitch2OnOff.Text = "Off";
                        lblSwitch3OnOff.Text = "Off";
                        //lblTest.Text = "x";
                    }
                    //statushm.Text = conv;
                }

                /*temp*/
                for (int i = 0; i < data.Length; i++)
                {
                    String b3 = Convert.ToString(data[2]);
                    String b4 = Convert.ToString(data[3]);
                    //array 2 - byte 3 contains information about the temperature.

                    //Converitng the hex into decimal which displays in the label as 'tempstatus'
                    declare_value = int.Parse(b3, System.Globalization.NumberStyles.HexNumber);
                    declare_value1 = int.Parse(b4, System.Globalization.NumberStyles.HexNumber);
                    conv = Convert.ToString(declare_value + "." + declare_value1);
                    lblTemp.Text = conv;
                    //statushm.Text = conv;
                }

                //automatic temperature control function with the array changing the messages according to the temperature level

                for (int i = 1; i < data.Length; i++)

                    if (temperatureprog == true)
                    {


                        //If it less than the declared value, the heater turns on

                        if (templimit > declare_value && !string.IsNullOrEmpty(txtSetTemp.Text))
                        {
                            array[6] = 0x01;
                            array[5] = 0x00;
                            lblSMSMessage.Text = "less than";
                            Remote_func();
                        }

                        //If it greater than the declared value, motor turns on

                        else if (templimit < declare_value)
                        {
                            array[5] = 0x02;
                            array[6] = 0x00;
                            lblSMSMessage.Text = "more than than";
                            Remote_func();
                        }

                        else if (templimit == declare_value && !string.IsNullOrEmpty(txtSetTemp.Text))
                        {
                            //array[5] = 0x00;
                            //array[6] = 0x00;
                            lblSMSMessage.Text = "nothing";
                            Remote_func();
                        }

                        //else if (lblsetTemp.Text == "")
                        //{

                        //}


                    }
            }
        }

        private async void ChangeColor(Color new_color)
        {
            var original_color = btn0.BackColor;

            btn0.BackColor = new_color;

            await Task.Delay(TimeSpan.FromSeconds(1));

            btn0.BackColor = original_color;
        }


        //toggle motor
        private void btnMotorOnOff_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblMStatus.Text == "Off")
                {
                    if(lblBroadCastID.Text == "")
                    {
                        sendCommand(serialPort, "F");
                    }
                    else
                    {
                        array[5] = 0x02;
                        Remote_func();
                        //sendCommand(serialPort, hash + lblBroadCastID.Text + "0200000000000000");
                    }

                    lblMStatus.Text = "On";
                    btnMotorFwdRev.Enabled = true;
                    btnMotorFwdRev.Text = "Motor Reverse";
                    lblMDirection.Text = "Forward";
                }
                else
                {
                    if (lblBroadCastID.Text == "")
                    {
                        sendCommand(serialPort, "S");
                    }
                    else
                    {
                        array[5] = 0x00;
                        Remote_func();
                        //sendCommand(serialPort, hash + lblBroadCastID.Text + "0000000000000000");
                    }
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
            try
            {
                if (lblBroadCastID.Text == "")
                {
                    if (lblLED1OnOff.Text == "Off")
                    {
                        sendCommand(serialPort, "0");
                        lblLED1OnOff.Text = "On";
                    }
                    else
                    {
                        sendCommand(serialPort, "0");
                        lblLED1OnOff.Text = "Off";
                    }
                }
                else
                {
                    if (lblLED1OnOff.Text == "Off")
                    {
                        array[0] = 0x10;
                        Remote_func();
                        lblLED1OnOff.Text = "On";
                    }
                    else
                    {
                        array[0] = 0x00;
                        Remote_func();
                        //sendCommand(serialPort, hash + lblBroadCastID.Text + "0000000000000000");
                        lblLED1OnOff.Text = "Off";
                    }
                    
                }
            }

            catch (Exception ex)
            {
                lblSMSMessage.Text = "Please connect to the serial port";
            }
          
        }

        private void btnLED2OnOff_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblBroadCastID.Text == "")
                {
                    if (lblLED2OnOff.Text == "Off")
                    {
                        sendCommand(serialPort, "1");
                        lblLED2OnOff.Text = "On";
                    }
                    else
                    {
                        sendCommand(serialPort, "1");
                        lblLED2OnOff.Text = "Off";
                    }
                }
                else
                {
                    if (lblLED2OnOff.Text == "Off")
                    {
                        array[1] = 0x20;
                        Remote_func();
                       // sendCommand(serialPort, hash + lblBroadCastID.Text + "2000000000000000");
                        lblLED2OnOff.Text = "On";
                    }
                    else
                    {
                        array[1] = 0x00;
                        Remote_func();
                        //sendCommand(serialPort, hash + lblBroadCastID.Text + "0000000000000000");
                        lblLED2OnOff.Text = "Off";
                    }
                    
                }
            }
            catch (Exception ex)
            {
                lblSMSMessage.Text = "Please connect to the serial port";
            }
        }

        private void btnLED3OnOff_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblBroadCastID.Text == "")
                {
                    if (lblLED3OnOff.Text == "Off")
                    {
                        sendCommand(serialPort, "2");
                        lblLED3OnOff.Text = "On";
                    }
                    else
                    {
                        sendCommand(serialPort, "2");
                        lblLED3OnOff.Text = "Off";
                    }
                }
                else
                {
                    if (lblLED3OnOff.Text == "Off")
                    {
                        array[2] = 0x40;
                        Remote_func();
                        //sendCommand(serialPort, hash + lblBroadCastID.Text + "4000000000000000");
                        lblLED3OnOff.Text = "On";
                    }
                    else
                    {
                        array[2] = 0x00;
                        Remote_func();
                        //sendCommand(serialPort, hash + lblBroadCastID.Text + "0000000000000000");
                        lblLED3OnOff.Text = "Off";
                    }
                    
                }
            }

            catch (Exception ex)
            {
                lblSMSMessage.Text = "Please connect to the serial port";
            }
        }

        private void btnLED4OnOff_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblBroadCastID.Text == "")
                {
                    if (lblLED4OnOff.Text == "Off")
                    {
                        sendCommand(serialPort, "3");
                        lblLED4OnOff.Text = "On";
                    }
                    else
                    {
                        sendCommand(serialPort, "3");
                        lblLED4OnOff.Text = "Off";
                    }
                }
                else
                {
                    if (lblLED4OnOff.Text == "Off")
                    {
                        array[3] = 0x80;
                        Remote_func();
                        //sendCommand(serialPort, hash + lblBroadCastID.Text + "8000000000000000");
                        lblLED4OnOff.Text = "On";
                    }
                    else
                    {
                        array[3] = 0x00;
                        Remote_func();
                        //sendCommand(serialPort, hash + lblBroadCastID.Text + "0000000000000000");
                        lblLED4OnOff.Text = "Off";
                    }
                    
                }
            }

            catch (Exception ex)
            {
                lblSMSMessage.Text = "Please connect to the serial port";
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                ClearFields();
                ClearLabels();
                ClearStatuses();
                if (lblBroadCastID.Text == "")
                {
                    sendCommand(serialPort, "@");
                }
                else
                {
                    sendCommand(serialPort, hash + lblBroadCastID.Text + "0000000000000000");
                }
            }
            catch (Exception ex)
            {
                lblSMSMessage.Text = "Please connect to the serial port";
            }
        }

        void ClearStatuses()
        {
            lblMaskStatus.Text = "";
            lblFilterStatus.Text = "";
            lblBroadCastID.Text = "";
            lblIncomingStatus.Text = "";
        }

        void ClearFields()
        {
            txtFilter.Text = "";
            txtMask.Text = "";
            txtOutgoing.Text = "";
            txtIncoming.Text = "";
            txtSMS.Text = "";
            btnMotorFwdRev.Text = "Motor(Fwd / Rev)";
            txtSMS.Text = "";
            btnOutgoing.Enabled = false;
            btnIncoming.Enabled = false;
            btnSetFilter.Enabled = false;
            btnSetMask.Enabled = false;
        }

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

        private void btnGetTemp_Click(object sender, EventArgs e)
        {
            try
            {
                formTimer.Start();
            }
            catch (Exception ex)
            {
                lblSMSMessage.Text = "Please connect to the serial port";
            }

        }

        //get new te mp every 2 secs
        private void formTimer_Tick(object sender, EventArgs e)
        {
            sendCommand(serialPort, "T");

            string tempT = serialPort.ReadLine();
            if (tempT.Length > 0)
            {
                try
                {
                    string tempX = tempT.Substring((tempT.Length - 5), 5);
                    lblTemp.Text = tempX;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }

        private void btnMotorFwdRev_Click(object sender, EventArgs e)
        {

            try
            {
                if (btnMotorFwdRev.Text == "Motor Forward")
                {
                    array[5] = 0x02;                    
                    Remote_func();
                    //sendCommand(serialPort, "F");
                    btnMotorFwdRev.Text = "Motor Reverse";
                    lblMDirection.Text = "Forward";
                }
                else if (btnMotorFwdRev.Text == "Motor Reverse")
                {
                    array[5] = 0x06;
                    Remote_func();
                    //sendCommand(serialPort, "R");
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
                lblSMSMessage.Text = "Please connect to the serial port";
            }
        }

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

            string message =

                "T=" + lblTemp.Text + Environment.NewLine +
                "H=" + heater + Environment.NewLine +
                "LEDs=" + ledOne + ", " + ledTwo + ", " + ledThree + ", " + ledFour + ", " + Environment.NewLine +
                "M=" + motor + ", " + "MD=" + motorDirection + Environment.NewLine +
                "S=" + switchOne + ", " + switchTwo + ", " + switchThree + ", " + switchFour;

            sendCommand(serialPort, "O");
            sendCommand(serialPort, "AT+CMGS=" + number + "\r");
            sendCommand(serialPort, "" + message + char.ConvertFromUtf32(26));
            sendCommand(serialPort, "" + char.ConvertFromUtf32(27));

            txtSMS.Text = "";
        }


        private void btnSwitch1OnOff_Click(object sender, EventArgs e)
        {
            if (lblSwitch1OnOff.Text == "Off")
            {

                lblSwitch1OnOff.Text = "On";
            }
            else
            {

                lblSwitch1OnOff.Text = "Off";
            }
        }

        private void btnSwitch2OnOff_Click(object sender, EventArgs e)
        {
            if (lblSwitch2OnOff.Text == "Off")
            {

                lblSwitch2OnOff.Text = "On";
            }
            else
            {

                lblSwitch2OnOff.Text = "Off";
            }
        }

        private void btnSwitch3OnOff_Click(object sender, EventArgs e)
        {
            if (lblSwitch3OnOff.Text == "Off")
            {

                lblSwitch3OnOff.Text = "On";
            }
            else
            {

                lblSwitch3OnOff.Text = "Off";
            }
        }

        private void btnSwitch4OnOff_Click(object sender, EventArgs e)
        {
            if (lblSwitch4OnOff.Text == "Off")
            {
                lblSwitch4OnOff.Text = "On";
            }
            else
            {
                lblSwitch4OnOff.Text = "Off";
            }
        }

        private void btnSetFilter_Click(object sender, EventArgs e)
        {
            try
            {
                string canFilter = txtFilter.Text;
                sendCommand(serialPort, "A" + canFilter);
                lblFilterStatus.Text = txtFilter.Text.ToUpper();
                btnSetFilter.Enabled = false;
                txtFilter.Text = "";
                ClearLabels();
            }
            catch (Exception ex)
            {
                lblSMSMessage.Text = "Please connect to the serial port";
            }

        }

        private void btnSetMask_Click(object sender, EventArgs e)
        {
            try
            {
                string canMask = txtMask.Text;
                sendCommand(serialPort, "M" + canMask);
                lblMaskStatus.Text = txtMask.Text.ToUpper();
                btnSetMask.Enabled = false;
                txtMask.Text = "";
                ClearLabels();
            }
            catch (Exception ex)
            {
                lblSMSMessage.Text = "Please connect to the serial port";
            }
        }

        private void btnOutgoing_Click(object sender, EventArgs e)
        {
            try
            {
                outgoingID = txtOutgoing.Text;
                lblBroadCastID.Text = txtOutgoing.Text.ToUpper();
                btnOutgoing.Enabled = false;
                txtOutgoing.Text = "";
                ClearLabels();
            }
            catch(Exception ex)
            {
                lblSMSMessage.Text = "Please connect to the serial port";
            }
            
            
        }

        private void btnIncoming_Click(object sender, EventArgs e)
        {
            try
            {
                string inputID = txtIncoming.Text;
                sendCommand(serialPort, "E" + inputID);
                lblIncomingStatus.Text = txtIncoming.Text.ToUpper();
                btnIncoming.Enabled = false;
                txtIncoming.Text = "";
                ClearLabels();
            }

            catch (Exception ex)
            {
                lblSMSMessage.Text = "Please connect to the serial port";
            }
        }

        private void txtOutgoing_TextChanged(object sender, EventArgs e)
        {
            btnOutgoing.Enabled = true;
        }

        private void txtIncoming_TextChanged(object sender, EventArgs e)
        {
            btnIncoming.Enabled = true;
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            btnSetFilter.Enabled = true;
        }

        private void txtMask_TextChanged(object sender, EventArgs e)
        {
            btnSetMask.Enabled = true;
        }

        private void btnSetTemp_Click(object sender, EventArgs e)
        {
            String settemp = txtSetTemp.Text;

            templimit = Convert.ToInt32(settemp);
            //txtThreshold.Text = settemp;

            if (settemp.Length > 0)
            {
                temperatureprog = true;
            }

            else
            {

                temperatureprog = false;

            }
        }
    }
}
