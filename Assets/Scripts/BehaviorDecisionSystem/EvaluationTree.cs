using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

/// <summary>
/// Deciding what each action does, and what it's value is. This should work relative to each action's context.
/// </summary>
public class EvaluationTree
{
    [HideInInspector] public BehaviorDecisionSystem bds;

    List<BehaviorSnippet> availableActions = new List<BehaviorSnippet>();
    //private void Method<BehaviorSnippet>(List<BehaviourSnippet> foos)

    public void AddNewSnippet(BehaviorSnippet newSnippet)
    {
        if(!ContainsType(newSnippet.name))
        {
            availableActions.Add(newSnippet);
        }
    }

    public void SetupInitialSnippets()
    {
        // TODO: Add the base actions here
        // food
        AddNewSnippet(new BSnip_HandleHunger(this));

        // sleep
        AddNewSnippet(new BSnip_HandleSleep(this));

        // social

        // tv
        AddNewSnippet(new BSnip_WatchTV(this));
    }

    public BehaviorSnippet DetermineCurrentAction()
    {
        if (availableActions == null || availableActions.Count < 1)
        {
            Debug.LogError("There were no valid availableActions available to the evaluation tree on: " + bds.gameObject.name);
            return null;
        }

        List<BehaviorSnippet> currentHighestActions = new List<BehaviorSnippet>();

        foreach(BehaviorSnippet currentSnippet in availableActions)
        {
            //emplace value if it's the first, or if it's a better value
            if (currentHighestActions.Count < 1 || currentSnippet.actionValue > currentHighestActions[0].actionValue)
            {
                currentHighestActions.Clear();
                currentHighestActions.Add(currentSnippet);
            }
            else if (currentSnippet.actionValue == currentHighestActions[0].actionValue)
            {
                currentHighestActions.Add(currentSnippet);
            }
        }

        if (currentHighestActions.Count == 1)
        {
            return currentHighestActions[0];
        }
        else 
        {
            Debug.LogWarning("Had " + currentHighestActions.Count + " snippets tie for highest action value on " + bds.gameObject + ", this is not necessarily a problem, but may indicate an error if happening very frequently.");
            return currentHighestActions[Random.Range(0, currentHighestActions.Count)];
        }
    }

    public void UpdateTree()
    {
        foreach (BehaviorSnippet current in availableActions)
        {
            current.SnippetUpdate();
        }
    }

    public bool ContainsType(string nameOfType)
    {
        foreach(BehaviorSnippet curAction in availableActions)
        {
            if (curAction.name == nameOfType)
                return true;
        }
           
        return false;
    }

    public void RemoveAllRelatedToHunger()
    {
         availableActions.RemoveAll(IsHungerRelated);
    }

    static bool IsHungerRelated(BehaviorSnippet snippet)
    {
        return (snippet.typeOfAction == UtilityType.MAKE_BREAD || snippet.typeOfAction == UtilityType.GET_BREAD);
    }
}


