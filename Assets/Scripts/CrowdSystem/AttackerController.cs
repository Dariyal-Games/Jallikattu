using UnityEngine;

public class AttackerController : MonoBehaviour
{
    #region Members and Properties

    public Transform attachPoint;
    public float attackSpeed;

    private Transform target;
    //private Vector3 offset;
    private Vector3 direction;

    #endregion

    #region Unity Lifecycle

    void Start()
    {
        if (attachPoint == null) throw new System.Exception("Attach Point not set.");

        //offset = attachPoint.position - transform.position;
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
    /// <param name="bullAttachPoint"></param>
    public void AttackBull(Transform bullAttachPoint)
    {
        if (bullAttachPoint == null) throw new System.Exception("Bull attach point is null! How the #@#$ did that happen.");

        AttachToBull(bullAttachPoint);
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
        target = bullAttachPoint;
        direction = (bullAttachPoint.position - attachPoint.position).normalized;
    }

    #endregion

}

