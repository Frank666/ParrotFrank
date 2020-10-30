using System;
using System.Collections.Generic;
using System.Text;

namespace ParrotFrankHelpers
{
    public class Utilities
    {
        public double SessionTime(DateTime init, DateTime end)
        {
            TimeSpan ts = end - init;
            return Math.Round(ts.TotalMinutes);
        }

        public string CategoryImage(int categoryId)
        {
            switch (categoryId)
            {
                case 1:
                    return "Beer";
                case 2:
                    return "Food";
                default:
                    return "Desserts";
            }            
        }
         
    }
}
