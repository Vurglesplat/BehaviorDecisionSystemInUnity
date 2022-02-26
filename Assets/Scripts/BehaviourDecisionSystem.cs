using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Deciding what actions are available to the system, and hard removing those that are not.
/// This should work relative to the player's context.
/// </summary>

public class BehaviourDecisionSystem : MonoBehaviour
{

    //[SerializeField] GameObject heldWheat = null;
    [SerializeField] GameObject TV;
    [SerializeField] GameObject oven;
    [SerializeField] GameObject wheatfield;

    [Header("UI Assignments")]
    [Space]
    [SerializeField] TextMeshProUGUI currentActionHeader;
    [SerializeField] TextMeshProUGUI currentGoalHeader;

    [Space] [Space]
    [SerializeField] EvaluationTree evalTree = new EvaluationTree(); 
    [Space] [Space]


    [HideInInspector] public NPCMovementScript movementScript;
    [HideInInspector] public CharacterStats charStats;
    

    // mother of all start functions, will handle the initialization of a lot of things
    void Start()
    {
        charStats = this.gameObject.GetComponent<CharacterStats>();
        charStats.bds = this;

        movementScript = this.gameObject.GetComponent<NPCMovementScript>();
        evalTree.bds = this;
        evalTree.SetupInitialSnippets();
    }

    // Update is called once per frame
    void Update()
    {
        CheckForNewActionConditions();

        evalTree.UpdateTree();
        BehaviorSnippet currentSnippet = evalTree.FindCurrentAction();

        if (currentSnippet != null)
        {
            currentSnippet.BehaviorUpdate();
            movementScript.targetObj = currentSnippet.target;
            currentActionHeader.text = currentSnippet.currentActionName;
            currentGoalHeader.text = currentSnippet.name;
        }
    }


    public void CheckForNewActionConditions()
    {

    }

}
