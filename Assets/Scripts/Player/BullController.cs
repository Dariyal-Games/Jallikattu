using Dariyal.Framework.StatSystem;
using Dariyal.Jallikattu.Stat;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dariyal.Jallikattu
{
    public class BullController : MonoBehaviour
    {
        public Transform attachPoint;
        private AttackerController attacker;
        private PlayerMovement playerMovement;
        private BullStats playerStats;

        void Start()
        {
            playerMovement = GetComponent<PlayerMovement>();
            playerStats = GetComponent<BullStats>();

            if (attachPoint == null) throw new System.Exception("Attach Point not set.");
        }

        public void SetAttacker(AttackerController attacker)
        {
            this.attacker = attacker;
        }

        public AttackerController GetAttacker()
        {
            return attacker;
        }

        public void AddPermanantModifier(StatType stat, StatModifier modifier)
        {
            playerStats.AddPermanentModifier(stat, modifier);
        }

        public void AddTemporaryModifier(StatType stat, StatModifier modifier, float duration)
        {
            playerStats.AddTemporaryModifier(stat, modifier, duration);
        }

        public void RemoveModifier(StatType stat, StatModifier modifier)
        {
            playerStats.RemoveModifier(stat, modifier);
        }

        public void OnSpeedupPowerup(float deltaSpeed, float duration)
        {
            playerMovement.AddTemporarySpeedBoost(deltaSpeed, duration);
        }
    }
}