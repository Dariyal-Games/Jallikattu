using UnityEngine;

public class AttackerController : MonoBehaviour
{
    #region Members and Properties

    public Transform attachPoint;
    public float attackSpeed;
    public float attackStrength;

    private Transform target;
    //private Vector3 offset;
    private Vector3 direction;

    #endregion

    #region Unity Lifecycle

    void Start()
    {
        if (attachPoint == null) throw new System.Exception("Attach Point not set.");

        //offset = attachPoint.position - transform.position;
        Debug.Log("Attacker strength " + attackStrength);
    }

    void Update()
    {
        if (target != null)
        {
            if ((target.position - attachPoint.position).magnitude > 0.1)
            {
                transform.position += attackSpeed * Time.deltaTime * direction;
            }
        }
    }

    #endregion


    #region Public Methods

    /// <summary>
    /// Attack the bull.
    /// </summary>
    /// <param name="bull"></param>
    public void AttackBull(BullController bull)
    {
        if (bull.attachPoint == null) throw new System.Exception("Bull attach point is null! How the #@#$ did that happen.");

        if (bull.GetAttacker() == null)
        {
            Debug.Log("Attacking Bull with strength " + attackStrength);
            bull.SetAttacker(this);
            AttachToBull(bull.attachPoint);
            Messenger.Broadcast("Bull Attacked");
        }
        else
        {
            Debug.Log("Bull has attacker.");
        }
    }

    public void LeaveBull()
    {
        Debug.Log("Leaving Bull.");
        target = null;
        transform.SetParent(null);
        Messenger.Broadcast("Bull Escaped");
        Destroy(gameObject);
    }

    #endregion

    #region Private Methods

    /// <summary>
    /// Attach the attacker to the bull.
    /// </summary>
    /// <param name="bullAttachPoint"></param>
    private void AttachToBull(Transform bullAttachPoint)
    {
        transform.SetParent(bullAttachPoint);
        Vector3 offset = bullAttachPoint.position - attachPoint.position;
        transform.position += offset;

    }

    #endregion

}

