using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProPooling;
using System;

namespace Dariyal.Jallikattu
{
    public abstract class PowerUp : MonoBehaviour, IPoolComponent
    {
        protected PoolItem _pooItem;

        public void OnGetFromPool(PoolItem poolItem)
        {
            _pooItem = poolItem;
        }

        public void OnReturnToPool(PoolItem poolItem)
        {
        }

        public abstract void PowerUpAction(BullController bull);

        protected void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                PowerUpAction(other.gameObject.GetComponent<BullController>());
                _pooItem.ReturnSelf();
            }
        }
    }
}
