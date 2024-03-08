using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BSnip_HandleSleep : BehaviorSnippet
{
    public BSnip_HandleSleep(EvaluationTree parentEvalTree) : base(parentEvalTree)
    {
        typeOfAction = UtilityType.GETTING_SLEEP;
        name = "Trying To Get Sleep";
        currentActionName = "Thinking About Sleep";
    }

    public override void BehaviorUpdate()
    {
        ChangeCurrentMovementTarget(charStats.Hammock);

        if (!target)
        {
            Debug.Log("NO BED");
        }
        else
        {
            if ((Vector2.Distance(target.transform.position, charStats.gameObject.transform.position) < 0.1f))
            {
                Debug.Log("IN BED");
                
                ChangeCurrentAction("Sleeping");
            }
            else
            {
                ChangeCurrentAction("Heading To Hammock");
            }
        }


    }
    public override void SnippetUpdate()
    {
        actionValue = ((1.0f - charStats.energy) * 125);
    }
}