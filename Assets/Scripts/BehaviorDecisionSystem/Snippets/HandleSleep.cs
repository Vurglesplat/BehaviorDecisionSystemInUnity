using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleSleep : BehaviorSnippet
{

    public HandleSleep(EvaluationTree parentEvalTree) : base(parentEvalTree)
    {
        typeOfAction = UtilityType.GETTING_SLEEP;
        name = "Trying To Get Sleep";
        currentActionName = "Thinking About Sleep";
    }

    public override void BehaviorUpdate()
    {
        target = charStats.Hammock;
        if (!target)
        {
            Debug.Log("NO BED");
        }
        else
        {
            if ((Vector2.Distance(target.transform.position, charStats.gameObject.transform.position) < 0.1f))
            {
                Debug.Log("IN BED");
                currentActionName = "Sleeping";
            }
            else
            {
                currentActionName = "Heading To Hammock";
            }
        }


    }
    public override void SnippetUpdate()
    {
        actionValue = ((1.0f - charStats.energy) * 125);
    }
}