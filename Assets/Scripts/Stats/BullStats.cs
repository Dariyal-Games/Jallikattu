using Dariyal.Framework.StatSystem;
using System.Collections;
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
            var strength = CreateOrGetStat<Attribute>(StatType.Strength);
            strength.Name = "Strength";
            var agility = CreateOrGetStat<Attribute>(StatType.Agility);
            agility.Name = "Agility";
            var stamina = CreateOrGetStat<Vital>(StatType.Stamina);
            stamina.Name = "Stamina";
            var stamStrLinker = new StatLinkerBasic(strength, 10);
            stamina.AddLinker(stamStrLinker);
            var speed = CreateOrGetStat<Attribute>(StatType.Speed);
            speed.Name = "Speed";
            var speedAgiLinker = new StatLinkerBasic(agility, .4f);
            var speedStrLinker = new StatLinkerBasic(strength, .6f);
            speed.AddLinker(speedAgiLinker);
            speed.AddLinker(speedStrLinker);
            var turning = CreateOrGetStat<Attribute>(StatType.Turning);
            turning.Name = "Turning";
            var turnAgiLinker = new StatLinkerBasic(agility, .5f);
            turning.AddLinker(turnAgiLinker);
        }
    }

    public class BullStats : MonoBehaviour
    {
        private BullStatCollection _bullStatCollection;

        public Attribute Strength { get { return _bullStatCollection.GetStat<Attribute>(StatType.Strength); } }

        public Attribute Agility { get { return _bullStatCollection.GetStat<Attribute>(StatType.Agility); } }

        public Attribute Speed { get { return _bullStatCollection.GetStat<Attribute>(StatType.Speed); } }

        public Attribute Turning { get { return _bullStatCollection.GetStat<Attribute>(StatType.Turning); } }

        public Vital Stamina { get { return _bullStatCollection.GetStat<Vital>(StatType.Stamina); } }

        public void AddPermanentModifier(StatType stat, StatModifier modifier)
        {
            _bullStatCollection.AddModifier(stat, modifier);
        }

        public void AddTemporaryModifier(StatType stat, StatModifier modifier, float duration)
        {
            _bullStatCollection.AddModifier(stat, modifier);

            StartCoroutine(RemoveModifierWithDelay(stat, modifier, duration));
        }

        public void RemoveModifier(StatType stat, StatModifier modifier)
        {
            _bullStatCollection.RemoveModifier(stat, modifier);
        }

        public IEnumerator RemoveModifierWithDelay(StatType stat, StatModifier modifier, float delay)
        {
            yield return new WaitForSeconds(delay);

            RemoveModifier(stat, modifier);
        }

        private void Start()
        {
            _bullStatCollection = new BullStatCollection();
        }
    }
}
