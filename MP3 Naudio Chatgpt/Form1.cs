using System;
using System.Windows.Forms;
using Bass_Dll_Player.cs;


namespace Bass_Dll_Player
{
    
    public partial class Form1 : Form
    {
        //https://www.youtube.com/watch?v=jpOcIsNeueQ&t=476s VIDEO RUSSO channel "DiZ Like"


        public Form1()
        {
           InitializeComponent();                     
        }


        private void button1_Click(object sender, EventArgs e)  // botao PLAY
        {
            if((playlist.Items.Count!=0) && (playlist.SelectedItem != null))
            {
                string current = Vars.Files[playlist.SelectedIndex];
                BassLike.Play(current, BassLike.Volume);
                

                label1.Text = TimeSpan.FromSeconds(BassLike.GetPosOfStream(BassLike.Stream)).ToString();
                label2.Text = TimeSpan.FromSeconds(BassLike.GetTimeOfStream(BassLike.Stream)).ToString();

                trackBar1.Maximum = BassLike.GetTimeOfStream(BassLike.Stream);
                trackBar1.Value = BassLike.GetPosOfStream(BassLike.Stream);

                timer1.Enabled = true;

            }

        }

        private void button2_Click(object sender, EventArgs e) // Botao STOP
        {
            BassLike.Stop();
            timer1.Enabled = false;
            trackBar1.Value = 0;
            label1.Text = "00:00:00";

        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e) // OpenDialog
        {
            // nota que Vars é a classe que fizemos no ficheiro Vars.cs
            Vars.Files.Add(openFileDialog1.FileName);
            playlist.Items.Add(Vars.GetFileName(openFileDialog1.FileName));
        }

        private void button3_Click(object sender, EventArgs e)  // Botao abri ficheiros
        {
            openFileDialog1.ShowDialog();
            
        }

        private void trackBar1_Scroll(object sender, EventArgs e) // Trackbarr propriedades - Scroll
        {
            BassLike.SetPosOfScroll(BassLike.Stream, trackBar1.Value);
        }

        private void timer1_Tick(object sender, EventArgs e) // Timmer propriedades dois clicks
        {
            label1.Text = TimeSpan.FromSeconds(BassLike.GetPosOfStream(BassLike.Stream)).ToString();
            trackBar1.Value = BassLike.GetPosOfStream(BassLike.Stream);
        }

        private void trackBar2_Scroll(object sender, EventArgs e) // Boato de Volume
        {
            BassLike.SetVolumeToStream(BassLike.Stream, trackBar2.Value);
        }
    }
}
