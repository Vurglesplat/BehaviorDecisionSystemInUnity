using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovementScript : MonoBehaviour
{
    public GameObject targetObj = null;
    [HideInInspector] public Vector2 targetDifference;
    [SerializeField] float moveSpeed;
    Rigidbody2D rb;
    BehaviorDecisionSystem decisionSystem;
    PersonalSpace pSpace;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        decisionSystem = this.gameObject.GetComponent<BehaviorDecisionSystem>();
        pSpace = this.gameObject.GetComponentInChildren<PersonalSpace>();
    }

    // Update is called once per frame
    void Update()
    {
        if (targetObj)
        {
            targetDifference = (targetObj.transform.position - this.transform.position);
            if (targetDifference.magnitude > 0.1)
            {
                targetDifference.Normalize();
                rb.velocity = targetDifference * moveSpeed;

                if (pSpace.otherNPCsInRange.Count > 0)
                {
                    Debug.Log("1");
                    Vector3 distanceVec = new Vector3(0,0,0);
                    foreach (GameObject NPC in pSpace.otherNPCsInRange)
                    {
                        distanceVec += (this.gameObject.transform.position - NPC.transform.position);
                    Debug.Log("2");
                    }

                    if (distanceVec != new Vector3(0,0,0))
                    {
                    Debug.Log("3");
                        // the radius of the personal space is 1.5
                        float weightingForDistanceVec = (1.5f - (distanceVec.magnitude / pSpace.otherNPCsInRange.Count));

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
}
