using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Cocoa
{
    public class ScenarioPlayer
    {
        private List<string> steps;

        public ScenarioPlayer(string scenario)
        {
            steps = new List<string>();
            StringReader stringReader = new StringReader(scenario);
            string line = null;
            while ((line = stringReader.ReadLine()) != null)
            {
                if (!line.StartsWith("//"))
                {
                    steps.Add(line);
                }
            }

        }

        public void Play()
        {
            foreach (string step in steps)
            {
                string[] elements = step.Split(',');

                if (elements[0].Equals("Confirm"))
                {
                    Application.OpenForms[0].Activate();
                    DialogResult result = MessageBox.Show(elements[1], "Confirmation", MessageBoxButtons.YesNo);
                    if (result == DialogResult.No)
                    {
                        break;
                    }
                }
                
                if (elements[0].Equals("ActivateWindow"))
                {
                    EventExecutor.ActivateWindow(int.Parse(elements[1]));
                }

                if (elements[0].Equals("Sleep"))
                {
                    EventExecutor.Sleep(int.Parse(elements[1]));
                }

                if (elements[0].Equals("MouseLeftPress"))
                {
                    EventExecutor.MouseLeftPress(int.Parse(elements[1]), int.Parse(elements[2]));
                }

                if (elements[0].Equals("PressEnter"))
                {
                    EventExecutor.PressEnter();
                }

                if (elements[0].Equals("PressDown"))
                {
                    EventExecutor.PressDown();
                }

                if (elements[0].Equals("PressTab"))
                {
                    EventExecutor.PressTab();
                }

                if (elements[0].Equals("PressUp"))
                {
                    EventExecutor.PressUp();
                }

                if (elements[0].Equals("PressLeftArrow"))
                {
                    EventExecutor.PressLeftArrow();
                }

                if (elements[0].Equals("PressRightArrow"))
                {
                    EventExecutor.PressRightArrow();
                }

                if (elements[0].Equals("PressPageUp"))
                {
                    EventExecutor.PressPageUp();
                }

                if (elements[0].Equals("PressPageDown"))
                {
                    EventExecutor.PressPageDown();
                }

                if (elements[0].Equals("PressHome"))
                {
                    EventExecutor.PressHome();
                }

                if (elements[0].Equals("PressEnd"))
                {
                    EventExecutor.PressEnd();
                }

                if (elements[0].Equals("PressSpace"))
                {
                    EventExecutor.PressSpace();
                }

                if (elements[0].Equals("PressEsc"))
                {
                    EventExecutor.PressEsc();
                }
            }
        }
    }
}
