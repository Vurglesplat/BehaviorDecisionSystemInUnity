using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

/// <summary>
/// Deciding what each action does, and what it's value is. This should work relative to each action's context.
/// </summary>
public class EvaluationTree
{
    [HideInInspector] public BehaviourDecisionSystem bds;

    
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
        AddNewSnippet((new HandleHunger(this)));

        // sleep

        // social

        // tv
        AddNewSnippet(new WatchTV(this));
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

            if (current.actionValue > currentHighest.actionValue)
            {
                currentHighest = current;
            }
        }

        return currentHighest;
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

    static bool IsHungerRelated(BehaviorSnippet x)
    {
        if (x.typeOfAction == UtilityType.MAKE_BREAD || x.typeOfAction == UtilityType.GET_BREAD)
            return true;
        else
            return false;
    }
}


