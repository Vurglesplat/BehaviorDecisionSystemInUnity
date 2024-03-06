using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BSnip_HandleHunger : BehaviorSnippet
{
    bool isDoingSomethingAboutHunger = false;

    public BSnip_HandleHunger(EvaluationTree parentEvalTree) : base(parentEvalTree) 
    {
        actionValue = 10;
        name = "Handling Hunger";
        currentActionName = "Hungry, thinking about food";
    }

    public override void BehaviorUpdate()
    {
        if (charStats.hunger < 0.7f)
        {
            Debug.Log(charStats.name + " is hungry");
            if (GameObject.FindGameObjectWithTag("Bread"))
            {
                Debug.Log("Got Bread, will try to eat.");
                evalTree.AddNewSnippet(new BSnip_GetBread(evalTree));
            }
            else
            {
                Debug.Log("No bread found, I'll make some");
                evalTree.AddNewSnippet(new BSnip_MakeBread(evalTree));
            }
        }
        else
        {
            Debug.LogWarning(charStats.name + " is actually not hungry");
            // ClearHungerConditions();
        }
    }

    public override void SnippetUpdate()
    {
        if(!isDoingSomethingAboutHunger)
            actionValue = (1.0f - charStats.hunger) * 100;
    }
}
