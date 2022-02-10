using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterStats : MonoBehaviour
{
    [Space]
    public string charName;
    [Space]
    [SerializeField] Image hungerSlider;
    [SerializeField] Image energySlider;
    [SerializeField] Image socialSlider;

    [Header("Conditions")]
    public bool canSleep = false;

    [Space]
    [Header("Rates")]
    [Range(0.0f, 1.0f)] public float hunger = 1.0f;
    [Range(0.0f, 1.0f)] public float energy = 1.0f;
    [Range(0.0f, 1.0f)] public float social = 1.0f;

    [Header("Stats")]
    [SerializeField] float hungerFallRate = 0.0f;
    [SerializeField] float energyFallRate = 0.0f;
    [SerializeField] float socialFallRate = 0.0f;

    [Header("Potential Targets")]
    public GameObject TV;
    public GameObject Hammock;
    public GameObject Oven;
    public GameObject WheatField;
    public GameObject Friend1;
    public GameObject Friend2;


    bool isAwake = true;
    [HideInInspector] public BehaviourDecisionSystem bds;

    private void Update()
    {
        UpdateStatValues();
        UpdateStatVisuals();
    }

    void UpdateStatValues()
    {
        // decay values
        if (isAwake)
        {
            hunger -= hungerFallRate * 0.0001f;
            energy -= energyFallRate * 0.0001f;
            social -= socialFallRate * 0.0001f;
        }
        else
        {
            Debug.LogWarning("should decay stats differently when asleep");  //  TODO
        }

    }

    void UpdateStatVisuals()
    {
        //update sliders
        hungerSlider.fillAmount = hunger;
        energySlider.fillAmount = energy;
        socialSlider.fillAmount = energy;
    }


}
