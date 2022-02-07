using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    [Space]
    [SerializeField] Image hungerSlider;
    [SerializeField] Image energySlider;
    [SerializeField] Image socialSlider;


    [Space] [Space]
    [SerializeField] EvaluationTree evalTree = new EvaluationTree(); 
    [Space] [Space]
    
    [Range(0.0f, 1.0f)] public float hunger = 1.0f;
    [Range(0.0f, 1.0f)] public float energy  = 1.0f;
    [Range(0.0f, 1.0f)] public float social  = 1.0f;

    [Header("Stats")]
    [SerializeField] float hungerFallRate = 0.0f;
    [SerializeField] float energyFallRate = 0.0f;
    [SerializeField] float socialFallRate = 0.0f;

    [HideInInspector] public NPCMovementScript movementScript;
    
    bool isAwake = true;

    // Start is called before the first frame update
    void Start()
    {
        movementScript = this.gameObject.GetComponent<NPCMovementScript>();
        evalTree.behaveSys = this;
        evalTree.setup(TV);
    }

    // Update is called once per frame
    void Update()
    {
        CheckForNewActionConditions();

        updateStatValues();
        BehaviorSnippet currentSnippet = evalTree.FindCurrentAction();
        evalTree.UpdateTree();

        if (currentSnippet != null)
        {
            currentSnippet.updateBehavior(this.gameObject);
            movementScript.targetObj = currentSnippet.target;
        }
    }

    void updateStatValues()
    {
        // decay values
        if (isAwake)
        {
            hunger -= hungerFallRate * 0.0001f;
            energy -= energyFallRate * 0.0001f;
            social -= socialFallRate * 0.0001f;
        }


        //update sliders
        hungerSlider.fillAmount = hunger;
        energySlider.fillAmount = energy;
        socialSlider.fillAmount = energy;
    }
    public void CheckForNewActionConditions()
    {
        if (hunger < 0.7f)
        {
            Debug.Log("I am Hungry");

            if (GameObject.FindGameObjectWithTag("Bread"))
            {
                Debug.Log("Got Bread, will try to eat.");
                if (evalTree.currActionsShortlist[(int)UtilityType.GET_BREAD] == false)
                {
                    evalTree.currActionsShortlist[(int)UtilityType.GET_BREAD] = true;
                    evalTree.availableActions.Add(new GetBread(GameObject.FindGameObjectWithTag("Bread"), this));
                }
            }
            else
            {
                Debug.Log("No bread found, I'll make some");
                if (evalTree.currActionsShortlist[(int)UtilityType.MAKE_BREAD] == false)
                {
                    evalTree.currActionsShortlist[(int)UtilityType.MAKE_BREAD] = true;
                    evalTree.availableActions.Add(new MakeBread(oven, wheatfield));
                }
            }
        }
        else
        {
            Debug.Log("Not hungry");
            ClearHungerConditions();

        }
    }

    public void ClearHungerConditions()
    {
        if (evalTree.currActionsShortlist[(int)UtilityType.MAKE_BREAD] || evalTree.currActionsShortlist[(int)UtilityType.GET_BREAD])
        {
            evalTree.availableActions.RemoveAll(IsHungerRelated);
            evalTree.currActionsShortlist[(int)UtilityType.MAKE_BREAD] = false;
            evalTree.currActionsShortlist[(int)UtilityType.GET_BREAD] = false;
        }
    }

    static bool IsHungerRelated (BehaviorSnippet x)
    {
        if (x.typeOfAction == UtilityType.MAKE_BREAD || x.typeOfAction == UtilityType.GET_BREAD)
            return true;
        else
            return false;
    }
}
