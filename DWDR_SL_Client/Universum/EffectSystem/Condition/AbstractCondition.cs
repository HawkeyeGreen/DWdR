using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWDR_SL_Client.Universum.EffectSystem.Condition
{

    /**** Abstrakte Klasse: AbstractCondition
     *  
     */

    /// <summary>
    /// AbstractCondition bildet den universellen Vertrag für alle Conditions.
    /// Eine AbstractCondition kann also alle anderen Conditions enthalten.
    /// </summary>

    abstract class AbstractCondition
    {
        private bool inverted = false;
        private string type;

        public string Type { get => type; set => type = value; }
        public bool Inversion { get => inverted; set => inverted = value; }

        public AbstractCondition(string type, bool inverted)
        {
            this.type = type;
            this.inverted = inverted;
        }

        /// <summary>
        /// Checks if the condition is met or not. The concrete implementation for
        /// the check´is handled in the concrete Conditions.
        /// </summary>
        /// <returns>was the condition met? true if yes, false if not</returns>
        abstract public bool isMet();


        /// <summary>
        /// Uses the parameters to check 
        /// if the new target can be evaluated by
        /// this condition. If not the old target remains.
        /// </summary>
        /// <param name="ID">The ID of the new target.</param>
        /// <param name="type">The mapped Type.</param>
        abstract public void setTarget(long ID, string type);
    }
}
