using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyFormA
{
    class Start_Form : System.Windows.Forms.Form
    {
        public Start_Form()
        {
            Button st_btn = new Button
            {
                Text = "8k saalid",
                Location = new System.Drawing.Point(10, 10)
            };
            st_btn.Click += St_btn_Click;
            this.Controls.Add(st_btn);
            Button st_btn2 = new Button()
            {
                Text = "4k saal",
                Location = new System.Drawing.Point(10, 50)
            };
            st_btn2.Click += St_btn_Click1; ;
            this.Controls.Add(st_btn2);

            PictureBox film = new PictureBox
            {
                Image = Image.FromFile(@"..\..\Filmid\titinik.jpg")
                Location = new System.Drawing.Point(10, 100);
                
            };
            this.Controls.Add(film);
            film.Click += Film_Click1; 
         
        }
           string filminimetus;

           private void Film_Click1(object sender, EventArgs e)
          {
               filminimetus=Film();
          }
          private void Film()
          {
              filminimetus = "Titanik";
              return filminimetus;
          }




    private void St_btn_Click1(object sender, EventArgs e)
        {
            FormAgain newWin = new FormAgain(10, 10,filminimetus);
            newWin.StartPosition = FormStartPosition.CenterScreen;

            newWin.ShowDialog();
        }

        private void St_btn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Vabandage saalid ei töötovad ,saalite lahti alustamine on 20.05.2023");

           
        }
         
        
    }
}
