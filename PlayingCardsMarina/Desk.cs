using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PlayingCardsMarina
{
    public partial class Desk : Form
    {

        private string folderPath = null;
        private string [] fileNames = null;


        public Desk()
        {
            InitializeComponent();
            InitializeDesk();
        }

        private void InitializeDesk()
        {
            this.BackColor = Color.ForestGreen;
          
        }

        private void LoadCards_Click(object sender, EventArgs e)
        {
            PictureBox filePictureBox = null;

            folderPath = @"C:\Users\Installer\Desktop\Programming\Playing Cards\Playing Cards\playing_card_images\face";
            fileNames = Directory.GetFiles(folderPath);

            foreach(var fileName in fileNames)
            {
                filePictureBox = new PictureBox()
                {
                    Height = 100,
                    Width = 70,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Left = 100,
                    Top = 100,
                    Image = Image.FromFile(fileName)
                };
                this.Controls.Add(filePictureBox);
            }
        }
    }
}
