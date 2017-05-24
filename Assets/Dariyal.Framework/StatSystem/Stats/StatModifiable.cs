using System;
using System.Collections.Generic;
using System.Linq;

namespace Dariyal.Framework.StatSystem
{
    public class ModifiableStat : Stat, IModifiableStat, IStatValueChange
    {
        private List<StatModifier> _statModifiers;
        private float _statModifiedValue;

        public event EventHandler OnValueChange;

        public override float StatValue
        {
            get { return base.StatValue + StatModifierValue; }
        }

        public float StatModifierValue
        {
            get { return _statModifiedValue; }
        }

        public ModifiableStat()
        {
            _statModifiedValue = 0;
            _statModifiers = new List<StatModifier>();
        }

        public void AddModifier(StatModifier modifier)
        {
            _statModifiers.Add(modifier);
            modifier.OnValueChange += OnModifierValueChange;
        }

        public void RemoveModifier(StatModifier modifier)
        {
            _statModifiers.Remove(modifier);
            modifier.OnValueChange -= OnModifierValueChange;
        }

        public void ClearModifiers()
        {
            _statModifiers.Clear();
        }

        public void UpdateModifiers()
        {
            _statModifiedValue = 0;

            var orderGroups = _statModifiers.OrderBy(m => m.Order).GroupBy(m => m.Order);
            foreach (var group in orderGroups)
            {
                float sum = 0, max = 0;
                foreach (var mod in group)
                {
                    if (mod.Stacks == false)
                    {
                        if (mod.Value > max)
                        {
                            max = mod.Value;
                        }
                    }
                    else
                    {
                        sum += mod.Value;
                    }
                }
                _statModifiedValue += group.First().ApplyModifier(BaseValue + _statModifiedValue, sum > max ? sum : max);
            }

            TriggerValueChange();
        }

        protected void TriggerValueChange()
        {
            if (OnValueChange != null)
            {
                OnValueChange(this, null);
            }
        }
        public void OnModifierValueChange(object modifier, EventArgs args)
        {
            UpdateModifiers();
        }
    }
}