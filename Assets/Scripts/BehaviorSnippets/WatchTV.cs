using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatchTV : BehaviorSnippet
{

    public WatchTV(EvaluationTree parentEvalTree) : base(parentEvalTree)
    {
        actionValue = 40;
        name = "Bored, want to watch TV";
    }

    public override void BehaviourUpdate()
    {
        target = charStats.TV;

        if (Vector2.Distance(target.transform.position, charStats.gameObject.transform.position) < 1.5f)
        {
            currentActionName = "Watching TV";
        }

        if (Vector2.Distance(target.transform.position, charStats.gameObject.transform.position) < 2.0f)
        {
            if (!target.GetComponent<TVScript>().screen.activeSelf)
            {
                currentActionName = "Turning the TV on";
                target.GetComponent<TVScript>().screen.SetActive(true);
                target = null;
            }
        }
        else
        {
            currentActionName = "Heading to the TV";
        }
    }

    public override void SnippetUpdate()
    {
        ;
    }
}
