using System;
using UnityEngine;

namespace Dariyal.StatSystem
{
    public class Vital : Attribute, IStatCurrentValueChange
    {
        private float _statCurrentValue;

        public event EventHandler OnCurrentValueChange;

        public float StatCurrentValue
        {
            get
            {
                if (_statCurrentValue > StatValue)
                {
                    _statCurrentValue = StatValue;
                }
                else if (_statCurrentValue < 0)
                {
                    _statCurrentValue = 0;
                }
                return _statCurrentValue;
            }
            set
            {
                if (_statCurrentValue != value)
                {
                    _statCurrentValue = value;
                    TriggerCurrentValueChange();
                }
            }
        }

        public Vital()
        {
            _statCurrentValue = 0;
        }

        public void SetValueCurrentToMax()
        {
            StatCurrentValue = StatValue;
        }

        private void TriggerCurrentValueChange()
        {
            if (OnCurrentValueChange != null)
            {
                OnCurrentValueChange(this, null);
            }
        }
    }
}