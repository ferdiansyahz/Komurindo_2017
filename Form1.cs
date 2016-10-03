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
using System.Drawing.Drawing2D;
using System.Media;
using System.Windows.Media.Media3D;
using System.Xaml;
using System.Security.Cryptography.Xml;
using System.Xaml.Permissions;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms.DataVisualization.Charting;



//Komurindo UI
//AURORA TEAM UNIVERSITY of INDONESIA

//Program masih perkembangan

namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
        
    {
        

        AxisAngleRotation3D ax3d;
        public Form1()
        {
            InitializeComponent();
            getAvailablePorts();
            ax3d = new AxisAngleRotation3D(new Vector3D(0, 2, 0), 1);
            RotateTransform3D myRotateTransform = new RotateTransform3D(ax3d);

        }
        
        //untuk nampilin port mana yang available
        void getAvailablePorts()
        {
            String[] ports = SerialPort.GetPortNames();
            comboBox1.Items.AddRange(ports);
        }


       
        //Tombol Connect
        private void button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.Text == "" || comboBox2.Text == "")
                {
                    textBox1.Text = "Pilih port terlebih dahulu";

                }
                else
                {
                    //pilih port 
                    serialPort1.PortName = comboBox1.Text;
                    //pilih baudrate
                    serialPort1.BaudRate = Convert.ToInt32(comboBox2.Text);

                    serialPort1.Open();
                    //supaya data yang didapat terus diupdate
                    serialPort1.DataReceived += serialPort1_DataReceived;

                    serialPort1.DataBits = 8;
                    serialPort1.Parity = Parity.None;
                    serialPort1.StopBits = StopBits.One;
                    serialPort1.Handshake = Handshake.None;
                    serialPort1.Encoding = System.Text.Encoding.Default;
                    

                    progressBar1.Value = 100;

                    //supaya button lain aktif
                    button1.Enabled = true;
                    button2.Enabled = true;
                    textBox1.Enabled = true;
                    button3.Enabled = false;
                    button4.Enabled = true;
      
                }
            }
            catch (UnauthorizedAccessException)
            {
                textBox1.Text = "Salah nih";
                //Seandainya port arduino udah diconnect via lain, maka muncul pesan itu
            }     
         }

        //Buat ngambil data roll pitch yaw dari arduino gy85
        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {

            //string [] yup = serialPort1.ReadLine().Split(',');
            string roll = serialPort1.ReadLine();
            string pitch = serialPort1.ReadLine();
            string yaw = serialPort1.ReadLine();
            //string roll = yup[0];
            //string pitch = yup[1];
            //string yaw = yup[2];
            //string yup = serialPort1.ReadLine();
            this.BeginInvoke(new LineReceivedEvent(LineReceived), roll);
            //this.BeginInvoke(new LineReceivedEvent(LineReceived), yup);
            this.BeginInvoke(new LineReceivedEvent1(LineReceived1), yaw);
            this.BeginInvoke(new LineReceivedEvent2(LineReceived2), pitch);

        }
        

        //Buat nampilin data roll dari arduino gy85

        private delegate void LineReceivedEvent(string roll);

        private void LineReceived(string roll)

        {

            textBox2.Text = roll;
            //textBox2.AppendText(yup[0] + "/n");
            //aGauge1.Value = float.Parse(Convert.ToString(yup[0]+','));
            aGauge1.Value = float.Parse(roll);
            artificialHorizon1.roll_angle = float.Parse(roll);
            //aGauge2.Value = float.Parse(pitch);
            //textBox4.Text = Convert.ToString(pitch);
            chart1.Series["Roll"].Points.AddY(float.Parse(roll));
            
            


            //textBox5.Text = Convert.ToString(yaw);
        }

        //Buat nampilin data yaw 
        private delegate void LineReceivedEvent1(string yaw);
        private void LineReceived1(string yaw)
        {
            textBox4.Text = yaw;
            aGauge2.Value = float.Parse(yaw);
            chart1.Series["Yaw"].Points.AddY(float.Parse(yaw));


        }


        //Buat nampilin data pitch
        private delegate void LineReceivedEvent2(string pitch);
        private void LineReceived2(string pitch)
        {
            textBox5.Text = pitch;
            aGauge3.Value = float.Parse(pitch);
            artificialHorizon1.pitch_angle = float.Parse(pitch);
            chart1.Series["Pitch"].Points.AddY(float.Parse(pitch));
        }









        //Tombol Disconnect
        private void button4_Click(object sender, EventArgs e)
        {
            serialPort1.Close();
            progressBar1.Value = 0;
            button1.Enabled = false;
            button2.Enabled = false;
            button4.Enabled = false;
            button3.Enabled = true;
            textBox1.Enabled = false;
        }

        //Buat kontrol sekian derajat servo ke arduino//
        private void button1_Click(object sender, EventArgs e)
        {   
            serialPort1.Write("H");            
        }

       //Buat kontrol sekian derajat servo ke arduino
        private void button2_Click(object sender, EventArgs e)
        {  
            serialPort1.Write("L");    
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void bindingSource2_CurrentChanged(object sender, EventArgs e)
        {

        }

       

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

       
        //Masih progress buat 3d representation
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

            

            /*e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            using (LinearGradientBrush l = new LinearGradientBrush(
              new Rectangle(12, 12, 100, 35), Color.FromArgb(255, 0, 0, 255),
              Color.FromArgb(255, 0, 0, 255), LinearGradientMode.Vertical))
            {
                using (Pen p = new Pen(l, 12))
                    e.Graphics.DrawEllipse(p, new Rectangle(12, 212, 100, 35));
            }

            GraphicsPath gPath = new GraphicsPath();
            gPath.AddArc(new Rectangle(12, 12, 100, 35), 180, 180);
            gPath.AddArc(new Rectangle(12, 212, 100, 35), 0, 180);

            //make the path a bit larger for the bursh
            //so the path gets drawn antialiased
            GraphicsPath g2 = (GraphicsPath)gPath.Clone();
            RectangleF r = g2.GetBounds();
            float w = (r.Width + 4) / r.Width;
            float h = (r.Height + 4) / r.Height;
            g2.Transform(new Matrix(w, 0, 0, h, -2, -2));
            

            using (PathGradientBrush p = new PathGradientBrush(g2))
            {
                p.CenterColor = Color.FromArgb(171, 195, 195, 195);
                p.SurroundColors = new Color[] { Color.FromArgb(171, 0, 0, 255) };
                p.FocusScales = new PointF(0.71F, 0.71F);
                e.Graphics.FillPath(p, gPath);
            }

            using (LinearGradientBrush l = new LinearGradientBrush(
              new Rectangle(12, 12, 100, 35), Color.FromArgb(255, 0, 0, 255),
              Color.FromArgb(255, 0, 0, 255), LinearGradientMode.Vertical))
            {
                using (Pen p = new Pen(l, 12))
                    e.Graphics.DrawEllipse(p, l.Rectangle);
            }

            gPath.Dispose();
            






            //RotateTransform3D myRotateTransform = new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(0, 1, 0), 1));






            rot3D.Rotation3D = new AxisAngleRotation3D(new Vector3D(0, 1, 0), iteratorIndex);

            rot3D.CenterX = // whatever;

            rot3D.CenterY = // whatever;

            rot3D.CenterZ = //whatever;

            my3DObject.Transform = rot3D;*/




        }


        //masih progress bikin 3d object
        private static Image GetCylinderBitmap(int width, int height, Color color)

        {

            Image result = new Bitmap(width, height);

            using (Graphics graphics = Graphics.FromImage(result))

            {

                Brush brush = new SolidBrush(color);

                graphics.FillRectangle(brush, new Rectangle(0, height / 10, width - 1, height - height / 5));

                graphics.FillEllipse(brush, new Rectangle(0, 0, width - 1, height / 5));

                graphics.FillEllipse(brush, new Rectangle(0, height - height / 5 - 1, width - 1, height / 5));

                graphics.DrawLine(Pens.Black, new Point(0, height / 10), new Point(0, height - height / 10));

                graphics.DrawLine(Pens.Black, new Point(width - 1, height / 10), new Point(width - 1, height - height / 10));

                graphics.DrawEllipse(Pens.Black, new Rectangle(0, 0, width - 1, height / 5));

                graphics.DrawArc(Pens.Black, new Rectangle(0, height - height / 5 - 1, width - 1, height / 5), 0.0f, 180.0f);

            }

            return result;

        }

        private void artificialHorizon1_Load(object sender, EventArgs e)
        {
            
        }
        
        private void elementHost1_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }

}




