using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DWDR_SL_Client.Universum.EffectSystem
{
    class EffectManager
    {
        IEffectable master;

        private List<Effects.AbstractEffect> ownedEffects;
        private List<Effects.AbstractEffect> affectedEffects;     

        public EffectManager(IEffectable master)
        {
            ownedEffects = new List<Effects.AbstractEffect>();
            affectedEffects = new List<Effects.AbstractEffect>();            
            this.master = master;
        }

        public double getModifiedValue(string key, double baseValue)
        {
            List<List<Modifiers.AbstractModifier>> affectingModifiers = new List<List<Modifiers.AbstractModifier>>();

            foreach(Effects.AbstractEffect effect in affectedEffects)
            {
                if(effect.AffectedKeys.Contains(key))
                {
                    effect.addModifiers(key, affectingModifiers);
                }
            }

            double final = baseValue;
            double mod = 0;

            // Wende Base-Mods an
            foreach(Modifiers.AbstractModifier modifier in affectingModifiers[0])
            {
                mod += modifier.useModifier(baseValue);
            }

            final += mod;
            mod = 0;

            // Wende InnerMods an
            foreach (Modifiers.AbstractModifier modifier in affectingModifiers[1])
            {
                mod += modifier.useModifier(baseValue);
            }

            final += mod;
            mod = 0;

            // Wende OuterMods an
            foreach (Modifiers.AbstractModifier modifier in affectingModifiers[2])
            {
                mod += modifier.useModifier(baseValue);
            }

            final += mod;

            return final;
        }

        public void addDeployer(Effects.AbstractEffect deployer)
        {

        }

        public void updateEffects()
        {
            

            affectDownward();
            affectParent();
            affectSpecialTarget();

        }

        private void affectDownward()
        {

        }

        private void affectSpecialTarget()
        {

        }

        private void affectParent()
        {

        }

        private void updateMyEffects()
        {
            List<Effects.AbstractEffect> markedToRemove = new List<Effects.AbstractEffect>();
            foreach(Effects.AbstractEffect effect in affectedEffects)
            {
                if(!effect.update())
                {
                    markedToRemove.Add(effect);
                }
            }
            foreach(Effects.AbstractEffect effect in markedToRemove) { affectedEffects.Remove(effect); }

        }

        public void applyEffect(Effects.AbstractEffect effect)
        {
            if(effect.isAValidTarget(master))
            {
                if(containsEffect(effect.ID))
                {
                    if(effect.Stackable && !effect.Refreshable)
                    {
                        affectedEffects.Add(effect);
                    }
                    else if(effect.Stackable && effect.Refreshable)
                    {
                        removeEffectByID(effect.ID);
                        affectedEffects.Add(effect);
                        affectedEffects.Add(effect);
                    }
                }
                else
                {
                    affectedEffects.Add(effect);
                }
            }
        }

        private bool containsEffect(long ID)
        {
            foreach(Effects.AbstractEffect effect in affectedEffects)
            {
                if(effect.ID == ID)
                {
                    return true;
                }
            }

            return false;
        }

        private void removeEffectByID(long ID) => removeEffectRecursive(ID, 0);

        private bool removeEffectRecursive(long ID, int index)
        {
            if(index >= affectedEffects.Count)
            {
                return false;
            }
            else
            {
                if(affectedEffects[index].ID == ID)
                {
                    affectedEffects.RemoveAt(index);
                    return true;
                }
                else
                {
                    return removeEffectRecursive(ID, index++);
                }
            }
        }

        public void save(string basePath)
        {

        }

        public void load(string basePath)
        {

        }
    }
}
