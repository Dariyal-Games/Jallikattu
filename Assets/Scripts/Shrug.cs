using Dariyal.Framework.Events;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class Shrug : MonoBehaviour
{
    Stats bullStats;
    BullController controller;

    float bullShrugStrength;
    float attackerLatchStrength;
    bool beingAttacked;

    public float shrugFactor;

    // Use this for initialization
    void Start()
    {
        bullStats = GetComponent<Stats>();
        controller = GetComponent<BullController>();
        Messenger.AddListener("Bull Attacked", OnBullAttacked);
    }

    private void OnBullAttacked()
    {
        bullShrugStrength = (bullStats.PrimaryStats.Strength * .75f + bullStats.PrimaryStats.Stamina * .25f) * shrugFactor;
        attackerLatchStrength = controller.GetAttacker().attackStrength;
        beingAttacked = true;
        Debug.Log("Bull getting attacked by attacker with strength " + attackerLatchStrength.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        if (beingAttacked)
        {
            if (CrossPlatformInputManager.GetButtonDown("Shrug"))
            {
                attackerLatchStrength -= bullShrugStrength;
            }

            if(attackerLatchStrength <= 0)
            {
                controller.GetAttacker().LeaveBull();
                controller.SetAttacker(null);
              
                beingAttacked = false;
            }
        }
    }
}
