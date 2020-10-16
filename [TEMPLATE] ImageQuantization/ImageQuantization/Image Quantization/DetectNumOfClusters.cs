using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace ImageQuantization
{
    /// <summary>
    /// Detect Number Of Clausters by standerd deviation AND MEAN 
    /// WE GET DEFEERNCE BETWEEN TWO Consecutive standard deviation until becames < 0.0001
    /// </summary>
    class DetectNumOfClusters
    {

        /// <summary>
        /// Data Needed to calculate NofClusters like last Sd and the current SD and Edge to remove and 
        /// the list of weights to work on
        /// </summary>
        public int k = 0;    // O(1)
        private List<Edge> edges; //O(1)
        double lastSD = 0;   //O(1)
        double currentSD = 0;   //O(1)
        Edge RemovedEdge = new Edge();//O(1)
        /// <summary>
        ///  Control procedure that manages process sequence by determinig when to stop and have number of clusters 
        /// </summary>
        /// <param name="edges"></param>
        public DetectNumOfClusters(List<Edge> edges) //O(E*E)
        {
            this.edges = edges; //O(1)
            k = 0; //O(1) 
            do
            {
                lastSD = currentSD; //O(1)
                calculateStandardDeviation(); //O(E)
                edges.Remove(RemovedEdge); //O(E)
                k++; //O(1)
            } while (Math.Abs(currentSD - lastSD) > 0.0001); //O(E*E)
            k--;//O(1)
        }
        /// <summary>
        /// Caluclate The Mean of Weights that helps in calculate deviation to remove edge
        /// </summary>
        /// <returns> Mean Value</returns>
        double calculateMean() //O(E)
        {
            double sum = 0; //O(1)
            foreach (Edge edge in edges)//O(E*1) -> O(E)
                sum += edge.weight; //O(1)
            return sum / edges.Count(); //O(1)
        }
        /// <summary>
        ///  CalCulate SD For Edges and Determin Witch edge with Max distance To remove later
        /// </summary>
        /// <returns>deviation Value</returns>
        double calculateStandardDeviation()//O(E)
        {
            double mean = calculateMean(); //O(E)
            double MaxValue = 0; //O(1)
         
            double sum = 0;  //O(1)
            foreach (Edge edge in edges) //O(E *1) -> O(E)
            {
                double term = (edge.weight - mean) * (edge.weight - mean); //O(1)
                if (term > MaxValue) // O(1)
                {
                    MaxValue = term; // O(1)
                    RemovedEdge = edge; // O(1)
                }
                sum += term;  //O(1)
            }
            currentSD = sum / (edges.Count() - 1); //O(E)
            currentSD = Math.Sqrt(currentSD);    //O(1) 
            return currentSD; //O(1)
        }
    }
}
