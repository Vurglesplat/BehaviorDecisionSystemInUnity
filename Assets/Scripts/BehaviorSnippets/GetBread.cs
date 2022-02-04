using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GetBread : BehaviorSnippet
{
    public BehaviourDecisionSystem bDS;

    public override void updateBehavior(GameObject character)
    {
        if(!target)
        {
            Debug.Log("Bread Missing!");
            bDS.ClearHungerConditions();
        }
        else
        {
            if ((Vector2.Distance(target.transform.position, character.transform.position) < 0.5f))
            {
                Debug.Log("Eating the bread");
                GameObject.Destroy(target);
                character.GetComponent<BehaviourDecisionSystem>().hunger = 1.0f;
            }
            else
            {
                Debug.Log("going to the bread");
            }
        }


    }

    public GetBread(GameObject bread, BehaviourDecisionSystem newBDS)
    {
        target = bread;
        typeOfAction = UtilityType.GET_BREAD;
        bDS = newBDS;
    }
}
