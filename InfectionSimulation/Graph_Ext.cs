using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Graph_Lib
{
    public enum Node_State { susceptible, infected, removed }

    public class Clique
    {
        private Graph graph;
        public Clique(Graph graph)
        {
            this.graph = graph;
        }
        public List<Node> m_nodes = new List<Node>();
        public int index = 0;
        private int numberOfInfected = 0;
        public bool isIndexCase = false;



        public int NumberOfInfected
        {
            get
            {
                //return m_nodes.Count(x => x.M_state == Node_State.infected);
                return numberOfInfected;
            }
        }
        private int numberOfInfectedTotaly = 0;
        public int NumberOfInfectedTotaly
        {
            get
            {
                //return m_nodes.Count(x => x.M_state == Node_State.infected || x.M_state == Node_State.removed);
                return numberOfInfectedTotaly;
            }
        }
        public void NodeIsInfected()
        {
            if (NumberOfInfectedTotaly == 0)
            {
                Event_TimeInfected = graph.Event_Time;
            }
            numberOfInfected++;
            numberOfInfectedTotaly++;
        }
        public void NodeIsRecovered()
        {
            numberOfInfected--;
        }
        public void Set_NewCliqueMemeber(Node node)
        {
            if (!m_nodes.Contains(node))
            {
                foreach (Node alreadyIn in m_nodes)
                {
                    graph.Set_CliqueNeighbour(node.index, alreadyIn.index);
                }
                m_nodes.Add(node);
                if (node.M_state == Node_State.infected)
                {
                    numberOfInfected++;
                }
                node.Clique_Index = index;
            }
        }

        public void Set_RemoveMember(Node node)
        {
            m_nodes.Remove(node);
            foreach (Node cn in m_nodes)
            {
                cn.Set_RemoveCliqueNeighbour(node);
            }
            node.Set_RemoveAllCliqueNeighbours();
            if (node.M_state == Node_State.infected)
            {
                numberOfInfected--;
            }
        }

        public int Get_AmountMembers()
        {
            return m_nodes.Count;
        }

        public int Get_RemovedMemeber()
        {
            int am = 0;
            foreach(Node n in m_nodes)
            {
                if(n.M_state == Node_State.removed)
                {
                    am++;
                }
            }
            return am;
        }

        public int Event_TimeInfected = 0;
    }

    public class Graph
    {
        public Node[] m_nodes;
        public List<Node> m_infectedNodes = new List<Node>();
        public List<Node> m_recoveredNodes = new List<Node>();

        public List<Clique> m_cliques = new List<Clique>();

        public int m_Population;

        public int Event_Time;

        //Constructor
        public Graph(int a_Nodes)
        {
            m_nodes = new Node[a_Nodes];
            for (int i = 0; i < a_Nodes; i++)
            {
                m_nodes[i] = new Node(this)
                {
                    index = i
                };
            }
            m_Population = a_Nodes;
        }
        public int Get_NumberOfInfected()
        {
            return m_infectedNodes.Count;
        }
        public int Get_NumberOfSusceptible()
        {
            return m_Population - m_infectedNodes.Count - m_recoveredNodes.Count;
        }
        
        //Create Neibhours
        public void Set_Neighbours(int element1, int element2)
        {
            Node node1 = m_nodes[element1];
            Node node2 = m_nodes[element2];
            node1.Set_NewNeighbour(node2);
            node2.Set_NewNeighbour(node1);
        }

        public void Set_CliqueNeighbour(int element1, int element2)
        {
            Node node1 = m_nodes[element1];
            Node node2 = m_nodes[element2];
            node1.Set_NewCliqueNeighbour(node2);
            node2.Set_NewCliqueNeighbour(node1);
        }
        //Create neibhours between many objects, sets them to be clique neigbours
        public void Set_Neighbours(int[] n_nei)
        {
            for (int c_nei = 0; c_nei < n_nei.Length; c_nei++)
            {
                for (int i = n_nei.Length - 1; i >= c_nei + 1; i--)
                {
                    Set_CliqueNeighbour(n_nei[c_nei], n_nei[i]);
                }
            }
        }
        //Get Node Object
        public Node Get_NodeFromInt(int elemnt)
        {
            return m_nodes[elemnt];
        }

        //Remove node with Node object
        //Sets node state to removed
        //public void Set_RemoveNode(Node n_node)
        //{
        //    foreach (Node n2_Node in n_node.m_neighbours)
        //    {
        //        n2_Node.Set_RemoveNeighbour(n_node);
        //        if (XORSusAndInf(n_node, n2_Node))
        //        {
        //            susToInfect--;
        //        }
        //    }
        //    n_node.m_state = Node_State.removed;
        //    foreach (Node node in n_node.m_cliqueNeighbours)
        //    {
        //        if (XORSusAndInf(node, n_node))
        //        {
        //            susToInfect -= n_node.Get_CliqueWeight(node);
        //        }
        //    }
        //    n_node.Set_RemoveAllNeighbours();
        //}

        //Remove node with Index
        //Sets node state to removed
        //public void Set_RemoveNode(int n_NodeIndex)
        //{
        //    Node n_Node = m_nodes[n_NodeIndex];
        //    foreach (Node n2_Node in n_Node.m_neighbours)
        //    {
        //        n2_Node.Set_RemoveNeighbour(n_Node);
        //    }
        //    n_Node.m_state = Node_State.removed;
        //    n_Node.Set_RemoveAllNeighbours();
        //}
        public void Do_InfectNode(int nodeNum)
        {
            Node node = Get_NodeFromInt(nodeNum);
            Do_InfectNode(node);
        }
        public void Do_InfectNode(Node node) //Funkar ej om kliqqvän med sig själv
        {
            node.Infect();
        }

        public void Do_RecoverNode(int NodeNum)
        {
            Node node = Get_NodeFromInt(NodeNum);
            Do_RecoverNode(node);
        }
        public void Do_RecoverNode(Node node)
        {
            node.Recover();
        }
        public void MoveAwayNode(int AmountToRetain)
        {
            int[] probSelected = new int[m_nodes.Length];
            int sum = 0;
            for (int i = 0; i < m_nodes.Length; i++)
            {
                if (m_nodes[i].M_state == Node_State.susceptible)
                {
                    probSelected[i] = m_cliques[m_nodes[i].Clique_Index].NumberOfInfected;
                    sum += probSelected[i];
                }
            }
            int rand = Statistics.Get_Integer(0, sum);
            int iterator = -1;
            while (rand >= 0)
            {
                iterator++;
                rand -= probSelected[iterator];
            }

            MoveAwayNode(m_nodes[iterator], AmountToRetain);
        }

        private void MoveAwayNode(Node node, int AmounToRetain)
        {
            for (int i = 0; i < AmounToRetain; i++)
            {
                int randInt = Statistics.Get_Integer(0, node.m_cliqueNeighbours.Count);
                int iterator = -1;
                foreach (Node n in node.m_cliqueNeighbours)
                {
                    iterator++;
                    if (iterator == randInt)
                    {
                        Set_Neighbours(node.index, n.index);
                    }
                }
            }
            int Orand;
            /*do
            {
                rand = Statistics.Get_Integer(0, m_nodes.Length);
            } while (rand == node.index);*/
            Orand = Statistics.Get_Integer(0, m_cliques.Count);
            m_cliques[node.Clique_Index].Set_RemoveMember(node);
            m_cliques[Orand].Set_NewCliqueMemeber(node);
            node.TimesMoved++;
        }
        public int Get_GlobalInfectedSusceptibleConnections() //Måste fixa !!!
        {
            int amount = 0;
            foreach (Node n in m_infectedNodes)
            {
                foreach (Node m in n.m_neighbours)
                {
                    if (m.M_state == Node_State.susceptible && m.m_cliqueNeighbours.Count != 0)
                    {
                        amount++;
                    }
                }
            }
            return amount;
        }

        public void Set_DropInfectedSusConnection(int amoutNextToSusGlobal)
        {
            int rand = Statistics.Get_Integer(0, amoutNextToSusGlobal);
            int amount = 0;


            foreach (Node n in m_infectedNodes)
            {
                foreach (Node m in n.m_neighbours)
                {
                    if (m.M_state == Node_State.susceptible && m.m_cliqueNeighbours.Count != 0)
                    {
                        amount++;
                        if (amount >= rand)
                        {
                            Set_DropConnection(m, n);
                            return;
                        }
                    }
                }

            }
        }

        public void Set_DropInfectedSusConnection()
        {
            int val = Get_GlobalInfectedSusceptibleConnections();
            Set_DropInfectedSusConnection(val);
        }

        public void Set_DropConnection(Node node1, Node node2)
        {
            node1.Set_RemoveNeighbour(node2);
            node2.Set_RemoveNeighbour(node1);
        }

        public int Get_AmoutNodesEligbleForCliqueWeightIncrease()
        {
            int amount = 0;
            foreach (Node n in m_nodes)
            {
                if (n.M_state == Node_State.susceptible && n.m_cliqueNeighbours.Count != 0)
                {
                    foreach (Node m in n.m_neighbours)
                    {
                        if (m.M_state == Node_State.infected)
                        {
                            amount++;
                        }
                    }
                }
            }
            return amount;
        }

        public void Set_IncreaseCliqueWeightOfNode(int Increase)
        {
            int am = Get_AmoutNodesEligbleForCliqueWeightIncrease();
            Set_IncreaseCliqueWeightOfNode(Increase, am);
        }

        public void Set_IncreaseCliqueWeightOfNode(int Increase, int AmountELgibleNodes)
        {
            int targ = Statistics.Get_Integer(0, AmountELgibleNodes);
            int amount = 0;
            foreach (Node n in m_nodes)
            {
                if (n.M_state == Node_State.susceptible && n.m_cliqueNeighbours.Count != 0)
                {
                    foreach (Node m in n.m_neighbours)
                    {
                        if (m.M_state == Node_State.infected)
                        {
                            amount++;
                            if (amount >= targ)
                            {
                                foreach (Node noder in n.m_cliqueNeighbours)
                                {
                                    Set_IncreaseCliqueWeight(Increase, n, noder);
                                    foreach (Node noder2 in n.m_cliqueNeighbours)
                                    {
                                        if (noder != noder2)
                                        {
                                            Set_IncreaseCliqueWeightOneWay(Increase, noder, noder2);
                                        }
                                    }
                                }

                                return;
                            }
                        }
                    }
                }
            }
        }

        public void Set_IncreaseCliqueWeightOneWay(int Increase, Node node1IncreaseOn, Node node2whichnode1increasesconnectionwith)
        {
            node1IncreaseOn.Set_ChangeCliqueEdgeValue(Increase, node2whichnode1increasesconnectionwith);
            if (node1IncreaseOn.M_state == Node_State.infected && node2whichnode1increasesconnectionwith.M_state == Node_State.susceptible)
            {
                susToInfect += Increase;
            }
        }
        public void Set_IncreaseCliqueWeight(int Increase, Node node1, Node node2)
        {
            node1.Set_ChangeCliqueEdgeValue(Increase, node2);
            node2.Set_ChangeCliqueEdgeValue(Increase, node1);
        }

        public void Do_InfectRandomAtStart()
        {
            int index = Statistics.Get_Integer(0, m_Population);
            /*do
            {
                index = Statistics.Get_Integer(0, m_Population);
            }
            while (m_nodes[index].m_cliqueNeighbours.Count < 50);*/
            m_cliques[m_nodes[index].Clique_Index].isIndexCase = true;
            Do_InfectNode(m_nodes[index]);
        }
        public int susToInfect = 0;
        public int Get_SusceptibleNeibhoursToInfected()
        {
            return susToInfect;
        }
        public int Get_SusceptibleNeibhoursToInfectedFuskvariant()
        {
            int amount = 0;
            foreach (Node n in m_infectedNodes)
            {
                foreach (Node m in n.m_neighbours)
                {
                    if (m.M_state == Node_State.susceptible)
                    {
                        amount++;
                    }
                }
                foreach (Node m in n.m_cliqueNeighbours)
                {
                    if (m.M_state == Node_State.susceptible)
                    {
                        amount += n.Get_CliqueWeight(m);
                    }
                }
            }
            return amount;
        }

        public void Do_InfectSusceptibleNextToInfect(int amoutNextToSus)
        {
            int rand = Statistics.Get_Integer(0, amoutNextToSus);
            int amount = 0;
            
            foreach (Node n in m_infectedNodes)
            {
                foreach (Node m in n.m_neighbours)
                {
                    if (m.M_state == Node_State.susceptible)
                    {
                        amount++;
                        if (amount >= rand)
                        {
                            Do_InfectNode(m);
                            return;
                        }
                    }
                }
                foreach (Node m in n.m_cliqueNeighbours) //Kan förbättras???
                {
                    if (m.M_state == Node_State.susceptible)
                    {
                        amount += n.Get_CliqueWeight(m);
                        if (amount >= rand)
                        {
                            Do_InfectNode(m);
                            return;
                        }
                    }
                }
                //amount += m_cliques[n.Clique_Index].Get_AmountMembers() - m_cliques[n.Clique_Index].NumberOfInfectedTotaly;
                //if (amount >= rand)
                //{
                //    foreach (Node neightbour in n.m_cliqueNeighbours)
                //    {
                //        if (neightbour.M_state == Node_State.susceptible)
                //        {
                //            if (rand == amount)
                //            {
                //                Do_InfectNode(neightbour);
                //                return;
                //            }
                //            amount--;
                //        }
                //    }
                //}
                //foreach (Node m in n.m_cliqueNeighbours)
                //{
                //    if (m.M_state == Node_State.susceptible)
                //    {
                //        amount += n.Get_CliqueWeight(m);
                //        if (amount >= rand)
                //        {
                //            Do_InfectNode(m);
                //            return;
                //        }
                //    }
                //}
            }
        }

        public void Do_InfectSusceptibleNextToInfect()
        {
            int amoutNextToSus = Get_SusceptibleNeibhoursToInfected();
            Do_InfectSusceptibleNextToInfect(amoutNextToSus);
        }

        public void Do_RecoverRandomInfectedNode()
        {
            int infectedNodes = Get_NumberOfInfected();
            int rand = Statistics.Get_Integer(0, infectedNodes);
            Do_RecoverNode(m_infectedNodes[rand]);
        }
    }

    public class Node
    {
        //public List<Node> m_neighbours = new List<Node>();
        //public Dictionary<int, bool> m_Bneighbours = new Dictionary<int, bool>();
        public HashSet<Node> m_neighbours = new HashSet<Node>();
        public HashSet<Node> m_cliqueNeighbours = new HashSet<Node>();
        private Dictionary<Node, int> m_cliqueWeight = new Dictionary<Node, int>();
        //public HashSet<Node> m_normalNeighbours = new HashSet<Node>();
        private Node_State nodestate;
        public Node_State M_state
        {
            get
            {
                return nodestate;
            }
        }
        private Graph graph;
        public Node(Graph graph)
        {
            this.graph = graph;
        }
        public int Clique_Index = 0;
        //public Node(Graph graph)
        //{
        //    this.graph = graph;
        //}
        public int TimesMoved = 0;

        public int index;

        //Adds neighbour to set
        public void Set_NewNeighbour(Node n_neighbours)
        {
            //if (m_Bneighbours.ContainsKey(n_neighbours.index))
            //{
            //    if (!m_Bneighbours[n_neighbours.index])
            //    {
            //        m_neighbours.Add(n_neighbours);
            //        m_Bneighbours[n_neighbours.index] = true;
            //    }
            //}
            //else
            //{
            //    m_neighbours.Add(n_neighbours);
            //    m_Bneighbours.Add(n_neighbours.index, true);
            //}
            if (m_neighbours.Add(n_neighbours) && M_state == Node_State.susceptible && n_neighbours.M_state == Node_State.infected)
            {
                graph.susToInfect++;
            }
        }

        public void Set_NewCliqueNeighbour(Node n_neighbour)
        {
            if (M_state == Node_State.susceptible && n_neighbour.M_state == Node_State.infected)
            {
                graph.susToInfect++;
            }
            m_cliqueNeighbours.Add(n_neighbour);
            //m_cliqueWeight.Add(n_neighbour, 1);
        }
        
        public int Get_CliqueWeight(Node c_neighbour)
        {
            if (m_cliqueWeight.ContainsKey(c_neighbour))
            {
                return m_cliqueWeight[c_neighbour];
            }
            else
            {
                return 1;
            }
        }

        //Removes neighbour from set
        public void Set_RemoveNeighbour(Node n_neighbours)
        {
            if (M_state == Node_State.susceptible && n_neighbours.M_state == Node_State.infected)
            {
                graph.susToInfect--;
            }
            m_neighbours.Remove(n_neighbours);
            //m_Bneighbours[n_neighbours.index] = false;
        }
        public void Set_RemoveCliqueNeighbour(Node n_neighbours)
        {
            if (M_state == Node_State.susceptible && n_neighbours.M_state == Node_State.infected)
            {
                graph.susToInfect--;
            }
            m_cliqueNeighbours.Remove(n_neighbours);
            //m_Bneighbours[n_neighbours.index] = false;
        }
        //Clear all neighbours from set
        public void Set_RemoveAllNeighbours()
        {
            m_neighbours.Clear();
            //m_Bneighbours = new Dictionary<int, bool>();
        }
        public void Set_RemoveAllCliqueNeighbours()
        {
            foreach (Node neightbour in m_cliqueNeighbours)
            {
                if (neightbour.M_state == Node_State.infected)
                {
                    graph.susToInfect--;
                }
            }
            m_cliqueNeighbours.Clear();
        }
        public int Get_NeibhourCount()
        {
            return m_neighbours.Count;
        }

        //Checks if neibhour in set
        public bool Get_IsNeighbourWith(Node c_neighbours)
        {
            return m_neighbours.Contains(c_neighbours); //m_Bneighbours[c_neighbours.index];
        }
        private static bool XORSusAndInf(Node node1, Node node2)
        {
            return node1.M_state == Node_State.infected && node2.M_state == Node_State.susceptible || node1.M_state == Node_State.susceptible && node2.M_state == Node_State.infected;
        }
        public void Set_ChangeCliqueEdgeValue(int Change, Node nei)
        {
            if (M_state == Node_State.infected && nei.M_state == Node_State.susceptible)
            {
                graph.susToInfect += Change;
            }
            if (m_cliqueWeight.ContainsKey(nei))
            {
                m_cliqueWeight[nei] += Change;
            }
            else
            {
                m_cliqueWeight.Add(nei, Change + 1);
            }
        }
        //Check state
        public override int GetHashCode()
        {
            return index;
        }
        public void Infect()
        {
            if (M_state != Node_State.infected)
            {
                nodestate = Node_State.infected;
                graph.m_infectedNodes.Add(this);
                foreach (Node neightbour in m_neighbours)
                {
                    switch (neightbour.M_state)
                    {
                        case Node_State.susceptible:
                            graph.susToInfect++;
                            break;
                        case Node_State.infected:
                            graph.susToInfect--;
                            break;
                    }
                }
                if (Get_IsNeighbourWith(this))
                {
                    graph.susToInfect++;
                }
                foreach (Node neightbour in m_cliqueNeighbours)
                {
                    switch (neightbour.M_state)
                    {
                        case Node_State.susceptible:
                            graph.susToInfect += Get_CliqueWeight(neightbour);
                            break;
                        case Node_State.infected:
                            graph.susToInfect -= neightbour.Get_CliqueWeight(this);
                            break;
                    }
                }
            }
            graph.m_cliques[Clique_Index].NodeIsInfected();
        }
        public void Recover()
        {
            if (M_state != Node_State.removed)
            {
                if (M_state == Node_State.infected)
                {
                    graph.m_infectedNodes.Remove(this);
                }
                foreach (Node neightbour in m_neighbours)
                {
                    if (XORSusAndInf(this, neightbour))
                    {
                        graph.susToInfect--;
                    }
                }
                foreach (Node neightbour in m_cliqueNeighbours)
                {
                    if (XORSusAndInf(this, neightbour))
                    {
                        graph.susToInfect--;
                    }
                }
                nodestate = Node_State.removed;
                graph.m_recoveredNodes.Add(this);
                graph.m_cliques[Clique_Index].NodeIsRecovered();
            }
        }
    }
}