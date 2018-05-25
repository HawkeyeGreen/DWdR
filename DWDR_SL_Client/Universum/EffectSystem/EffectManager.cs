using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWDR_SL_Client.Universum.EffectSystem
{
    /******* Klassenübersicht ***********
     * Ein System, dass Effekte benutzen möchte,
     * nutzt einen EffektManager zur Verwaltung von
     * Effekten, die es selbst betreffen, als auch Effekte, 
     * die es selbst verursacht.
     * 
     * Wichtige Schnittstellen-Informationen:
     * deployEffects(): 
     * Gibt auf Anfrage alle Effekte, die den Anfrager betreffen könnten,
     * aus. Die Ausgabe erfolgt als eine Liste mit EffectDeployKits, die der
     * EffectManager des Anfragers zu Effekten entpackt.
     * getMyEffectsEnvelope():
     * Gibt alle Effekte, die den übergebenen Wert des Host-Systems betreffen,
     * verrechnet heraus d.h. einen EffectEnevolpe, der vollständig mit validen Effekten befüllt wurde.
     * 
     * getMyEffectsList():
     * Gibt eine Liste mit Effekten zurück, die den Host gerade betreffen (für Übersichtszwecke)
     */

    public class EffectManager
    {
        private bool resistances = false;
        private ResistanceSet resistanceSet;
        private List<Effect> effects;

        public EffectManager()
        {
            resistanceSet = new EffectSystem.ResistanceSet();
            effects = new List<EffectSystem.Effect>();
        }
        

        public bool canPierceMe(List<int> percingStrengths, List<string> piercingBoard)
        {
            if(resistances == true)
            {
                return resistanceSet.piercing(percingStrengths, piercingBoard);
            }
            return true;
        }

        public void addEffectManual(Effect effect)
        {
            effects.Add(effect);
        }

        public void addEffectByDeployKit(EffectDeployKit deployKit)
        {

        }

        public void addEffectsByDeployKitSet(List<EffectDeployKit> deployKitSet)
        {

        }
    }

    public class ResistanceSet
    {
        List<int> resistanceTable = new List<int>();
        List<string> resistanceBoard = new List<string>();

        public bool piercing(List<int> percingStrengths, List<string> piercingBoard)
        {
            bool gotPierced = false;

            for(int i = 0; i< percingStrengths.Count; i++)
            {
                if(resistanceTable[i] < percingStrengths[i])
                {
                    gotPierced = true;
                }
            }

            for(int i = 0; i < piercingBoard.Count; i++)
            {
                if(resistanceBoard.Contains(piercingBoard[i]))
                {
                    gotPierced = true;
                }
            }

            return gotPierced;
        }
    }
}
