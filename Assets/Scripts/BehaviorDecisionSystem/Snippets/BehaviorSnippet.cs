using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UtilityType
{
    UNASSIGNED = -1,
    WATCHING_TV = 0,
    WASTING_ELECTRICITY,

    MAKE_BREAD,
    GET_BREAD,
    GETTING_SLEEP,

    TOTAL_UTILITY_VALUES
};

public abstract class BehaviorSnippet
{
    const string DEFAULT_NAME = "DEFAULT_BEHAVIOR_NAME";
    const string DEFAULT_ACTION = "DEFAULT_ACTION";

    public BehaviorDecisionSystem bDS;
    public EvaluationTree evalTree;
    public CharacterStats charStats;

    public GameObject target;
    public UtilityType typeOfAction = UtilityType.UNASSIGNED;
    public float originalActionValue = -1;
    public float actionValue;

    public string name = DEFAULT_NAME;
    public string currentActionName = DEFAULT_ACTION;

    /// <summary>
    ///  What this snippet does with control granted to it
    /// </summary>
    public virtual void BehaviorUpdate() 
    {
        Debug.LogError("WARNING, DEFAULT BEHAVIOUR UPDATE");
    }

    /// <summary>
    /// The snippets updating without any control being actually granted to them
    /// </summary>
    /// <param name="stats"></param>
    public virtual void SnippetUpdate() 
    {
        Debug.LogError("WARNING, DEFAULT SNIPPET UPDATE");
    }

    public BehaviorSnippet(EvaluationTree parentEvalTree)
    {
        evalTree = parentEvalTree;
        bDS = evalTree.bds;
        charStats = bDS.charStats;
    }

    public void ChangeCurrentAction(string newActionText)
    {
        currentActionName = newActionText;
        bDS.onActionChanged(this);
    }

    public void ChangeCurrentMovementTarget(GameObject newtarget)
    {
        target = newtarget;
        bDS.movementScript.targetObj = newtarget;
    }
}

