using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ld3
{
    class Array : DataArray
    {
        static Random random = new Random();
        double[] data;
        public Array(int n, int seed)
        {
            data = new double[n];
            length = n;
            Random rand = new Random(seed);
            for (int i = 0; i < length; i++)
                data[i] = random.NextDouble();
        }
        public override double this[int index]
        {
            get { return data[index]; }
        }
        public override void Swap(int j, double a, double b)
        {
            data[j - 1] = a;
            data[j] = b;
        }
        //static string RandomName(int size)
        //{
        //    StringBuilder builder = new StringBuilder();
        //    char ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
        //    builder.Append(ch);
        //    for (int i = 1; i < size; i++)
        //    {
        //        ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble())));
        //        builder.Append(ch);
        //    }
        //    return builder.ToString();
        //}
    }
}
