using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToSleep : BehaviorSnippet
{
    public override void updateBehavior(GameObject character)
    {

        if (Vector2.Distance(target.transform.position, character.transform.position) < 0.1f)
        {
            Debug.Log("Watching TV");
        }

        if (Vector2.Distance(target.transform.position, character.transform.position) < 2.0f)
        {
            if (!target.GetComponent<TVScript>().screen.activeSelf)
            {
                Debug.Log("Turning the TV on");
                target.GetComponent<TVScript>().screen.SetActive(true);
            }
        }
        else
        {
            Debug.Log("Going to the TV");
        }
    }

    public GoToSleep(GameObject bed)
    {
        target = bed;
        typeOfAction = (int)UtilityType.WATCHING_TV;
    }
}