using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BSnip_GoToSleep : BehaviorSnippet
{
    public BSnip_GoToSleep(EvaluationTree parentEvalTree) : base(parentEvalTree)
    { }

public override void BehaviorUpdate()
    {
        Debug.LogError("The GoToSleep Behavior snippet has not been implemented but is being called");

        //if (Vector2.Distance(target.transform.position, charStats.gameObject.transform.position) < 0.1f)
        //{
        //    Debug.Log("Watching TV");
        //}

        //if (Vector2.Distance(target.transform.position, charStats.gameObject.transform.position) < 2.0f)
        //{
        //    if (!target.GetComponent<TVScript>().screen.activeSelf)
        //    {
        //        Debug.Log("Turning the TV on");
        //        target.GetComponent<TVScript>().screen.SetActive(true);
        //    }
        //}
        //else
        //{
        //    Debug.Log("Going to the TV");
        //}
    }

    //public BSnip_GoToSleep(GameObject bed)
    //{
    //    target = bed;
    //    typeOfAction = (int)UtilityType.WATCHING_TV;
    //}
}