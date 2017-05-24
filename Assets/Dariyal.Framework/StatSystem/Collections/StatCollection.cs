using System.Collections.Generic;
using UnityEngine;

namespace Dariyal.Framework.StatSystem
{
    /// <summary>
    /// Collection of stats.
    /// </summary>
    public class StatCollection
    {
        private Dictionary<StatType, Stat> _stats;

        public Dictionary<StatType, Stat> StatDictionary
        {
            get
            {
                if (_stats == null)
                {
                    _stats = new Dictionary<StatType, Stat>();
                    ConfigureStats();
                }

                return _stats;
            }
        }

        public StatCollection()
        {
            _stats = new Dictionary<StatType, Stat>();
            ConfigureStats();
        }

        protected virtual void ConfigureStats()
        {

        }

        public bool Contains(StatType type)
        {
            return _stats.ContainsKey(type);
        }

        public Stat GetStat(StatType type)
        {
            if (Contains(type))
            {
                return _stats[type];
            }

            return null;
        }

        public T GetStat<T>(StatType type) where T : Stat
        {
            return GetStat(type) as T;
        }

        protected T CreateStat<T>(StatType type) where T : Stat
        {
            T stat = System.Activator.CreateInstance(typeof(T)) as T;
            _stats.Add(type, stat);
            return stat;
        }

        protected T CreateOrGetStat<T>(StatType type) where T : Stat
        {
            T stat = GetStat<T>(type);
            if (stat == null)
            {
                stat = CreateStat<T>(type);
            }

            return stat;
        }

        public void AddModifier(StatType target, StatModifier modifier)
        {
            AddModifier(target, modifier, false);
        }

        public void AddModifier(StatType target, StatModifier modifier, bool update)
        {
            if (Contains(target))
            {
                var modStat = GetStat(target) as IModifiableStat;
                if (modStat != null)
                {
                    modStat.AddModifier(modifier);
                    if (update)
                    {
                        modStat.UpdateModifiers();
                    }
                }
                else
                {
                    Debug.Log("[StatSystem] Trying to add Modifier to a non IModifiableStat stat\"{" + target.ToString() + "\"");
                }
            }
            else
            {
                Debug.Log("[StatSystem] Trying to add Stat Modifier to \"" + target.ToString() + "\", but collection does not contain that stat");
            }
        }

        public void RemoveModifier(StatType target, StatModifier modifier)
        {
            RemoveModifier(target, modifier, false);
        }

        public void RemoveModifier(StatType target, StatModifier modifier, bool update)
        {
            if (Contains(target))
            {
                var modStat = GetStat(target) as IModifiableStat;
                if (modStat != null)
                {
                    modStat.RemoveModifier(modifier);
                    if (update)
                    {
                        modStat.UpdateModifiers();
                    }
                }
                else
                {
                    Debug.Log("[StatSystem] Trying to remove Modifier from a non IModifiableStat stat \"" + target.ToString() + "\"");
                }
            }
            Debug.Log("[StatSystem] Trying to remove Stat Modifier from \"" + target.ToString() + "\", but collection does not contain that stat");
        }

        public void ClearAllModifiers()
        {
            ClearAllModifiers(false);
        }

        public void ClearAllModifiers(bool update)
        {
            foreach (var key in StatDictionary.Keys)
            {
                ClearModifier(key, update);
            }
        }

        public void ClearModifier(StatType stat)
        {
            ClearModifier(stat, false);
        }

        public void ClearModifier(StatType stat, bool update)
        {
            if (Contains(stat))
            {
                var modStat = GetStat(stat) as IModifiableStat;
                if (modStat != null)
                {
                    modStat.ClearModifiers();
                    if (update)
                    {
                        modStat.UpdateModifiers();
                    }
                }
                else
                {
                    Debug.Log("[StatSystem] Trying to clear Stat Modifiers from non modifiable stat \"" + stat.ToString() + "\"");
                }
            }
            else
            {
                Debug.Log("[StatSystem] Trying to clear Stat Modifiers from \"" + stat.ToString() + "\", but RPGStats does not contain that stat");
            }
        }

        public void UpdateAllModifiers()
        {
            foreach (var key in StatDictionary.Keys)
            {
                UpdateModifier(key);
            }
        }

        public void UpdateModifier(StatType stat)
        {
            if (Contains(stat))
            {
                var modStat = GetStat(stat) as IModifiableStat;
                if (modStat != null)
                {
                    modStat.UpdateModifiers();
                }
                else
                {
                    Debug.Log("[StatSystem] Trying to Update Stat Modifiers for a non modifiable stat \"" + stat.ToString() + "\"");
                }
            }
            else
            {
                Debug.Log("[StatSystem] Trying to Update Stat Modifiers for \"" + stat.ToString() + "\", but RPGStats does not contain that stat");
            }
        }
    }
}