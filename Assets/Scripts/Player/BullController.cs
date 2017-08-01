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
        private Stats playerStats;

        void Start()
        {
            playerMovement = GetComponent<PlayerMovement>();
            playerStats = GetComponent<Stats>();

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

        public void IncreaseSpeed(float speed, float duration)
        {
            playerMovement.AddTemporarySpeedBoost(speed, duration);
        }
    }
}