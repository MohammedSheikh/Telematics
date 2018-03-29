using System;
using System.Threading;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using System.Drawing;

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
            }
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

        private void btnMotorOnOff_Click(object sender, EventArgs e)
        {
            if (lblMStatus.Text == "Off")
            {
                sendCommand(serialPort, "F");
                lblMStatus.Text = "On";
                btnMotorFwdRev.Enabled = true;
                btnMotorFwdRev.Text = "Motor Reverse";
                lblMDirection.Text = "Forward";
            }
            else
            {
                sendCommand(serialPort, "S");
                lblMStatus.Text = "Off";
                btnMotorFwdRev.Enabled = false;
                btnMotorFwdRev.Text = "Motor (Fwd/Rev)";
                lblMDirection.Text = "";
            }
        }

        private void btnLED1OnOff_Click(object sender, EventArgs e)
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

        private void btnLED2OnOff_Click(object sender, EventArgs e)
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

        private void btnLED3OnOff_Click(object sender, EventArgs e)
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

        private void btnLED4OnOff_Click(object sender, EventArgs e)
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

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearFields();
            ClearLabels();
            sendCommand(serialPort, "@");
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


        private void CTEC3426_Load(object sender, EventArgs e)
        {
            btnMotorFwdRev.Enabled = false;
            lblMDirection.Text = "";
        }

        private void btnGetTemp_Click(object sender, EventArgs e)
        {
            sendCommand(serialPort, "t");
            
            
        }
        void getTemp(string Tet)
        {
            //terminal.AppendText(Tet);
            //if(temp)
        }

        private void btnMotorFwdRev_Click(object sender, EventArgs e)
        {
            
            if (btnMotorFwdRev.Text == "Motor Forward")
            {
                sendCommand(serialPort, "F");
                btnMotorFwdRev.Text = "Motor Reverse";
                lblMDirection.Text = "Forward";
            }
            else if (btnMotorFwdRev.Text == "Motor Reverse")
            {
                sendCommand(serialPort, "R");
                btnMotorFwdRev.Text = "Motor Forward";
                lblMDirection.Text = "Reverse";
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string number = txtSMS.Text; 

            if(number.Length != 11)
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
                "S=" +  switchOne +  ", " + switchTwo + ", " + switchThree + ", " + switchFour;

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
            string canFilter = txtFilter.Text;
            sendCommand(serialPort, "A" + canFilter);
        }

        private void btnSetMask_Click(object sender, EventArgs e)
        {
            string canMask = txtMask.Text;
            sendCommand(serialPort, "M" + canMask);
        }

        private void btnOutgoing_Click(object sender, EventArgs e)
        {
            string broadcastID =txtOutgoing.Text;
            sendCommand(serialPort, "B" + broadcastID);
        }

        private void btnIncoming_Click(object sender, EventArgs e)
        {
            string inputID = txtOutgoing.Text;
            sendCommand(serialPort, "E" + inputID);
        }
    }
}
