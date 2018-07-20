using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWDR_SL_Client.Organization
{
    public class Round
    {
        public static int currentRound = 0;     // Aktuelle Runde
        public static short currentPhase = 1;   // Teil-Phase der Runde -> 
        public static short currentStep = 1;


        public static int currentInterstellarYear = 10201;
        public static short currentInterstellarMonthMax = 1;
        public static short currentInterstellarMonthMin = 1;
        public static short monthPerYear = 12;
        public static short daysPerMonth = 40;
        public static short daysperYear = 480;

        public static bool nextPhase()
        {
            if(currentPhase < 4)
            {
                currentPhase++;
                if(currentPhase  == 1) // 1. Quartal
                {
                    currentInterstellarMonthMin = 1;
                    currentInterstellarMonthMax = 3;
                }
                else if (currentPhase == 2) // 2. Quartal
                {
                    currentInterstellarMonthMin = 4;
                    currentInterstellarMonthMax = 6;
                }
                else if (currentPhase == 3) // 3. Quartal
                {
                    currentInterstellarMonthMin = 7;
                    currentInterstellarMonthMax = 9;
                }
                else // 4.Quartal
                {
                    currentInterstellarMonthMin = 10;
                    currentInterstellarMonthMax = 12;
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void nextStep()
        {
            currentStep++;
        }

        public static int openNewRound()
        {
            currentPhase = 1;
            currentInterstellarMonthMin = 1;
            currentInterstellarMonthMax = 3;
            currentStep = 1;
            currentRound++;
            currentInterstellarYear++;
            return currentRound;
        }

        public static void read()
        {

        }

        public static void save()
        {

        }

    }
}
