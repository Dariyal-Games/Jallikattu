using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dariyal.StatSystem
{
    public class Stat
    {
        private string _name;
        private float _baseValue;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public virtual float StatValue
        {
            get { return BaseValue; }
        }


        public virtual float BaseValue
        {
            get { return _baseValue; }
            set { _baseValue = value; }
        }

        public Stat()
        {
            Name = string.Empty;
            BaseValue = 0;
        }

        public Stat(string name, float value)
        {
            Name = name;
            BaseValue = value;
        }
    }
}