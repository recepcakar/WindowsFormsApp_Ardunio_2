using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace WindowsFormsApp_Ardunio_2
{
    public partial class Form1 : Form
    {
        string[] Port_List;
        bool baglanti_durumu = false;


        public Form1()
        {
            InitializeComponent();
        }

        void PortListele()
        {
            comboBox1.Items.Clear();
            Port_List = SerialPort.GetPortNames();
            foreach (string port in Port_List)
            {
                comboBox1.Items.Add(port);
                if (Port_List[0] != null)
                {
                    comboBox1.SelectedItem = Port_List[0];
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            groupBox4.Enabled = false;
            PortListele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PortListele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (baglanti_durumu == false)
            {
                serialPort1.PortName = comboBox1.SelectedItem.ToString(); // Düzeltildi
                serialPort1.BaudRate = 9600;
                serialPort1.Open();
                comboBox1.Enabled = false;
                button2.Enabled = false;
                baglanti_durumu = true;
                button1.Text = "bağlantı kes";
                groupBox4.Enabled = true;
            }

            else
            {
                serialPort1.Close();
                baglanti_durumu = false;
                button1.Text = "bağlan";
                comboBox1.Enabled=true;
                button2 .Enabled=true;
                groupBox4.Enabled=false;

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            serialPort1.Write("0");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                serialPort1.Write("5");
            }
            else
                serialPort1.Write("6");
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                serialPort1.Write("1");
            }
            else
                serialPort1.Write("2");
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                serialPort1.Write("7");
            }
            else
                serialPort1.Write("8");
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                serialPort1.Write("3");
            }
            else
                serialPort1.Write("4");
        }
    }
}
