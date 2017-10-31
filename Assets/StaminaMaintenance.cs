using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProPooling;
using System;

namespace Dariyal.Jallikattu
{
    public class StaminaMaintenance : MonoBehaviour
    {
        public float refillAmount;

        //public abstract class StaminaMaintenance : MonoBehaviour, IPoolComponent
        //{
        //    protected PoolItem _pooItem2;

        //    public void OnGetFromPool(PoolItem poolItem)
        //    {
        //        _pooItem2 = poolItem;
        //    }

        //    public void OnReturnToPool(PoolItem poolItem)
        //    {
        //    }

        //    public abstract void BoosterAction(BullController bull);

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                StaminaManager.staminaBar.fillAmount += refillAmount * Time.deltaTime;             //refill amount
                Destroy(this.gameObject);
                //BoosterAction(other.gameObject.GetComponent<BullController>());
                //_pooItem2.ReturnSelf();
            }
        }
    }
}


