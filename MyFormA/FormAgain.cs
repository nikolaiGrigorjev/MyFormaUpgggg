using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyFormA
{
    public partial class FormAgain : Form
    {
        Label messiah = new Label();
        Button[] btn = new Button[3];
        Button btn_tbl;
        TableLayoutPanel tbl = new TableLayoutPanel();
        string[] texts = new string[3];
        
        public FormAgain() { }
      
        int btn_w, btn_h;
        public FormAgain(string title, string body, string button1, string button2, string button3)
        {
            texts[0] = button1;
            texts[1] = button2;
            texts[2] = button3;
            
            
            this.ClientSize = new System.Drawing.Size(500, 500);
            this.Text = title;
            int x = 10;
            for (int i = 0; i < 3; i++)
            {
                btn[i] = new Button
                {
                    Location = new System.Drawing.Point(x, 20),
                    Size = new System.Drawing.Size(30, 30),
                    Text = texts[i]
                   
            };
                
                btn[i].Click += FormAgain_Click;
                x += 100;
                this.Controls.Add(btn[i]);
            }
            
            messiah.Location = new System.Drawing.Point(10, 10);
            messiah.Text = body;
            this.Controls.Add(messiah);
        }
        

            public FormAgain(int x,int y)
        {
            this.tbl.ColumnCount = x;
            this.tbl.RowCount = y;
            this.tbl.ColumnStyles.Clear();
            this.tbl.RowStyles.Clear();
            for (int i = 0; i < x; i++)
            {
                this.tbl.RowStyles.Add(new RowStyle(SizeType.Percent,
                    100/y));
            }
            for (int i = 0; i < y; i++)
            {
                this.tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100 / x));
            }
            this.Size = new System.Drawing.Size(y * 100, x * 100);
            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    var btn_tbl = new Button
                    {
                        Text = string.Format("rida {0},koht {1}", i+ 1, j+ 1),
                        Name = string.Format("{1}{0}", j+ 1,  i+1),
                        Dock = DockStyle.Fill,
                       
                    };
                    btn_tbl.MouseClick += Btn_tbl_MouseClick;
                    this.tbl.Controls.Add(btn_tbl, i, j);
                    btn_tbl.BackColor = Color.LawnGreen;
                }
                btn_w = (int)(100 / y);
                btn_h = (int)(100 / x);
                this.tbl.Dock = DockStyle.Fill;
               // this.tbl.Size = new System.Drawing.Size(tbl.ColumnCount * btn_w*4, tbl.RowCount * btn_h*4);
                this.Controls.Add(tbl);
            }
        }

        private void Btn_tbl_MouseClick(object sender, MouseEventArgs e)
        {
            Button b = sender as Button;
            b.BackColor = Color.Red;

        }

        private void FormAgain_Click(object sender, EventArgs e)
        {
            Button btn_click = (Button)sender;
            //MessageBox.Show(btnS.Text + " button was clicked");
            btn_click.BackColor = Color.Yellow;
            string[] rida_koht = btn_tbl.Name.Split('_');
            MyFormA.Pilet P= new Pilet(int.Parse(rida_koht[1]), int.Parse(rida_koht[0]));
            if (MessageBox.Show("Sinu pilet on : Rida:" + (rida_koht[1]) + "Koht:" + (rida_koht[0]),
                    "Kas ostad?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                btn_click.BackColor = Color.Red;
            }
            else
            {
                btn_click.BackColor = Color.Green;
            };
           


        }
    }
}
