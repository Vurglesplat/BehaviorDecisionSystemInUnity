using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    [Space]
    public string charName;

    [Header("Conditions")]
    public bool canCurrentlySleep = false;

    [Space]
    [Header("Rates")]
    [Range(0.0f, 1.0f)] public float hunger = 1.0f;
    [Range(0.0f, 1.0f)] public float energy = 1.0f;
    [Range(0.0f, 1.0f)] public float social = 1.0f;

    [Header("Stats")]
    [SerializeField] float hungerFallRate = 0.0f;
    [SerializeField] float energyFallRate = 0.0f;
    [SerializeField] float socialFallRate = 0.0f;
    [SerializeField] float generalFallRateModifier = 0.0001f;  // this is used to keep the other numbers more readable

    [Header("Restorables Amounts")]
    public float breadFillAmount = 1.0f;
    public float bedRestoreRate = 0.1f;
    public float socialRestoreRate = 0.005f;

    [Header("Potential Targets")]
    public GameObject TV;
    public GameObject Hammock;
    public GameObject Oven;
    public GameObject WheatField;
    public GameObject Friend1;
    public GameObject Friend2;


    bool isAwake = true;
    [HideInInspector] public BehaviorDecisionSystem bds;

    private void Update()
    {
        UpdateStatValues();
        bds.characterPanel.UpdateCharacterStats(this);
    }

    void UpdateStatValues()
    {
        // decay values
        if (isAwake)
        {
            hunger -= hungerFallRate * generalFallRateModifier * (Time.timeScale);
            energy -= energyFallRate * generalFallRateModifier * (Time.timeScale);
            social -= socialFallRate * generalFallRateModifier * (Time.timeScale);
        }
        else
        {
            Debug.LogWarning("should decay stats differently when asleep?");  //  TODO
        }
    }
}
