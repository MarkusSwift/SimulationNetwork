using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_Lib
{
    public static class Statistics
    {
        [ThreadStatic]
        static Random rand = new Random(); //reuse this if you are generating many
        //
        public static float Get_NormalDistribution(float StandardDeviation, float Mean)
        {
            UpdateIfNecessary();
            double u1 = 1.0 - rand.NextDouble(); //uniform(0,1] random doubles
            double u2 = 1.0 - rand.NextDouble();
            double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2); //random normal(0,1)
            double randNormal = Mean + StandardDeviation * randStdNormal;
            return (float)randNormal;
        }


        //exp
        public static float Get_ExponentialDistribution(float lambda)
        {
            UpdateIfNecessary();
            double u1 = 1.0 - rand.NextDouble(); //uniform(0,1] random doubles

            double value = Math.Log(1f - u1) / (-lambda);
            return (float)value;
        }

        public static float GetUniformal()
        {
            UpdateIfNecessary();
            return (float)rand.NextDouble();
        }

        public static int Get_Integer(int min_inclusive, int max_exclusive)
        {
            UpdateIfNecessary();
            return rand.Next(min_inclusive, max_exclusive);
        }
        private static void UpdateIfNecessary()
        {
            if (rand == null)
            {
                rand = new Random((int)DateTime.Now.Ticks ^ System.Threading.Thread.CurrentThread.ManagedThreadId);
            }
        }
    }
}