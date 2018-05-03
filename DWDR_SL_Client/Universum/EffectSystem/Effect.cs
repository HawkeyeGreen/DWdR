using System;
using System.Collections.Generic;
using DWDR_SL_Client.Organization;

namespace DWDR_SL_Client.Universum.EffectSystem
{

    /*  Klasse Effect
     *  Ein Effekt ist die kleinste Einheit des Effektsystems.
     *  In einem Effekt sind die maßgeblichen Informationen,
     *  die das betroffene System benötigt, um seine Werte
     *  entsprechend zu modifizieren.
     *  Ein Effekt zählt stets mit wie lange er schon aktiv ist,
     *  um es den Modifiern mitzuteilen.
     *  
     *  Ein Effekt enthält einen ConditionChecker, der alles
     *  enthält, um die Laufbedingung für den Effekt zu testen.
     *  
     *  Ein Effekt enthält eine Menge von Modifiers,
     *  die Modifiers enthalten Informationen über die den zu verändernden Wert,
     *  die Art der Veränderung und die Höhe der Veränderung.
     */


    public class Effect
    {
        #region public check values
        public bool permanentlyHidden = true;
        public bool permanentEffect = false;
        public bool purgeable = true;
        #endregion

        ConditionChecker checking = new ConditionChecker();
        List<Modifier> modifiers = new List<Modifier>();

        #region target-validation
        List<string> tags = new List<string>();
        List<string> targetedValues = new List<string>();
        List<string> validTargetTypes = new List<string>();
        List<string> penetratedResistances = new List<string>();
        #endregion

        public string myName = "dummyEffect";
        int timeIAmActive = 0;
    }

    /*  Ein Modifier enthält seinen Typ, sein Zielwert und die Stärke der Modifikation.
     *  Liste der ModifyTypen
     *  1. Additiv I            'Basic Additiv'
     *  2. Multiplikativ I      'Inner Multiplikator'
     *  3. Additiv II           'Strong Additiv'
     *  4. Multiplikativ II     'Strong Mulitplikator'
     *  5. Additiv III          'TotalAdditiv'
     *  
     *  Weiterhin wichtig ist der Modus:
     *  - Counting
     *  - Static
     */
    public class Modifier
    {
        public string mode = "Static";
        public string type = "Additiv I";
        public string targetedValue = "productionYield";
        public double value = 0;

        public double conglomerateModifier(int roundsGone)
        {
            if (mode == "Counting")
            {
                if (type.Contains("Multiplikativ"))
                {
                    double Zinsfuß = value * 100 - 100;
                    double Basis = 1 + Zinsfuß / 100;
                    double potence = Convert.ToDouble(roundsGone);
                    return Math.Pow(Basis, potence);
                }
                return roundsGone * value;
            }
            return value;
        }
    }

    /*  ConditionChecker
     *  Diese Klasse wird beim Initialisieren des Effect
     *  mit allen Informationen und Verknüpfungen versorgt, die er benötigt,
     *  um zu überprüfen, ob seine Bedingungen aktuell sind.
     */
    class ConditionChecker
    {

        ConditionContainer condition = new ConditionContainer();

        public bool amITrue()
        {
            return true;
        }

        public void saveMe(string effectPath)
        {

        }
    }
}
