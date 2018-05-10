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
     * aus.
     * getMyEffectsEnvelope():
     * Gibt alle Effekte, die den übergebenen Wert des Host-Systems betreffen,
     * verrechnet heraus d.h. einen EffectEnevolpe, der vollständig mit validen Effekten befüllt wurde.
     * 
     * getMyEffectsList():
     * Gibt eine Liste mit Effekten zurück, die den Host gerade betreffen (für Übersichtszwecke)
     */

    public class EffectManager
    {

    }
}
