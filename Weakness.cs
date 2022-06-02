using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon
{

    class Weakness
    {
        /*
            [0]   Bug
            [1]   Dark
            [2]   Dragon
            [3]   Electric
            [4]   Fairy
            [5]   Fighting
            [6]   Fire
            [7]   Flying
            [8]   Ghost
            [9]   Grass
            [10]  Ground
            [11]  Ice
            [12]  Normal
            [13]  Poison
            [14]  Psychic
            [15]  Rock
            [16]  Steel
            [17]  Water
        */

        static double[] TypeMulti = new double[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };

        //For Setting the Damage Multipliers
        public static void WeakCalc(double bug, double dark, double dragon, double electric, double fairy, double fighting, double fire, double flying, double ghost, double grass, double ground, double ice, double normal, double poison, double psychic, double rock, double steel, double water)
        {
            TypeMulti[0] *= bug;
            TypeMulti[1] *= dark;
            TypeMulti[2] *= dragon;
            TypeMulti[3] *= electric;
            TypeMulti[4] *= fairy;
            TypeMulti[5] *= fighting;
            TypeMulti[6] *= fire;
            TypeMulti[7] *= flying;
            TypeMulti[8] *= ghost;
            TypeMulti[9] *= grass;
            TypeMulti[10] *= ground;
            TypeMulti[11] *= ice;
            TypeMulti[12] *= normal;
            TypeMulti[13] *= poison;
            TypeMulti[14] *= psychic;
            TypeMulti[15] *= rock;
            TypeMulti[16] *= steel;
            TypeMulti[17] *= water;
        }

        //For Outputting the Damage Numbers
        public static string output(int i)
        {
            return _ = "x" + TypeMulti[i].ToString();
        }

        //Resets Array Back to 1 When Changing Types
        public static void Reset()
        {
            for (int i = 0; i < 18; i++)
            {
                TypeMulti[i] = 1;
            }
        }
    }
    //End of Class    
}
//End of Namespace