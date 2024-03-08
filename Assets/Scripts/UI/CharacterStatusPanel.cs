using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;

public class CharacterStatusPanel : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI currentActionHeader;
    [SerializeField] public TextMeshProUGUI currentGoalHeader;

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
}
