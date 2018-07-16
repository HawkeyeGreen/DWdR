using System;
using System.Collections.Generic;
using DWDR_SL_Client.Organization;
using System.IO;

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


    //public class Effect
    //{
    //    #region public check values
    //    public bool permanentlyHidden = true;
    //    public bool permanentEffect = false;
    //    public bool purgeable = true;
    //    #endregion

    //    ConditionChecker checking = new ConditionChecker();
    //    List<Modifier> modifiers = new List<Modifier>();

    //    public string myName = "dummyEffect";
    //    public bool active = true;

    //    int timeIAmActive = 0;
    //    int roundIStarted = 0;
    //    int lastRoundIWasChecked = 0;

    //    List<string> targetedValues = new List<string>();


    //    /****** Konstruktor *********
    //     * Mit dieser Funktion werden alle den Effekt betreffenden
    //     * Werte initialisiert, so dass der Effekt effektiv genutzt 
    //     * werden kann.
    //     * 
    //     * D.h. folgende Attribute müssen aufgesetzt werden:
    //     * checker
    //     * modifiers
    //     * myName
    //     * active
    //     * roundIStarted
    //     * targetedValues
    //     */
    //    public void initialize()
    //    {

    //    }

    //    /******** Speichern ******
    //     * Diese Funktion soll den Effekt und alle zu ihm gehörenden Inhalte
    //     * im angegebenen Pfad speichern. Der Pfad zeigt dabei auf das Wurzelverzeichnis für den
    //     * Effekt.
    //     * 
    //     * Diese Funktion ruft auch die passenden Funktionen für die Modifier und
    //     * den ConditionChecker auf.
    //     */
    //    public void save(string path)
    //    {

    //    }

    //    /********** Laden ********
    //     * Diese Funktion setzt den Effekt mit den Dateien aus
    //     * dem angegebenen Pfad auf. Dabei ruft diese Funktion auch
    //     * die passenden Funktionen für alle Modifier und den Checker auf.
    //     */
    //    public void load(string path)
    //    {

    //    }


    //    public ModifierEnvelope update()
    //    {
    //        ModifierEnvelope returnMe = new ModifierEnvelope();
    //        if(lastRoundIWasChecked < Round.currentRound)
    //        {
    //            timeIAmActive = Round.currentRound - roundIStarted;
    //            returnMe.roundsGone = timeIAmActive;
    //            lastRoundIWasChecked = Round.currentRound;
    //        }


    //        if(checking.amITrue())
    //        {
    //            foreach(Modifier mod in modifiers) { returnMe.Collect(mod); }
    //        }
    //        else
    //        {
    //            returnMe.amINeutral = true;
    //        }

    //        return returnMe;
    //    }
    //}

    ///*  Ein Modifier enthält seinen Typ, sein Zielwert und die Stärke der Modifikation.
    // *  Liste der ModifyTypen
    // *  1. Additiv I            'Basic Additiv'
    // *  2. Multiplikativ I      'Inner Multiplikator'
    // *  3. Additiv II           'Strong Additiv'
    // *  4. Multiplikativ II     'Strong Mulitplikator'
    // *  5. Additiv III          'TotalAdditiv'
    // *  
    // *  Weiterhin wichtig ist der Modus:
    // *  - Counting
    // *  - Static
    // */
    //public class Modifier
    //{
    //    public string mode = "Static";
    //    public string type = "Additiv I";
    //    public string targetedValue = "productionYield";
    //    public double value = 0;

    //    public double conglomerateModifier(int roundsGone)
    //    {
    //        if (mode == "Counting")
    //        {
    //            if (type.Contains("Multiplikativ"))
    //            {
    //                double Zinsfuß = value * 100 - 100;
    //                double Basis = 1 + Zinsfuß / 100;
    //                double potence = Convert.ToDouble(roundsGone);
    //                return Math.Pow(Basis, potence); // Rückgabe, wenn Multiplikativ
    //            }
    //            return roundsGone * value; // Rückgabe, wenn additiv
    //        }
    //        return value; // Rückgabe, wenn statisch bzw. nicht Counting
    //    }
    //}

    ///*  ConditionChecker
    // *  Diese Klasse wird beim Initialisieren des Effect
    // *  mit allen Informationen und Verknüpfungen versorgt, die er benötigt,
    // *  um zu überprüfen, ob seine Bedingungen aktuell sind.
    // */
    //class ConditionChecker
    //{
    //    #region target-validation
    //    List<string> tags = new List<string>();
    //    List<string> validTargetTypes = new List<string>();
    //    List<string> penetratedResistances = new List<string>();
    //    List<int> piercingStrengths = new List<int>();
    //    #endregion


    //    Spaceobject myHost;
    //    ConditionContainer condition = new ConditionContainer();

    //    public void setMeUp()
    //    {

    //    }

    //    public bool amITrue()
    //    {
    //        bool ReturnMe = true;
    //        ReturnMe = true & condition.checkMe(myHost) & targetTypeValidation() & resistancePiercingConfirmation();
    //        return ReturnMe;
    //    }

    //    public bool targetTypeValidation()
    //    {
    //        return validTargetTypes.Contains(myHost.getType());
    //    }

    //    public bool resistancePiercingConfirmation()
    //    {
    //        bool returnMe = true;
    //        if(myHost.getType() == "planet")
    //        {
    //            Planet tmp = new Universum.Planet();
    //            tmp.loadMe(myHost.getPath());
    //            returnMe = tmp.effectManagement.canPierceMe(piercingStrengths, penetratedResistances);
    //        }

    //        return returnMe;
    //    }

    //    public void saveMe(string effectPath)
    //    {

    //    }

    //    public ConditionChecker loadMe(string effectPath)
    //    {
    //        StreamReader reader = new StreamReader(File.OpenRead(effectPath + "condition.cond"));

    //        reader.Close();

    //        return this;
    //    }
    //}
}
