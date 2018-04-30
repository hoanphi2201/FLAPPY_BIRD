using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
namespace Ver_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int x_cap1, x_cap2, x_cap3;
        int x_ongtren1, y_ongtren1, x_ongtren2, y_ongtren2, x_ongtren3, y_ongtren3;
        int DoChenhLechGiua2Ong = 200;
        int x_ongduoi1, y_ongduoi1, x_ongduoi2, y_ongduoi2, x_ongduoi3, y_ongduoi3;
        int x_ConChim, y_ConChim;
        private void Refesh()
        {
            ConChim.Image = Image.FromFile(@"chim.png");
            Background_Pic.Size = new Size(this.Width, this.Height);
            // set background
            OngCongDuoi1.Size = new Size(180, 730);
            OngCongTren1.Size = new Size(180, 709);
            OngCongDuoi2.Size = new Size(180, 730);
            OngCongTren2.Size = new Size(180, 709);
            OngCongDuoi3.Size = new Size(180, 730);
            OngCongTren3.Size = new Size(180, 709);
            // set llocation
            // ống 1

            // random độ cao
            Random rd = new Random();
            y_ongtren1 = -372; // độ cao ống trên  - 300 (tôi muốn ống đầu luôn có độ cao 300)
            y_ongtren2 = rd.Next(-550, -250); // ống trên + y_oongstren = độ cao hiển thị
            x_cap1 = this.Width + 300;
            OngCongTren1.Location = new Point(x_cap1, y_ongtren1);
            y_ongduoi1 = (DoChenhLechGiua2Ong + (OngCongTren1.Height + y_ongtren1));
            OngCongDuoi1.Location = new Point(x_cap1, y_ongduoi1);
            // ống 2
            x_cap2 = this.Width + 300 + OngCongTren1.Width + 350;
            y_ongtren2 = 400 - OngCongTren2.Height; // ống trên + y_oongstren = độ cao hiển thị
            OngCongTren2.Location = new Point(x_cap2, y_ongtren2);
            y_ongduoi2 = (DoChenhLechGiua2Ong + (OngCongTren2.Height + y_ongtren2));
            OngCongDuoi2.Location = new Point(x_cap2, y_ongduoi2);
            // ống 3
            x_cap3 = this.Width + 300 + 2 * OngCongTren1.Width + 2 * 350;
            Random rd3 = new Random();
            y_ongtren3 = rd3.Next(-550, -250); // ống trên + y_oongstren = độ cao hiển thị
            OngCongTren3.Location = new Point(x_cap3, y_ongtren3);
            y_ongduoi3 = (DoChenhLechGiua2Ong + (OngCongTren3.Height + y_ongtren3));
            OngCongDuoi3.Location = new Point(x_cap3, y_ongduoi3);

            // Set con chim
            ConChim.Size = new Size(122, 80);
            ConChim.Parent = Background_Pic;
            ConChim.BackColor = Color.Transparent;
            x_ConChim = 136;
            y_ConChim = 309;
            //x_ConChim = ConChim.Location.X;
            //y_ConChim = ConChim.Location.Y;
            //ConChim.BackColor = Color.FromArgb(0, 135, 147);
            // Set timer
            Timer_Chay.Interval = 1;
            //Timer_Chay.Start();
            // Buton Play
            
            Play.Location = new Point(250,270);
            Play.Size = new Size(120, 50);
            Play.BackColor = Color.FromArgb(0, 135, 147);
            TimerChim.Interval = 100;
            // TimerChim.Start();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Refesh();
        }
        bool check;
        int DiemSo = 0;
        private void Timer_Chay_Tick(object sender, EventArgs e)
        {
            Play.Location = new Point(0, 0);
            check = false;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
            x_cap1 -= 10;
            x_cap2 -= 10;
            x_cap3 -= 10;
            OngCongTren1.Location = new Point(x_cap1, y_ongtren1);
            y_ongduoi1 = (DoChenhLechGiua2Ong + (OngCongTren1.Height + y_ongtren1));
            OngCongDuoi1.Location = new Point(x_cap1, y_ongduoi1);
            // ống 2
            OngCongTren2.Location = new Point(x_cap2, y_ongtren2);
            y_ongduoi2 = (DoChenhLechGiua2Ong + (OngCongTren2.Height + y_ongtren2));
            OngCongDuoi2.Location = new Point(x_cap2, y_ongduoi2);
            // ống 3
            OngCongTren3.Location = new Point(x_cap3, y_ongtren3);
            y_ongduoi3 = (DoChenhLechGiua2Ong + (OngCongTren3.Height + y_ongtren3));
            OngCongDuoi3.Location = new Point(x_cap3, y_ongduoi3);
            if (x_cap1 + OngCongTren1.Width <= 0)
            {
                Random rd = new Random();
                // random độ cao
                y_ongtren1 = rd.Next(-550, -250);
                x_cap1 = 850 + OngCongTren2.Width + 350; // mỗi ống cách nhau 250
                DiemSo++;
                OngCongTren1.Location = new Point(x_cap1, y_ongtren1);
                OngCongDuoi1.Location = new Point(x_cap1, y_ongduoi1);
                
            }
            if (x_cap2 + OngCongTren2.Width <= 0)
            {
                x_cap2 = 850 + OngCongDuoi1.Width + 350;
                DiemSo++;
                // Random y: 1000 + y = docao;
                Random rd = new Random();
                y_ongtren2 = rd.Next(-550, -250);
                OngCongTren2.Location = new Point(x_cap2, y_ongtren2);
                OngCongDuoi2.Location = new Point(x_cap2, y_ongduoi2);

            }
            if (x_cap3 + OngCongTren3.Width <= 0)
            {
                
                x_cap3 = 850 + OngCongDuoi2.Width + 350;
                DiemSo++;
                // Random y: 1000 + y = docao;
                Random rd = new Random();
                y_ongtren3 = rd.Next(-550, -250);
                OngCongTren3.Location = new Point(x_cap3, y_ongtren3);
                OngCongDuoi3.Location = new Point(x_cap3, y_ongduoi3);
            }
            lblDiemSo.Text = "Điểm : "+ DiemSo.ToString();
            //if (x_cap1 <= 200 || x_cap2 <= 200 || x_cap3 <= 200)
            //{
            //    check = true;
            //    TimerChim3.Interval = 200;
            //    TimerChim3.Start();
            //}
        }
        int demClickPlay = 1;
        private void Play_Click(object sender, EventArgs e)
        {
            if (demClickPlay % 2 != 0)
            {
                Timer_Chay.Start();
                TimerChim.Start();
                TimerChim.Interval = 100;
            }
            else
            {
                Timer_Chay.Stop();
                TimerChim.Stop();
            }
            demClickPlay++;
        }
        int dem = 1;
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (dem % 2 != 0 )
            {
                SoundPlayer sound = new SoundPlayer("Fly.wav");
                sound.LoadAsync();
                sound.Play(); 
            }
            
            TimerChim2.Stop();
            //TimerChim3.Stop();
            if (e.KeyCode == Keys.Space)
            {
                if (y_ConChim >= 0)
                {
                    y_ConChim -= 50;
                    ConChim.Image = Image.FromFile(@"chimlenpts.png");
                    ConChim.Size = new Size(111, 91);
                }
            }
            dem++;
        }

        private void TimerChim_Tick(object sender, EventArgs e)
        {
            //this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
            if (y_ConChim + ConChim.Height <= this.Height)
            {
                y_ConChim += 15;
                this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
                bool Check_Play = false;
                if (x_ConChim + ConChim.Width >= x_cap1 && x_ConChim + ConChim.Width <= x_cap1 + OngCongTren1.Width)
                {
                    if (y_ConChim <= 709 + y_ongtren1 || y_ConChim + ConChim.Height >= y_ongduoi1)
                    {
                        Timer_Chay.Stop();
                        //TimerChim.Stop();
                        if (TimerChim.Interval == 100)
                        {
                            Check_Play = true;
                            SoundPlayer sound = new SoundPlayer("Dead.wav");
                            sound.LoadAsync();
                            sound.Play(); 
                            
                        }
                        TimerChim.Interval = 300;
                        
                    }
                }
                ConChim.Location = new Point(x_ConChim, y_ConChim);
                if (x_ConChim + ConChim.Width >= x_cap2 && x_ConChim + ConChim.Width <= x_cap2 + OngCongTren1.Width)
                {
                    if (y_ConChim <= 709 + y_ongtren2 || y_ConChim + ConChim.Height >= y_ongduoi2)
                    {
                        Timer_Chay.Stop();
                        if (TimerChim.Interval == 100)
                        {
                            Check_Play = true;
                            SoundPlayer sound = new SoundPlayer("Dead.wav");
                            sound.LoadAsync();
                            sound.Play();
                        }
                        TimerChim.Interval = 300;
                    }
                }
                ConChim.Location = new Point(x_ConChim, y_ConChim);
                if (x_ConChim + ConChim.Width >= x_cap3 && x_ConChim + ConChim.Width <= x_cap3 + OngCongTren1.Width)
                {
                    if (y_ConChim <= 709 + y_ongtren3 || y_ConChim + ConChim.Height >= y_ongduoi3)
                    {
                        Timer_Chay.Stop();
                        if (TimerChim.Interval == 100)
                        {
                            Check_Play = true;
                            SoundPlayer sound = new SoundPlayer("Dead.wav");
                            sound.LoadAsync();
                            sound.Play();
                        }
                        TimerChim.Interval = 300;
                    }
                }
                if (Check_Play == true)
                {
                    if (MessageBox.Show("Điểm: " + DiemSo.ToString() + "\n Ê có chơi tiếp không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Timer_Chay.Stop();
                        TimerChim.Stop();
                        Refesh();
                        DiemSo = 0;
                    }
                    else
                    {
                        Application.Exit();
                    }
                }
                ConChim.Location = new Point(x_ConChim, y_ConChim);
                
            }
            
        }

        private void TimerChim2_Tick(object sender, EventArgs e)
        {
            ConChim.Image = Image.FromFile(@"chimxuong2pts.png");
            ConChim.Size = new Size(146, 136);
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            ConChim.Image = Image.FromFile(@"chim.png");
            ConChim.Size = new Size(122, 80);
            TimerChim2.Stop();
            TimerChim2.Interval = 400;
            TimerChim2.Start();
        }
        private void TimerChim3_Tick(object sender, EventArgs e)
        {
        }
    }
}
