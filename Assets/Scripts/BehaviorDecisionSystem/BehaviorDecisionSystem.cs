using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening.Core.Easing;

/// <summary>
/// This is the main script which connects the various aspects of the BDS.
/// </summary>

public class BehaviorDecisionSystem : MonoBehaviour
{
    public delegate void OnBehaviorSnippetChanged(BehaviorSnippet newSnippet);

    [Space]
    [SerializeField] CharacterStatusPanel characterPanel;
    [Space]
    [SerializeField] EvaluationTree evalTree = new EvaluationTree(); 
    [Space] [Space]

    [HideInInspector] public OnBehaviorSnippetChanged onBehaviorSnippetChanged;
    [HideInInspector] public OnBehaviorSnippetChanged onActionChanged; // this is stored here for common access between each snippet and the character panel
    [HideInInspector] public NPCMovementScript movementScript;
    [HideInInspector] public CharacterStats charStats;


    BehaviorSnippet previousSnippet = null;

    // primary start function for the BDS, injects dependencies for the various subsystems
    void Start()
    {
        if (characterPanel == null)
        {
            Debug.LogError("Invalid CharacterStatusPanel on the behavior decision system.");
        }
        else
        {
            onBehaviorSnippetChanged += characterPanel.UpdateDisplayForNewSnippet;
            onActionChanged += characterPanel.UpdateDisplayForNewAction;
        }

        charStats = this.gameObject.GetComponent<CharacterStats>();
        if(!TryGetComponent(out charStats))
        {
            Debug.LogError("Unable to get a valid CharacterStats component on the behavior decision system.");
        }
        else
        {
            charStats.bds = this;
        }
        
        if(!TryGetComponent(out movementScript))
        {
            Debug.LogError("Unable to get a valid movement script component on the behavior decision system.");
        }
        else
        {
            evalTree.bds = this;
            evalTree.SetupInitialSnippets();
        }
    }

    void Update()
    {
        evalTree.UpdateTree();
        BehaviorSnippet currentSnippet = evalTree.DetermineCurrentAction();

        if (currentSnippet == null)
        {
            Debug.LogError("Evaluation Tree was unable to determine an action, when it should at least have an idle state.");
            return;
        }

        currentSnippet.BehaviorUpdate();

        if (previousSnippet != currentSnippet)
        {
            if (previousSnippet != null)
            {
                Debug.Log("Snippet changed from " + previousSnippet.currentActionName + " to " + currentSnippet.currentActionName + " on " + this.gameObject.name + "!");
            }

            onBehaviorSnippetChanged(currentSnippet);
            previousSnippet = currentSnippet;
        }

        // TODO: this script likely shouldn't handle the implementation of these changes, so these should be abstracted out to their relevant systems 
        movementScript.targetObj = currentSnippet.target;
    }
}
