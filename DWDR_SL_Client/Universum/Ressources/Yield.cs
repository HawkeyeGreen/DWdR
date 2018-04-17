using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DWDR_SL_Client.Universum.Ressources
{
    /*  Klasse AbstractYieldSet
     *  Enthält die BasisErträge von Produktion, Kultur, Sience etc.
     *  Und kann mit einem CollectorProfile alles zusammensammeln um einen
     *  effektiven Ertrag zu berechnen.
     *  
     *  Wichtige Funktionen:
     *  GetEffectiveYield(CollectorProfile myCollector)
     */
    public class AbstractYieldSet
    {
        List<AbstractYield> baseYield = new List<AbstractYield>();

        // Die Funktion überprüft zuerst via 'containsYield', ob bereits ein passender Eintrag vorhanden ist.
        // Ist das der Fall wird der entsprechende Eintrag erweitert. Ansonsten wird er angelegt.
        // Wird ein neuer gemacht, dann gibt die Funktion 'true' zurück.
        // Ansonsten false.

        public bool Insertion(string name, double value,string yieldGroup = "top", bool uneffected = false)
        {

            if(containsYield(name, uneffected))
            {
                getYieldEntry(name, uneffected).value += value;
                return false;
            }
            else
            {
                AbstractYield tmp = new AbstractYield();
                tmp.name = name;
                tmp.yieldGroup = yieldGroup;
                tmp.value = value;
                tmp.uneffected = uneffected;
                baseYield.Add(tmp);
                return true;
            }
        }

        //  Diese Funktion überprüft, ob sich in der Yield-Liste bereits ein Eintrag
        //  desselben Yields befindet UND ob der Uneffected-Wert übereinstimmen.
        //  Der Uneffected-Wert muss gleich sein, damit der Yield entweder von Effekten
        //  betroffen wird oder nicht.
        public bool containsYield(string name, bool uneffected = false)
        {
            for(int i = 0; i < baseYield.Count; i++)
            {
                if (baseYield[i].name == name && baseYield[i].uneffected == uneffected) { return true; }
            }
            return false;
        }

        AbstractYield getYieldEntry(string name, bool uneffected = false)
        {
            for (int i = 0; i < baseYield.Count; i++)
            {
                if (baseYield[i].name == name && baseYield[i].uneffected == uneffected) { return baseYield[i]; }
            }
            return new AbstractYield();
        }
    }

    class AbstractYield
    {
        public string name = "Produktion";
        public string yieldGroup = "top";
        public double value = 1.0;
        public bool uneffected = false;
    }
}
