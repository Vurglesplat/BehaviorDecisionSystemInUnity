using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.EventSystems.EventTrigger;


public class CharacterStatusPanel : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI currentActionHeader;
    [SerializeField] public TextMeshProUGUI currentGoalHeader;

    [Space]
    [SerializeField] Image hungerSlider;
    [SerializeField] Image energySlider;
    [SerializeField] Image socialSlider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateDisplayForNewSnippet(BehaviorSnippet newBehavior)
    {
        currentActionHeader.text = newBehavior.currentActionName;
        currentGoalHeader.text = newBehavior.name;
    }

    public void UpdateDisplayForNewAction(BehaviorSnippet newBehavior)
    {
        currentActionHeader.text = newBehavior.currentActionName;
    }

    public void UpdateCharacterStats(CharacterStats newStats)
    {
        //update sliders
        hungerSlider.fillAmount = newStats.hunger;
        energySlider.fillAmount = newStats.energy;
        socialSlider.fillAmount = newStats.social;
    }
}
