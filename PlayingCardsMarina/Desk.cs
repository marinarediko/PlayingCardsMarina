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
using System.Runtime.CompilerServices;
using System.Net.Mime;

namespace PlayingCardsMarina
{
    public partial class Desk : Form
    {

        private string folderPath = null;
        private string [] fileNames = null;
        private Random rand = new Random();
        private List<PictureBox> cards= new List<PictureBox>();


        public Desk()
        {
            InitializeComponent();
            InitializeDesk();
        }

        private void InitializeDesk()
        {
            this.BackColor = Color.ForestGreen;
          
        }

        
        private string SelectFolder()
        {
            var selectFolderDialog = new FolderBrowserDialog();
            DialogResult result = selectFolderDialog.ShowDialog();

            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(selectFolderDialog.SelectedPath))
            {
                return selectFolderDialog.SelectedPath;
            }
            return null;
        }
        


        private void LoadCards_Click(object sender, EventArgs e)
        {
            PictureBox filePictureBox = null;

            folderPath = @"C:\Users\Installer\Desktop\Programming\Playing Cards\Playing Cards\playing_card_images\face";
            // SELECT CARDS FROM FOLDER
            //folderPath = SelectFolder();
            if (folderPath== null)
            {
                return;
            }

            fileNames = Directory.GetFiles(folderPath);

            foreach(var fileName in fileNames)
            {

                filePictureBox = new PictureBox()
                {
                    Height = 90,
                    Width = 65,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Left = rand.Next(0,1000),
                    Top = rand.Next(50,500),
                    Image = Image.FromFile(fileName)
                };
                filePictureBox.Click += Card_Click;
                this.Controls.Add(filePictureBox);
                cards.Add(filePictureBox);
            }
        }

        private void StackCards_Click(object sender, EventArgs e)
        {
            int x = 100, y = 100;
            foreach (var card in cards)
            {
                card.Location = new Point(x, y);
                x++;
                y++;
            }
        }

        private void DeckCards_Click(object sender, EventArgs e)
        {
            int counter = 0;
            for (int x = 1; x < 10; x++)
            {
                for (int y = 1; y < 7; y++)
                {
                    cards[counter].Location = new Point(x * 70, y * 100 - 50);
                    counter++;

                }
            }
        }

        private void Card_Click(object sender, EventArgs e)
        {
            var card = (PictureBox)sender;
            card.Location = new Point(10, 30);
            card.BringToFront();

        }



    }
}
