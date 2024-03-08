using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BSnip_GetBread : BehaviorSnippet
{

    public BSnip_GetBread(EvaluationTree parentEvalTree) : base(parentEvalTree)
    {
        actionValue = 80;
        typeOfAction = UtilityType.GET_BREAD;
        name = "Getting Food";  
        currentActionName = "Heading to Bread";        
    }

    public override void BehaviorUpdate()
    {
        target = GameObject.FindGameObjectWithTag("Bread");
        if (!target)
        {
            Debug.Log("No Bread to eat!");
            evalTree.RemoveAllRelatedToHunger();
        }
        else
        {
            if ((Vector2.Distance(target.transform.position, charStats.gameObject.transform.position) < 0.5f))
            {
                Debug.Log("Eating the bread");
                GameObject.Destroy(target);
                ChangeCurrentMovementTarget(null);
                charStats.hunger = 1.0f;
            }
            else
            {
                Debug.Log("going to the bread");
                ChangeCurrentMovementTarget(target);
            }
        }


    }
    public override void SnippetUpdate()
    {
        if (GameObject.FindGameObjectWithTag("Bread"))
            actionValue = ((1.0f - charStats.hunger) * 100) + 20;
        else
            actionValue = (1.0f - charStats.hunger) * 100 - 10;
    }
}
