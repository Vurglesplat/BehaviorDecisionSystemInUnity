using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovementScript : MonoBehaviour
{
    private const double k_stoppingDistance = 0.1;
    private const float k_personalSpaceRadius = 1.5f;

    public GameObject targetObj = null;
    [HideInInspector] public Vector2 targetDifference;
    [SerializeField] float moveSpeed;
    Rigidbody2D rb;
    BehaviorDecisionSystem decisionSystem;
    PersonalSpace pSpace;

    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        decisionSystem = this.gameObject.GetComponent<BehaviorDecisionSystem>();
        pSpace = this.gameObject.GetComponentInChildren<PersonalSpace>();
    }

    void Update()
    {
        if (!targetObj)
        {
            return;
        }

        targetDifference = (targetObj.transform.position - this.transform.position);

        if (targetDifference.magnitude > k_stoppingDistance)
        {
            targetDifference.Normalize();
            rb.velocity = targetDifference * moveSpeed;

            // dodging other NPCs
            if (pSpace.otherNPCsInRange.Count > 0)
            {
                Vector3 distanceVec = new Vector3(0, 0, 0);
                foreach (GameObject NPC in pSpace.otherNPCsInRange)
                {
                    distanceVec += (this.gameObject.transform.position - NPC.transform.position);
                }

                if (distanceVec != new Vector3(0, 0, 0))
                {
                    // the radius of the personal space is 1.5
                    float weightingForDistanceVec = k_personalSpaceRadius - (distanceVec.magnitude / pSpace.otherNPCsInRange.Count);

                    // no reason for 0.1f, I just wanted it to be a small influence
                    Vector3 finalDistancingVec = Vector3.Lerp(distanceVec.normalized, (Quaternion.Euler(0, 0, -45f)) * new Vector3(rb.velocity.x, rb.velocity.y, 0), 0.4f);

                    rb.velocity = Vector3.Lerp(rb.velocity, finalDistancingVec, weightingForDistanceVec);
                }
            }
        }
        else
        {
            rb.velocity = new Vector2(0.0f, 0.0f);
        }
    }
}
