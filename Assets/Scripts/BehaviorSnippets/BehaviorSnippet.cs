using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UtilityType
{
    UNASSIGNED = -1,
    WATCHING_TV = 0,
    WASTING_ELECTRICITY,

    MAKE_BREAD,
    GET_BREAD,
    EXHAUSTED,

    TOTAL_UTILITY_VALUES
};

public class BehaviorSnippet
{
    public GameObject target;
    public UtilityType typeOfAction = UtilityType.UNASSIGNED;
    public float originalActionValue = -1;
    public float actionValue;


    public virtual void updateBehavior(GameObject character) { Debug.LogError("WARNING, DEFAULT SNIPPET UPDATE"); }

}


//public class WastingElectricity : BehaviorSnippet
//{

//    public override void updateBehavior(GameObject character)
//    {
//        if (Vector2.Distance(target.transform.position, character.transform.position) < 2.0f)
//            target.GetComponent<TVScript>().screen.SetActive(true);
//    }

//    public WastingElectricity(GameObject tv)
//    {
//        target = tv;
//        utilityValue = (int)UtilityValues.WASTING_ELECTRICITY;
//    }
//}



