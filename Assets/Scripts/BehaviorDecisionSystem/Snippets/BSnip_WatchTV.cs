using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BSnip_WatchTV : BehaviorSnippet
{

    public BSnip_WatchTV(EvaluationTree parentEvalTree) : base(parentEvalTree)
    {
        actionValue = 40;
        name = "Bored, want to watch TV";
    }

    public override void BehaviorUpdate()
    {
        ChangeCurrentMovementTarget(charStats.TV);

        if (Vector2.Distance(target.transform.position, charStats.gameObject.transform.position) < 1.5f)
        {
            ChangeCurrentAction("Watching TV");
        }

        if (Vector2.Distance(target.transform.position, charStats.gameObject.transform.position) < 2.0f)
        {
            if (!target.GetComponent<TVScript>().screen.activeSelf)
            {
                ChangeCurrentAction("Turning the TV on");
                target.GetComponent<TVScript>().screen.SetActive(true);
                ChangeCurrentMovementTarget(null);
            }
        }
        else
        {
            ChangeCurrentAction("Heading to the TV");
        }
    }

    public override void SnippetUpdate()
    {
        ;
    }
}
