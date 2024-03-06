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
            Debug.Log("Bread Missing!");
            evalTree.RemoveAllRelatedToHunger();
        }
        else
        {
            if ((Vector2.Distance(target.transform.position, charStats.gameObject.transform.position) < 0.5f))
            {
                Debug.Log("Eating the bread");
                GameObject.Destroy(target);
                charStats.hunger = 1.0f;
            }
            else
            {
                Debug.Log("going to the bread");
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
