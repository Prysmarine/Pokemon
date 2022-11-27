using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pokemon
{
    //For calculating Pokemon Stats
    //Probably needs to be renamed to something like statCalc
    internal class Nature
    {
        static double[] Stats = new double[] { 1, 1, 1, 1, 1, 1, 1, 1, 50};
        static double[] IV = new double[] { 0, 0, 0, 0, 0, 0};
        static double[] EV = new double[] { 0, 0, 0, 0, 0, 0};
        static int[] Final = new int[] { 0, 0, 0, 0, 0, 0 };

        public static void statIn(
            double hp, double atk, double def, double satk, 
            double sdef, double speed, double naturep, double naturem, double lvl,
            double ivhp, double ivatk, double ivdef, double ivsatk, double ivsdef, double ivspeed,
            double evhp, double evatk, double evdef, double evsatk, double evsdef, double evspeed)
        {
            Stats[0] = hp;
            Stats[1] = atk;
            Stats[2] = def;
            Stats[3] = satk;
            Stats[4] = sdef;
            Stats[5] = speed;
            Stats[6] = naturep;
            Stats[7] = naturem;
            Stats[8] = lvl;


            IV[0] = ivhp;
            IV[1] = ivatk;
            IV[2] = ivdef;
            IV[3] = ivsatk;
            IV[4] = ivsdef;
            IV[5] = ivspeed;

            EV[0] = evhp;
            EV[1] = evatk;
            EV[2] = evdef;
            EV[3] = evsatk;
            EV[4] = evsdef;
            EV[5] = evspeed;
            statCalc();
        }

        public static void statCalc()
        {
            Final[0] = Convert.ToInt32(Math.Floor(((((2 * Stats[0]) + IV[0] + (EV[0] / 4)) * Stats[8]) / 100)) + Stats[8] + 10);

            for (int i = 1; i < 6; i++)
            {
                if (i == Stats[6])
                {
                    Final[i] = Convert.ToInt32(Math.Floor((Math.Floor(((2 * Stats[i]) + IV[i] + (EV[i] / 4)) * Stats[8] / 100) + 5) * 1.1));
                }
                else if (i == Stats[7])
                {
                    Final[i] = Convert.ToInt32(Math.Floor((Math.Floor(((2 * Stats[i]) + IV[i] + (EV[i] / 4)) * Stats[8] / 100) + 5) * 0.9));
                }
                else
                    Final[i] = Convert.ToInt32(Math.Floor((Math.Floor(((2 * Stats[i]) + IV[i] + (EV[i] / 4)) * Stats[8] / 100) + 5)));
            }
        }
        
        public static string output(int i)
        {
            return _ = Final[i].ToString();
        }
    }
}
