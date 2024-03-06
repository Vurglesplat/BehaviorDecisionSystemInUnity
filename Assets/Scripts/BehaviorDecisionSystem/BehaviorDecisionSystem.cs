using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening.Core.Easing;

/// <summary>
/// This is the main script which connects the various aspects of the BDS.
/// </summary>

public class BehaviorDecisionSystem : MonoBehaviour
{
    [Space]
    [SerializeField] CharacterStatusPanel characterPanel;
    [Space]
    [SerializeField] EvaluationTree evalTree = new EvaluationTree(); 
    [Space] [Space]


    [HideInInspector] public NPCMovementScript movementScript;
    [HideInInspector] public CharacterStats charStats;


    // primary start function for the BDS
    void Start()
    {
        charStats = this.gameObject.GetComponent<CharacterStats>();
        charStats.bds = this;

        movementScript = this.gameObject.GetComponent<NPCMovementScript>();
        evalTree.bds = this;
        evalTree.SetupInitialSnippets();
    }

    void Update()
    {
        evalTree.UpdateTree();
        BehaviorSnippet currentSnippet = evalTree.FindCurrentAction();

        if (currentSnippet != null)
        {
            currentSnippet.BehaviorUpdate();
            // TODO: this script likely shouldn't handle the implementation of these changes, so these should be abstracted out to their relevant systems 
            movementScript.targetObj = currentSnippet.target;
            characterPanel.currentActionHeader.text = currentSnippet.currentActionName;
            characterPanel.currentGoalHeader.text = currentSnippet.name;
        }
    }
}
