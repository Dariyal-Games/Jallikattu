using UnityEngine;

namespace Dariyal.Jallikattu
{
    public class CrowdSystem : MonoBehaviour
    {
        public Transform personToAttach;

        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                personToAttach.GetComponent<AttackerController>().AttackBull(other.gameObject.GetComponent<BullController>());
            }
        }
    }
}
