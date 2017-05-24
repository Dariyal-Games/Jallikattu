using UnityEngine;
using System.Collections;
using System;
namespace Dariyal.StatSystem
{
    public abstract class StatLinker : IStatValueChange
    {
        private Stat _stat;

        public StatLinker(Stat stat)
        {
            _stat = stat;

            IStatValueChange iValueChange = _stat as IStatValueChange;
            if (iValueChange != null)
            {
                iValueChange.OnValueChange += OnLinkedStatValueChange;
            }
        }

        public Stat Stat
        {
            get { return _stat; }
        }

        public abstract int Value { get; }

        public event EventHandler OnValueChange;

        private void OnLinkedStatValueChange(object sender, EventArgs args)
        {
            if (OnValueChange != null)
            {
                OnValueChange(this, args);
            }
        }
    }
}