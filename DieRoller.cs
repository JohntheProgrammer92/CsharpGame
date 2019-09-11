using System;
using System.Collections.Generic;
using System.Text;

namespace DieRoller_F2019
{
    class DieRoller
    {
        public static int Roll()
        {
            return StaticRandom.Instance.Next(1, 7);
        }
        public static int Roll(int times)
        {
            int total = 0;
            while (times > 0)
            {
                total += StaticRandom.Instance.Next(1, 7);
                times--;
            }
            return total;
        }
        public static int Roll(int times, int sides)
        {
            int total = 0;
            while (times > 0)
            {
                total += StaticRandom.Instance.Next(1, sides + 1);
                times--;
            }
            return total;
        }
        public static int Roll(int times, int sides, int target)
        {
            int pass = 0;
            while (times > 0)
            {
                int roll = StaticRandom.Instance.Next(1, sides + 1);
                if (roll >= target)
                {
                    pass++;
                }
                times--;
            }
            return pass;
        }
    }
}
