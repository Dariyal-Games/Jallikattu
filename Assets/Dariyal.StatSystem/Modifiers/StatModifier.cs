using System;

namespace Dariyal.StatSystem
{
    public abstract class StatModifier
    {
        private float _value = 0f;

        public event EventHandler OnValueChange;

        public abstract int Order { get; }

        public float Value
        {
            get
            {
                return _value;
            }
            set
            {
                if (_value != value)
                {
                    _value = value;
                    if (OnValueChange != null)
                    {
                        OnValueChange(this, null);
                    }
                }
            }
        }

        public bool Stacks { get; set; }

        public StatModifier()
        {
            Value = 0;
            Stacks = true;
        }

        public StatModifier(float value)
        {
            Value = value;
            Stacks = true;
        }

        public StatModifier(float value, bool stacks)
        {
            Value = value;
            Stacks = stacks;
        }

        public abstract float ApplyModifier(float statValue, float modValue);
    }
}