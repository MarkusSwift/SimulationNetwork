#define PARALLELFOR

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
    public class Ultimate_Simulator_Manager
    {
        public SimulationOptions simulationOptions;
        public Ultimate_Simulator_Manager(SimulationOptions simulationOptions)
        {
            this.simulationOptions = simulationOptions;
        }
        public SimulationResults Run()
        {
            SimulationResults simulationResults = new SimulationResults(simulationOptions.simulations, simulationOptions);
            #if PARALLELFOR
            Parallel.For(0, simulationOptions.simulations, i =>
            #else
            for (int i = 0; i < simulationOptions.simulations; i++)
            #endif
            {
                Network_Simulator networkSimulator = new Network_Simulator();
                networkSimulator.Set_NewNetwork(simulationOptions.population);
                if (simulationOptions.useEdges)
                {
                    networkSimulator.Set_CreateRandomEdges(simulationOptions.edgeDistribution);
                }
                if (simulationOptions.useClique)
                {
                    networkSimulator.Set_CreateCliques(simulationOptions.qlickDistribution, simulationOptions.PresetClickDistribution);
                }
                networkSimulator.Set_Parameters(simulationOptions.rateOfInfect, simulationOptions.rateOfRecovery, simulationOptions.rate_increaseFamilyConnections, simulationOptions.rate_dropInfectedConnections, simulationOptions.rateOfMoving, simulationOptions.distributionRetainGlobalContacts);
                simulationResults.simulationResults[i] = networkSimulator.Do_Simulation();
            }
            #if PARALLELFOR
            );
            #endif
            return simulationResults;
        }
    }
    public class SimulationResults
    {
        public SimulationResult[] simulationResults;
        public SimulationResults(int size, SimulationOptions simOpsGet)
        {
            simulationResults = new SimulationResult[size];
            simOps = simOpsGet;
        }
        private float mean = -1;


        private float MajorOutbreakDef = 0.4f;

        public SimulationOptions simOps;
        //public int Population = 0;

        public float Mean()
        {
            if (mean == -1)
            {
                mean = 0;
                foreach (SimulationResult result in simulationResults)
                {
                    mean += result.infectedTotal;
                }
            }
            return mean / simulationResults.Length;
        }
        public float StandardDiviation()
        {
            mean = Mean();
            float diviation = 0;
            foreach (SimulationResult result in simulationResults)
            {
                diviation += (float)Math.Pow(result.infectedTotal - mean, 2);
            }
            return (float)Math.Sqrt(diviation / (simulationResults.Length - 1));
        }

        public float[] Get_SusMoveFrequency()
        {
            float[] aray = new float[simulationResults[0].frequencyOfMovementMadeOfSusceptible.Length];
            foreach (SimulationResult sim in simulationResults)
            {
                for (int i = 0; i < aray.Length; i++)
                {
                    aray[i] += sim.frequencyOfMovementMadeOfSusceptible[i];
                }
            }

            for (int i = 0; i < aray.Length; i++)
            {
                aray[i] /= simulationResults.Length;
            }

            return aray;
        }

        public float[] Get_InfMoveFrequency()
        {
            float[] aray = new float[simulationResults[0].frequenctOfMovementMadeOfInfected.Length];
            foreach (SimulationResult sim in simulationResults)
            {
                for (int i = 0; i < aray.Length; i++)
                {
                    aray[i] += sim.frequenctOfMovementMadeOfInfected[i];
                }
            }

            for (int i = 0; i < aray.Length; i++)
            {
                aray[i] /= simulationResults.Length;
            }
            return aray;
        }

        public float[] Get_InfCliqueInfSizeFrequency()
        {
            float[] aray = new float[simulationResults[0].frequencyOfInfectedCliqueInfectedSize.Length];
            foreach (SimulationResult sim in simulationResults)
            {
                for (int i = 0; i < aray.Length; i++)
                {
                    aray[i] += sim.frequencyOfInfectedCliqueInfectedSize[i];
                }
            }

            for (int i = 0; i < aray.Length; i++)
            {
                aray[i] /= simulationResults.Length;
            }
            return aray;
        }

        public float[] Get_InfCliqueSizeFrequency()
        {
            float[] aray = new float[simulationResults[0].frequencyOfInfectedCliqueSize.Length];


            foreach (SimulationResult sim in simulationResults)
            {
                for (int i = 0; i < aray.Length; i++)
                {
                    aray[i] += sim.frequencyOfInfectedCliqueSize[i];
                }
            }

            for (int i = 0; i < aray.Length; i++)
            {
                aray[i] /= simulationResults.Length;
            }
            return aray;
        }

        public float[] Get_InfCliqueSizeFrequencyOnlyMajorOutbreak()
        {
            float[] aray = new float[simulationResults[0].frequencyOfInfectedCliqueSize.Length];

            int rem = 0;//ONly used if majoroubreaks

            foreach (SimulationResult sim in simulationResults)
            {
                if (sim.infectedTotal / simOps.population > MajorOutbreakDef)
                {
                    for (int i = 0; i < aray.Length; i++)
                    {
                        aray[i] += sim.frequencyOfInfectedCliqueSize[i];
                    }
                }
                else
                {
                    rem--;
                }
            }

            for (int i = 0; i < aray.Length; i++)
            {
                aray[i] /= simulationResults.Length;
            }
            return aray;
        } //Works with major outbreak only

        public float[] Get_InfCliqueInfSizeFrequencyOnlyMajorOutbreak()
        {
            float[] aray = new float[simulationResults[0].frequencyOfInfectedCliqueInfectedSize.Length];

            int rem = 0;//ONly used if majoroubreaks

            foreach (SimulationResult sim in simulationResults)
            {
                if (sim.infectedTotal / simOps.population > MajorOutbreakDef)
                {
                    for (int i = 0; i < aray.Length; i++)
                    {
                        aray[i] += sim.frequencyOfInfectedCliqueInfectedSize[i];
                    }
                }
                else
                {
                    rem--;
                }
            }

            for (int i = 0; i < aray.Length; i++)
            {
                aray[i] /= simulationResults.Length;
            }
            return aray;
        } //Works with major outbreak only

        public float[] Get_TimeInfBySizeCliqe()
        {
            float[] aray = new float[simulationResults[0].eventTimeCliqueGetsInfected.Length];
            int[] amoutAdded = new int[simulationResults[0].eventTimeCliqueGetsInfected.Length];
            foreach (SimulationResult sim in simulationResults)
            {
                for (int i = 0; i < aray.Length; i++)
                {
                    if (sim.eventTimeCliqueGetsInfected[i] != 0)
                    {
                        aray[i] += sim.eventTimeCliqueGetsInfected[i];
                        amoutAdded[i]++;
                    }
                }
            }

            for (int i = 0; i < aray.Length; i++)
            {
                if (amoutAdded[i] != 0)
                {
                    aray[i] /= amoutAdded[i];
                }
            }
            return aray;
        }

        public float[] Get_TimeInfByInfectedSizeCliqe()
        {
            float[] aray = new float[simulationResults[0].eventTimeCliqueGetsInfectedByInfectedInClique.Length];
            int[] amoutAdded = new int[simulationResults[0].eventTimeCliqueGetsInfectedByInfectedInClique.Length];
            foreach (SimulationResult sim in simulationResults)
            {
                for (int i = 0; i < aray.Length; i++)
                {
                    if (sim.eventTimeCliqueGetsInfectedByInfectedInClique[i] != 0)
                    {
                        aray[i] += sim.eventTimeCliqueGetsInfectedByInfectedInClique[i];
                        amoutAdded[i]++;
                    }
                }
            }

            for (int i = 0; i < aray.Length; i++)
            {
                if (amoutAdded[i] != 0)
                {
                    aray[i] /= amoutAdded[i];
                }
            }
            return aray;
        }

        public float[] Get_IndexCliqueFreqBySize()
        {
            float[] aray = new float[simOps.population];
            foreach (SimulationResult s in simulationResults)
            {
                aray[s.IndexCliqueSize]++;
            }

            for (int i = 0; i < simOps.population - 1; i++)
            {
                aray[i] /= simulationResults.Length;
            }
            return aray;
        }
    }
    public class Network_Simulator
    {
        public Graph m_Graph;
        public int m_Population;
        private float v_rateInfect = 2.4f; 
        private float v_rateRecover = 1.2f;
        float rateMoveAway;
        private float Time = 0;

        bool increaseFamilyConnections = false;
        bool dropInfectedConnections = false;
        bool moveAway = false;

        float rate_increaseFamilyConnections = 0.2f;
        float rate_dropInfectedConnections = 0.3f;

        float[] distributionRetainContact;

        int Event_Time = 0;

        //Stats
        public int TotalCliques = 0;
        public int TOtalCliquesInfected = 0;

        public int TotalMovesMade = 0;

        //Creates a new network
        public void Set_NewNetwork(int Population)
        {
            m_Graph = new Graph(Population);
            m_Population = Population;
            Time = 0;
        }

        //Clear network of all nodes
        //public void Set_ClearNetwork()
        //{
        //    m_Graph.m_nodes = new Node[0];
        //    m_Population = 0;
        //    Time = 0;
        //}

        //Add random cliques
        public void Set_CreateCliques(float[] Distribution, int[] PresetDIst)
        {
            int CurrentUsed_Nodes = 0;
            List<int> Clique_Sizes = new List<int>();
            if(PresetDIst != null)
            {
                for (int num = 0; num < PresetDIst.Count(); num++)
                {
                    CurrentUsed_Nodes += PresetDIst[num];
                    Clique_Sizes.Add(PresetDIst[num]);
                }

            }

            while (CurrentUsed_Nodes < m_Population)
            {
                int randVal = -1;
                float randomVal_Creator = Statistics.GetUniformal();
                while (randomVal_Creator > 0)
                {
                    randVal += 1;
                    randomVal_Creator -= Distribution[randVal];

                    //Make sure we dont loopp to much
                    if (randVal > 120)
                    {
                        break;
                    }
                }
                if(randVal <= m_Population - CurrentUsed_Nodes)
                {
                    CurrentUsed_Nodes += randVal;
                    Clique_Sizes.Add(randVal);
                }
                else
                {
                    break;
                }
            }
            TotalCliques = Clique_Sizes.Count();
            TOtalCliquesInfected = 0;
            int position = 0;
            int iterator = -1;
            foreach (int size in Clique_Sizes)
            {
                iterator++;
                //int[] ThingsToAdd = int[]
                Clique n_clique = new Clique(m_Graph);

                for (int i = position; i < size + position; i++) 
                {
                    n_clique.Set_NewCliqueMemeber(m_Graph.Get_NodeFromInt(i));
                    n_clique.index = iterator;
                    m_Graph.Get_NodeFromInt(i).Clique_Index = iterator;
                    for (int q = i + 1; q < position + size; q++)
                    {
                        m_Graph.Set_CliqueNeighbour(i, q);
                    }
                }
                m_Graph.m_cliques.Add(n_clique);

                position += size;
            }
            //List<int> Nodes_Left = new List<int>();

            //for (int i = 0; i < m_Population; i++)
            //{
            //    Nodes_Left.Add(i);
            //}

            //foreach (int value in Clique_Sizes)
            //{
            //    if (value <= Nodes_Left.Count)
            //    {
            //        int[] Array = new int[value];
            //        for (int a = 0; a < value; a++)
            //        {
            //            int index = Statistics.Get_Integer(0, Nodes_Left.Count);
            //            Array[a] = Nodes_Left[index];
            //            Nodes_Left.RemoveAt(index);
            //        }
            //        m_Graph.Set_Neighbours(Array);
            //    }
            //}
        }

        //Add random edges to the network
        public void Set_CreateRandomEdges(float[] Distribution)
        {
            List<int> v_NodesWithEdges = new List<int>();
            List<int> v_AmountOfEdgesInEachNode = new List<int>();
            
            int TotalNodes = 0;

            for (int c_Node = 0; c_Node < m_Population; c_Node++)
            {
                v_NodesWithEdges.Add(c_Node);
                int randVal = -1;
                float randomVal_Creator = Statistics.GetUniformal();
                while (randomVal_Creator > 0)
                {
                    randVal++;
                    randomVal_Creator -= Distribution[randVal];
                }

                v_AmountOfEdgesInEachNode.Add(randVal);
                if (v_AmountOfEdgesInEachNode[c_Node] == 0)
                {
                    v_NodesWithEdges.Remove(c_Node);
                }
                TotalNodes += randVal;
            }
            int val1 = 0;
            int val2 = 0;

            int Node1;
            int Node2;
            while(TotalNodes > 1)
            {
                val1 = Statistics.Get_Integer(0, TotalNodes);
                
                val2 = Statistics.Get_Integer(0, TotalNodes-1);
                
                TotalNodes -= 2;
                int iterator = -1;
                while (val1 >= 0)
                {
                    iterator++;
                    val1 -= v_AmountOfEdgesInEachNode[iterator];
                }
                Node1 = iterator;
                v_AmountOfEdgesInEachNode[iterator]--;
                iterator = -1;
                while (val2 >= 0)
                {
                    iterator++;
                    val2 -= v_AmountOfEdgesInEachNode[iterator];
                }
                Node2 = iterator;
                v_AmountOfEdgesInEachNode[iterator]--;

                m_Graph.Set_Neighbours(Node1, Node2);
            }
        }

        public int Get_ContactsToRetain()
        {
            int interator = -1;
            float rand = Statistics.GetUniformal(); //När den blir ett blir det fel
            while (rand >= 0)
            {
                interator++;
                rand -= distributionRetainContact[interator];
            }
            return interator;
        }

        public void Set_Parameters(float rateInfect, float rateRecover, float rate_incFamilyConnec, float rate_dropInfectConnec, float rateMoveAway, float[] distriutionRetainGLobalContact)
        {
            v_rateInfect = rateInfect;
            v_rateRecover = rateRecover;
            if (rate_incFamilyConnec != 0)
            {
                rate_increaseFamilyConnections = rate_incFamilyConnec;
                increaseFamilyConnections = true;
            }
            if (rate_dropInfectConnec != 0)
            {
                rate_dropInfectedConnections = rate_dropInfectConnec;
                dropInfectedConnections = true;
            }
            if (rateMoveAway != 0)
            {
                this.rateMoveAway = rateMoveAway;
                distributionRetainContact = distriutionRetainGLobalContact;
                moveAway = true;
            }
        }

        //run simulatoin with current setup
        public SimulationResult Do_Simulation()
        {
            float v_pressure = 0;
            int v_infected = 0;
            int v_susNextToInf = 0;
            int v_globalSusInfecEdges = 0;
            int v_nodesEligbleForCliqueUpgrade=0;

            float pressure_MoveAway = 0;

            float prob_dropInfecConnec = 0;
            float prob_increaseCliqueWeight = 0;
            float probMoveAway = 0;

            string v_event = "-1";

            m_Graph.Do_InfectRandomAtStart();

            while(m_Graph.Get_NumberOfInfected() != 0)
            {
                Event_Time += 1;
                m_Graph.Event_Time = Event_Time;

                v_infected = m_Graph.Get_NumberOfInfected();
                v_susNextToInf = m_Graph.Get_SusceptibleNeibhoursToInfected();
                if (moveAway)
                {
                    int sum = 0;
                    foreach (Clique clique in m_Graph.m_cliques)
                    {
                        sum += clique.NumberOfInfected * (clique.Get_AmountMembers() - clique.NumberOfInfectedTotaly);
                    }
                    //int hej = m_Graph.m_infectedNodes.Sum(node => node.m_cliqueNeighbours.Count(neightbour => neightbour.M_state == Node_State.susceptible));
                    //if (sum != hej)
                    //{
                    //    throw new Exception();
                    //}
                    pressure_MoveAway = rateMoveAway * sum;
                    v_pressure = v_infected * v_rateRecover + v_susNextToInf * v_rateInfect + pressure_MoveAway;
                }
                else if (dropInfectedConnections && increaseFamilyConnections)
                {
                    v_globalSusInfecEdges = m_Graph.Get_GlobalInfectedSusceptibleConnections();
                    v_nodesEligbleForCliqueUpgrade = m_Graph.Get_AmoutNodesEligbleForCliqueWeightIncrease();
                    v_pressure = v_infected * v_rateRecover + v_susNextToInf * v_rateInfect + v_globalSusInfecEdges * rate_dropInfectedConnections + rate_increaseFamilyConnections*v_nodesEligbleForCliqueUpgrade;
                }
                else if (dropInfectedConnections)
                {
                    v_globalSusInfecEdges = m_Graph.Get_GlobalInfectedSusceptibleConnections();
                    v_pressure = v_infected * v_rateRecover + v_susNextToInf * v_rateInfect + v_globalSusInfecEdges * rate_dropInfectedConnections;
                }
                else if (increaseFamilyConnections)
                {
                    v_nodesEligbleForCliqueUpgrade = m_Graph.Get_AmoutNodesEligbleForCliqueWeightIncrease();
                    v_pressure = v_infected * v_rateRecover + v_susNextToInf * v_rateInfect + rate_increaseFamilyConnections * v_nodesEligbleForCliqueUpgrade;
                }
                else if(!dropInfectedConnections && !increaseFamilyConnections)
                {
                    v_pressure = v_infected * v_rateRecover + v_susNextToInf * v_rateInfect;
                }

                //Time += Statistics.Get_ExponentialDistribution(1 / v_pressure);

                float rand = Statistics.GetUniformal();
                float prob_infec = v_susNextToInf * v_rateInfect / v_pressure;
                float prob_rec = v_infected * v_rateRecover / v_pressure;
                if (dropInfectedConnections && increaseFamilyConnections)
                {
                    prob_dropInfecConnec = rate_increaseFamilyConnections * v_nodesEligbleForCliqueUpgrade/v_pressure;
                    prob_increaseCliqueWeight = v_globalSusInfecEdges * rate_dropInfectedConnections/v_pressure;
                }
                else if (dropInfectedConnections)
                {
                    prob_dropInfecConnec = rate_dropInfectedConnections * v_globalSusInfecEdges / v_pressure;
                }
                else if (increaseFamilyConnections)
                {
                    prob_increaseCliqueWeight = v_nodesEligbleForCliqueUpgrade * rate_dropInfectedConnections / v_pressure;
                }
                else if (moveAway)
                {
                    probMoveAway = pressure_MoveAway / v_pressure;
                }
                
                if (rand < prob_infec)
                {
                    //Infec
                    v_event = "infec";
                }
                else if (rand < prob_infec + prob_rec)
                {
                    v_event = "recover";
                }
                else if (rand < prob_infec + prob_rec + prob_dropInfecConnec)
                {
                    v_event = "dropInfec";
                }
                else if (rand < prob_infec + prob_rec + prob_dropInfecConnec + prob_increaseCliqueWeight)
                {
                    v_event = "incWeight";
                }
                else if (rand < prob_infec + prob_rec + prob_dropInfecConnec + prob_increaseCliqueWeight + probMoveAway)
                {
                    v_event = "-1";
                    int val = Get_ContactsToRetain();
                    TotalMovesMade++;
                    m_Graph.MoveAwayNode(val);
                }
                else
                {
                    //h
                }

                CarryOutEvent(v_event);
            }

            float[] EventTimeOfCliqueInfectionByInfectedPopulation = new float[50];
            float[] AmountDataPoints_EventTimeOfCliqueInfectionByInfectedPopulation = new float[50];
            foreach (Clique c in m_Graph.m_cliques)
            {
                if (c.NumberOfInfectedTotaly != 0)
                {
                    EventTimeOfCliqueInfectionByInfectedPopulation[Math.Min(c.Get_RemovedMemeber(), EventTimeOfCliqueInfectionByInfectedPopulation.Length - 1)] += c.Event_TimeInfected;
                    AmountDataPoints_EventTimeOfCliqueInfectionByInfectedPopulation[Math.Min(c.Get_RemovedMemeber(), AmountDataPoints_EventTimeOfCliqueInfectionByInfectedPopulation.Length - 1)]++;
                }
            }

            for (int a = 0; a < EventTimeOfCliqueInfectionByInfectedPopulation.Length; a++)
            {
                if (AmountDataPoints_EventTimeOfCliqueInfectionByInfectedPopulation[a] != 0)
                {
                    EventTimeOfCliqueInfectionByInfectedPopulation[a] /= AmountDataPoints_EventTimeOfCliqueInfectionByInfectedPopulation[a];
                }
            }


            int[] EventTimeOfCliqueInfection = new int[50];
            int[] AmountDataPoints_EventTimeOfCliqueInfection = new int[50];

            int[] frequencyOfMovesSus = new int[20];
            int[] frequencyOfMovesInf = new int[20];
            foreach (Clique c in m_Graph.m_cliques)
            {
                if (c.NumberOfInfectedTotaly != 0)
                {
                    EventTimeOfCliqueInfection[Math.Min(c.Get_AmountMembers(), EventTimeOfCliqueInfection.Length - 1)] += c.Event_TimeInfected;
                    AmountDataPoints_EventTimeOfCliqueInfection[Math.Min(c.Get_AmountMembers(), EventTimeOfCliqueInfection.Length - 1)]++;
                }
            }

            for (int a = 0; a < EventTimeOfCliqueInfection.Length; a++)
            {
                if (AmountDataPoints_EventTimeOfCliqueInfection[a] != 0)
                {
                    EventTimeOfCliqueInfection[a] /= AmountDataPoints_EventTimeOfCliqueInfection[a];
                }
            }


            foreach (Node n in m_Graph.m_nodes)
            {
                if (n.M_state == Node_State.susceptible)
                {
                    frequencyOfMovesSus[Math.Min(n.TimesMoved, frequencyOfMovesSus.Length - 1)] += 1;
                }
                else if (n.M_state == Node_State.removed)
                {

                    frequencyOfMovesInf[Math.Min(n.TimesMoved, frequencyOfMovesInf.Length - 1)] += 1;
                }
            }

            int[] freqeucyOfInfectedCLiqueSizeInfected = new int[m_Population];
            int[] freqeucyOfInfectedCLiqueSize = new int[m_Population];
            foreach (Clique c in m_Graph.m_cliques)
            {
                freqeucyOfInfectedCLiqueSizeInfected[c.Get_RemovedMemeber()]++;
                freqeucyOfInfectedCLiqueSize[c.Get_AmountMembers()]++;
            }

            List<Node> newNodes = new List<Node>();
            foreach (Node n in m_Graph.m_recoveredNodes)
            {
                bool Broken = false;
                foreach (Node m in n.m_cliqueNeighbours)
                {
                    if (newNodes.Contains(m))
                    {
                        Broken = true;
                        break;
                    }
                }
                if (!Broken)
                {
                    newNodes.Add(n);
                }
            }
            TOtalCliquesInfected = newNodes.Count();

            int IndexCliqueSize = 0;
            foreach (Clique c in m_Graph.m_cliques)
            {
                if (c.isIndexCase)
                {
                    IndexCliqueSize = c.Get_AmountMembers();
                    break;
                }
            }

            SimulationResult sim = new SimulationResult
            {
                time = Time,
                infectedTotal = m_Graph.m_recoveredNodes.Count,
                TotalCliques = TotalCliques,
                TotalCliques_Infected = TOtalCliquesInfected,
                MovementsMade = TotalMovesMade,
                frequencyOfMovementMadeOfSusceptible = frequencyOfMovesSus,
                frequenctOfMovementMadeOfInfected = frequencyOfMovesInf,
                frequencyOfInfectedCliqueInfectedSize = freqeucyOfInfectedCLiqueSizeInfected,
                frequencyOfInfectedCliqueSize = freqeucyOfInfectedCLiqueSize,
                eventTimeCliqueGetsInfected = EventTimeOfCliqueInfection,
                eventTimeCliqueGetsInfectedByInfectedInClique = EventTimeOfCliqueInfectionByInfectedPopulation,
                IndexCliqueSize = IndexCliqueSize
            };

            return sim;
        }
        
        private void CarryOutEvent(string m_event)
        {
            switch (m_event)
            {
                case "infec":
                    m_Graph.Do_InfectSusceptibleNextToInfect();
                    break;
                case "recover":
                    m_Graph.Do_RecoverRandomInfectedNode();
                    break;
                case "dropInfec":
                    m_Graph.Set_DropInfectedSusConnection();
                    break;
                case "incWeight":
                    m_Graph.Set_IncreaseCliqueWeightOfNode(1);
                    break;
            }
        }
    }
    
    public class SimulationResult
    {
        public float time;
        public int infectedTotal;
        public int TotalCliques;
        public int TotalCliques_Infected;

        public int MovementsMade;

        public int[] frequencyOfMovementMadeOfSusceptible;
        public int[] frequenctOfMovementMadeOfInfected;

        public int[] frequencyOfInfectedCliqueInfectedSize;
        public int[] frequencyOfInfectedCliqueSize;

        public int[] eventTimeCliqueGetsInfected;

        public float[] eventTimeCliqueGetsInfectedByInfectedInClique;
        public int IndexCliqueSize;
    }
}