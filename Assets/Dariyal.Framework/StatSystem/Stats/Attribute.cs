using System;
using System.Collections.Generic;

namespace Dariyal.Framework.StatSystem
{
    public class Attribute : ModifiableStat, IStatScalable, IStatLinkable
    {
        private int _statLevelValue;
        private float _statLinkerValue;
        private List<StatLinker> _statLinkers;

        public int StatLevelValue
        {
            get { return _statLevelValue; }
        }

        public override float BaseValue
        {
            get { return base.BaseValue + StatLevelValue + StatLinkerValue; }
        }

        public float StatLinkerValue
        {
            get
            {
                UpdateLinkers();
                return _statLinkerValue;
            }
        }

        public void AddLinker(StatLinker linker)
        {
            _statLinkers.Add(linker);
            linker.OnValueChange += OnLinkerValueChange;
        }

        public void RemoveLinker(StatLinker linker)
        {
            _statLinkers.Remove(linker);
            linker.OnValueChange -= OnLinkerValueChange;
        }

        public void ClearLinkers()
        {
            foreach (var linker in _statLinkers)
            {
                linker.OnValueChange -= OnLinkerValueChange;
            }

            _statLinkers.Clear();
        }

        public virtual void ScaleStat(int level)
        {
            _statLevelValue = level;
            TriggerValueChange();
        }

        public void UpdateLinkers()
        {
            _statLinkerValue = 0;
            foreach (var link in _statLinkers)
            {
                _statLinkerValue += link.Value;
            }

            TriggerValueChange();
        }

        public Attribute()
        {
            _statLinkers = new List<StatLinker>();
        }

        private void OnLinkerValueChange(object sender, EventArgs args)
        {
            UpdateLinkers();
        }
    }
}