using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DWDR_SL_Client.Organization;

namespace DWDR_SL_Client.Universum.Ressources
{
    class Deposit : MappedObject
    {
        Ressource ressource;
        private int amount = 100;
        private int startingAmount;

        public int Amount { get => amount; set => amount = value; }
        public Ressource BoundRessoure { get => ressource; }

        public Deposit(Ressource ressource) : base("RessourceDeposit")
        {
            startingAmount = amount;
            this.ressource = ressource;
        }
    }
}
