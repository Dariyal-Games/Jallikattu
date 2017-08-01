using Dariyal.Framework.StatSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


public enum StatType
{
    Strength,
    Agility,
    Stamina,
    Speed,
    Turning,
}

namespace Dariyal.Jallikattu.Stat
{
    public class BullStatCollection : StatCollection
    {
        protected override void ConfigureStats()
        {
            var strength = CreateOrGetStat<Framework.StatSystem.Attribute>(StatType.Strength);
            strength.Name = "Strength";
            var agility = CreateOrGetStat<Framework.StatSystem.Attribute>(StatType.Agility);
            agility.Name = "Agility";
            var stamina = CreateOrGetStat<Vital>(StatType.Stamina);
            stamina.Name = "Stamina";
            var stamStrLinker = new StatLinkerBasic(strength, 10);
            stamina.AddLinker(stamStrLinker);
            var speed = CreateOrGetStat<Framework.StatSystem.Attribute>(StatType.Speed);
            speed.Name = "Speed";
            var speedAgiLinker = new StatLinkerBasic(agility, .4f);
            var speedStrLinker = new StatLinkerBasic(strength, .6f);
            speed.AddLinker(speedAgiLinker);
            speed.AddLinker(speedStrLinker);
            var turning = CreateOrGetStat<Framework.StatSystem.Attribute>(StatType.Turning);
            turning.Name = "Turning";
            var turnAgiLinker = new StatLinkerBasic(agility, .5f);
            turning.AddLinker(turnAgiLinker);
        }
    }

    public class BullStats : MonoBehaviour
    {
        private BullStatCollection _bullStatCollection;

        public float Strength { get { return _bullStatCollection.GetStat<Framework.StatSystem.Attribute>(StatType.Strength).StatValue; } }

        public float Agility { get { return _bullStatCollection.GetStat<Framework.StatSystem.Attribute>(StatType.Agility).StatValue; } }

        public float CurrentStamina
        {
            get { return _bullStatCollection.GetStat<Vital>(StatType.Stamina).StatCurrentValue; }
            set
            {
                var stamina = _bullStatCollection.GetStat<Vital>(StatType.Stamina);
                if (stamina.StatCurrentValue != value)
                {
                    stamina.StatCurrentValue = value;
                }
            }
        }
        private void Start()
        {
            _bullStatCollection = new BullStatCollection();
        }
    }
}
