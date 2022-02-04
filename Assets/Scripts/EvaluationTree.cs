using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

/// <summary>
/// Deciding which action that is available is acted upon. This should work relative to each action's context.
/// </summary>
public class EvaluationTree
{
    [HideInInspector] public BehaviourDecisionSystem behaveSys;

    
    public List<BehaviorSnippet> availableActions = new List<BehaviorSnippet>();
    //private void Method<BehaviorSnippet>(List<BehaviourSnippet> foos)
    public bool[] currActionsShortlist = new bool[(int)UtilityType.TOTAL_UTILITY_VALUES];


    public void setup(GameObject TV)
    {
        for (int i = 0; i < (int)UtilityType.TOTAL_UTILITY_VALUES; i++)
        {
            currActionsShortlist[i] = false;
        }

        currActionsShortlist[(int)UtilityType.WATCHING_TV] = true;
        availableActions.Add(new WatchTV(TV));
    }

    public BehaviorSnippet FindCurrentAction()
    {
        BehaviorSnippet currentHighest = null;
        foreach(BehaviorSnippet current in availableActions)
        {
            if (currentHighest == null)
            {
                currentHighest = current;
            }

            if (current.typeOfAction > currentHighest.typeOfAction)
            {
                //  TODO
                Debug.LogWarning("Evaluating based off of type, not value");
                currentHighest = current;
            }
        }

        return currentHighest;
    }

    public void UpdateTree()
    {

    }
}

