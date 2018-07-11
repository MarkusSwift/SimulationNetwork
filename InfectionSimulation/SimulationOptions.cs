using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_Lib
{
    public class SimulationOptions
    {
        public int simulations;
        public int population;
        public float rateOfInfect;
        public float rateOfRecovery;
        public float rateOfMoving;
        public float[] qlickDistribution;
        public float[] edgeDistribution;
        public float[] distributionRetainGlobalContacts;
        public bool useClique = false;
        public bool useEdges = false;
        public float rate_increaseFamilyConnections = 0;
        public float rate_dropInfectedConnections = 0;
        public int[] PresetClickDistribution;

        public void Set_PresetCliqkc(int[] preset_clique)
        {
            PresetClickDistribution = preset_clique;
        }
        public SimulationOptions(int simulations, int population, float rateOfInfect, float rateOfRecovery)
        {
            this.rateOfInfect = rateOfInfect;
            this.rateOfRecovery = rateOfRecovery;
            this.population = population;
            this.simulations = simulations;
        }
        public void SetFamilyDropSettings(float r_increaseFamilyConnects, float r_dropInfectedConnecions)
        {
            if (r_increaseFamilyConnects != 0)
            {
                rate_increaseFamilyConnections = r_increaseFamilyConnects;
                //increaseFamilyConnections = true;
            }
            else
            {
                //increaseFamilyConnections = false;
            }

            if (r_dropInfectedConnecions != 0)
            {
                rate_dropInfectedConnections = r_dropInfectedConnecions;
                //dropInfectedConnections = true;
            }
            else
            {
                //dropInfectedConnections = false;
            }
        }
        public void SetCliqueDistribution(float[] distribution_Cliques)
        {
            useClique = true;
            qlickDistribution = distribution_Cliques;
        }
        public void SetRandomEdgeDistribution(float[] distribution_Edges)
        {
            useEdges = true;
            edgeDistribution = distribution_Edges;
        }
        public void SetRateMoveAway(float rateOfMoving, float[] distKeepContacts)
        {
            this.rateOfMoving = rateOfMoving;
            distributionRetainGlobalContacts = distKeepContacts;
        }
        public void SetRateMoveAway(float rateOfMoving)
        {
            this.rateOfMoving = rateOfMoving;
        }
        public override string ToString()
        {
            string edges = "";
            foreach (float probability in edgeDistribution)
            {
                edges += probability + "|";
            }
            edges += "0";
            string cliques = "";
            foreach (float probability in qlickDistribution)
            {
                cliques += probability + "|";
            }
            cliques += "0";
            string retain = "";
            foreach (float probability in retain)
            {
                retain += probability + "|";
            }
            retain += "0";
            return "simulations:" + simulations + " population:" + population + " rateOfInfect:" + rateOfInfect + " rateOfRecovery:" + rateOfRecovery + " rateOfMoving:" + rateOfMoving + " edgeDistribution:" + edges + " cliqueDistribution:" + cliques + " retainConnectionsDistribution:" + retain;
        }
    }
}