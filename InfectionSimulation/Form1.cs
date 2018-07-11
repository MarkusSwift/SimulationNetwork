using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graph_Lib
{
    public partial class Form1 : Form
    {
        private SimulationOptions simulationOptions;
        public Form1()
        {
            InitializeComponent();
        }
        private void ButtonRun_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();
            SetParam();
            Ultimate_Simulator_Manager networkSimulator = new Ultimate_Simulator_Manager(simulationOptions);
            //networkSimulator.SetFamilyDropSettings(0.2f, 0.4f);
            SimulationResults simulationResults = networkSimulator.Run();
            charten.Series[0].Points.Clear();
            charten.Series[1].Points.Clear();
            charten.Series[2].Points.Clear();
            charten.Series[3].Points.Clear();
            charten.Series[4].Points.Clear();
            charten.Series[5].Points.Clear();
            charten.Series[6].Points.Clear();
            charten.Series[7].Points.Clear();
            charten.Series[8].Points.Clear();
            charten.Series[9].Points.Clear();
            charten.Series[0].Name = "Infekterade";
            charten.Series[1].Name = "Susceptible move";
            charten.Series[2].Name = "Infekted move";
            charten.Series[3].Name = "Inf. clique pop";
            charten.Series[4].Name = "Inf. clique inf. pop";
            charten.Series[5].Name = "Time clique. inf";
            charten.Series[6].Name = "Time clique inf by ind pop";
            charten.Series[7].Name = "Inf. clique pop MO";
            charten.Series[8].Name = "Inf. clique infP MO";
            charten.Series[9].Name = "Inf. clique index infP";
            int[] results = new int[simulationOptions.population + 1];
            float[] results_susMoved = simulationResults.Get_SusMoveFrequency();
            float[] results_infMoved = simulationResults.Get_InfMoveFrequency();
            float[] results_InfcliqueSizeFrequency = simulationResults.Get_InfCliqueSizeFrequency();
            float[] results_InfCliqueInfSizeFrequenct = simulationResults.Get_InfCliqueInfSizeFrequency();
            float[] results_TimeInfByCliqueSize = simulationResults.Get_TimeInfBySizeCliqe();
            float[] results_TimeInfByInfectedCliqueSize = simulationResults.Get_TimeInfByInfectedSizeCliqe();
            float[] results_InfcliqueSizeFrequencyMO = simulationResults.Get_InfCliqueSizeFrequencyOnlyMajorOutbreak();
            float[] results_InfcliqueInfSizeFrequencyMO = simulationResults.Get_InfCliqueInfSizeFrequencyOnlyMajorOutbreak();
            float[] results_InfcliqueSizeFrequencyIndex = simulationResults.Get_IndexCliqueFreqBySize();

            //Chart 4
            for (int i = 0; i < 40; i++)
            {
                charten.Series[9].Points.AddXY(i, results_InfcliqueSizeFrequencyIndex[i]);
            }
            for (int i = 0; i < 40; i++)
            {
                charten.Series[7].Points.AddXY(i, results_InfcliqueSizeFrequencyMO[i]);
            }
            for (int i = 0; i < 40; i++)
            {
                charten.Series[3].Points.AddXY(i, results_InfcliqueSizeFrequency[i]);
            }
            //End

            for (int i = 1; i < results_TimeInfByInfectedCliqueSize.Length; i++)
            {
                charten.Series[8].Points.AddXY(i, results_InfcliqueSizeFrequencyMO[i]);
            }

            for (int i = 0; i < results_TimeInfByInfectedCliqueSize.Length; i++)
            {
                charten.Series[6].Points.AddXY(i, results_TimeInfByInfectedCliqueSize[i]);
            }
            for (int i = 0; i < results_TimeInfByCliqueSize.Length; i++)
            {
                charten.Series[5].Points.AddXY(i, results_TimeInfByCliqueSize[i]);
            }
            for (int i = 0; i < results_susMoved.Length; i++)
            {
                charten.Series[1].Points.AddXY(i, results_susMoved[i]);
            }
            for (int i = 0; i < results_infMoved.Length; i++)
            {
                charten.Series[2].Points.AddXY(i, results_infMoved[i]);
            }

            for (int i = 1; i < results_InfCliqueInfSizeFrequenct.Length; i++)
            {
                charten.Series[4].Points.AddXY(i, results_InfCliqueInfSizeFrequenct[i]);
            }

            for (int i = 0; i < simulationOptions.simulations; i++)
            {
                results[simulationResults.simulationResults[i].infectedTotal]++;
            }

            for (int i = 1; i < simulationOptions.population + 1; i++)
            {
                charten.Series[0].Points.AddXY(i, results[i]);
            }
            int size = 0;
            for (int i = Convert.ToInt32(0.4f * simulationOptions.population); i < simulationOptions.population + 1; i++)
            {
                size += results[i];
            }
            labelSize.Text = "Size: " + size;
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"simulations\simulation" + System.IO.Directory.GetFiles("simulations").Length + ".txt"))
            {
                file.WriteLine(simulationOptions + " name:1; name:2;????? name:3;Infected_Clique_Population name:4;Infected_Clique_Infected_Population name:5;Time_Clique_Infected_by_Population name:6;Time_Clique_Infected_by_Infected_Population name:7;Infected_Clique_Population_Given_Major_Outbreak name:8;Infected_Clique_Infected_Population_Given_Major_Outbreak name:9;Index_Clique_Population run:True standardDiviation:True cliquesAndMovement:True time:" + DateTime.Today.ToShortDateString() + "|" + DateTime.Now.ToLongTimeString() + " kommentar:" + textBoxKommentar.Text);
                foreach (float result in results)
                {
                    file.WriteLine(result);
                }
                file.WriteLine("%");
                foreach (float result in results_susMoved)
                {
                    file.WriteLine(result);
                }
                file.WriteLine("%");
                foreach (float result in results_infMoved)
                {
                    file.WriteLine(result);
                }
                file.WriteLine("%");
                foreach (float result in results_InfcliqueSizeFrequency)
                {
                    file.WriteLine(result);
                }
                file.WriteLine("%");
                foreach (float result in results_InfCliqueInfSizeFrequenct)
                {
                    file.WriteLine(result);
                }
                file.WriteLine("%");
                foreach (float result in results_TimeInfByCliqueSize)
                {
                    file.WriteLine(result);
                }
                file.WriteLine("%");
                foreach (float result in results_TimeInfByInfectedCliqueSize)
                {
                    file.WriteLine(result);
                }
                file.WriteLine("%");
                foreach (float result in results_InfcliqueSizeFrequencyMO)
                {
                    file.WriteLine(result);
                }
                file.WriteLine("%");
                foreach (float result in results_InfcliqueInfSizeFrequencyMO)
                {
                    file.WriteLine(result);
                }
                file.WriteLine("%");
                foreach (float result in results_InfcliqueSizeFrequencyIndex)
                {
                    file.WriteLine(result);
                }
            }
            labelElapsedTime.Text = "Time: " + stopwatch.Elapsed;
        }
        private void SetParam()
        {
            simulationOptions = new SimulationOptions((int)numericUpDownSimulations.Value, (int)numericUpDownPopulation.Value, (float)numericUpDownInfection.Value, (float)numericUpDownRecovery.Value);

            float[] retainGlobalContactDistribution = new float[2];
            retainGlobalContactDistribution[0] = 0.8f;
            retainGlobalContactDistribution[1] = 1f;
            simulationOptions.SetRateMoveAway((float)numericUpDownMoving.Value, retainGlobalContactDistribution);

            float[] qlickDistribution = new float[21];
            //qlickDistribution[15] = 1;// 0.95f;
            qlickDistribution[20] = 2;
            //qlickDistribution[100] = 0.1f;
            simulationOptions.SetCliqueDistribution(qlickDistribution);

            int[] qlickPresetDistribution = new int[2];
            qlickPresetDistribution[0] = 200;
            qlickPresetDistribution[1] = 40;
            //qlickPresetDistribution[1] = 100;
            //simulationOptions.Set_PresetCliqkc(qlickPresetDistribution);

            float[] edgeDistribution = new float[21];
            edgeDistribution[0] = 0.9f;
            edgeDistribution[1] = 1.1f;
            simulationOptions.SetRandomEdgeDistribution(edgeDistribution);
        }
        private void ButtonSpecial_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();
            SetParam();
            int varv = (int)numericUpDownVarv.Value;
            float[] results = new float[varv];
            float[] diviation = new float[varv];
            float[] results_clique = new float[varv];
            float[] results_edgesCreatedFromMovement = new float[varv];
            float[] results_indexCliqueSize = new float[varv];
            float[] results_averageClqueSizeGivenMO = new float[varv];
            charten.Series[0].Points.Clear();
            charten.Series[1].Points.Clear();
            charten.Series[2].Points.Clear();
            charten.Series[3].Points.Clear();
            charten.Series[4].Points.Clear();
            charten.Series[5].Points.Clear();
            charten.Series[6].Points.Clear();
            charten.Series[7].Points.Clear();
            charten.Series[8].Points.Clear();
            charten.Series[0].Name = "Infekterade";
            charten.Series[1].Name = "Clique";
            charten.Series[2].Name = "Edge create from movement";
            charten.Series[3].Name = "Standard diviation";
            charten.Series[4].Name = "average index size";
            charten.Series[5].Name = "??";
            charten.Series[6].Name = "???";
            charten.Series[7].Name = "????";
            charten.Series[8].Name = "?????";
            charten.Series[9].Name = "??????";
            for (int i = 0; i < varv; i++)
            {

                //float[] n = new float[i + 2];
                //n[i + 1] = 1;
                //simulationOptions.SetCliqueDistribution(n);
                simulationOptions.rateOfMoving = (i) * (float)numericUpDownMoving.Value;
                Ultimate_Simulator_Manager networkSimulator = new Ultimate_Simulator_Manager(simulationOptions);
                SimulationResults simulationResults = networkSimulator.Run();
                // int MO = 0;
                for (int q = 0; q < simulationOptions.simulations; q++)
                {
                    /*if (simulationResults.simulationResults[q].infectedTotal > simulationOptions.population * 0.3)
                    {
                        results[i] += simulationResults.simulationResults[q].infectedTotal;
                        MO++;
                    }*/
                    results[i] += simulationResults.simulationResults[q].infectedTotal;
                    results_clique[i] += (float)simulationResults.simulationResults[q].TotalCliques_Infected / simulationResults.simulationResults[q].TotalCliques;
                    results_edgesCreatedFromMovement[i] += simulationResults.simulationResults[q].MovementsMade;
                    results_indexCliqueSize[i] += simulationResults.simulationResults[q].IndexCliqueSize;
                }
                results_indexCliqueSize[i] /= simulationOptions.simulations;
                results_clique[i] /= simulationOptions.simulations;
                results[i] = simulationResults.Mean();
                diviation[i] = simulationResults.StandardDiviation();
                results_edgesCreatedFromMovement[i] /= simulationOptions.simulations;
                charten.Series[0].Points.AddXY(i + 1, results[i]);
                charten.Series[1].Points.AddXY(i + 1, results_clique[i]);
                charten.Series[2].Points.AddXY(i + 1, results_edgesCreatedFromMovement[i]);
                charten.Series[3].Points.AddXY(i + 1, diviation[i]);
                charten.Series[4].Points.AddXY(i + 1, results_indexCliqueSize[i]);
                charten.Update();
            }
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"simulations\simulation" + System.IO.Directory.GetFiles("simulations").Length + ".txt"))
            {
                file.WriteLine(simulationOptions + " run:False standardDiviation:True cliquesAndMovement:True time:" + DateTime.Today.ToShortDateString() + "|" + DateTime.Now.ToLongTimeString() + " kommentar:" + textBoxKommentar.Text);
                for (int i = 0; i < varv; i++)
                {
                    file.WriteLine(results[i] + " " + diviation[i] + " " + results_clique[i] + " " + results_edgesCreatedFromMovement[i]);
                }
            }
            labelElapsedTime.Text = "Time: " + stopwatch.Elapsed;
        }
    }
}