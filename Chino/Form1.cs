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
using Cocoa;

namespace Chino
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = System.IO.Directory.GetCurrentDirectory();
            openFileDialog1.ShowDialog();
            string path = openFileDialog1.FileName;
            MessageBox.Show("Start");
            StartAutomation(path);
            MessageBox.Show("End");

        }

        private void StartAutomation(string path)
        {
            StreamReader sr = new StreamReader(path);
            string scenario = sr.ReadToEnd();
            
            System.Diagnostics.Debug.WriteLine("========================================");
            System.Diagnostics.Debug.WriteLine(scenario);

            StringReader stringReader = new StringReader(txtVariables.Text);
            string paramLine = null;
            while ((paramLine = stringReader.ReadLine()) != null)
            {
                string[] param = paramLine.Split(':');
                scenario = scenario.Replace(param[0],param[1]);
            }
            System.Diagnostics.Debug.WriteLine("========================================");
            System.Diagnostics.Debug.WriteLine(scenario);

            ScenarioPlayer player = new ScenarioPlayer(scenario);
            player.Play();
        }
    }
}
