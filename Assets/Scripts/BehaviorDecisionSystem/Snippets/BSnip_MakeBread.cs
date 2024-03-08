using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BSnip_MakeBread : BehaviorSnippet
{
    public BSnip_MakeBread(EvaluationTree parentEvalTree) : base(parentEvalTree)
    {
        actionValue = 70;
        typeOfAction = UtilityType.MAKE_BREAD;
        name = "Making Bread";
        currentActionName = "Making Bread";
    }

public override void BehaviorUpdate()
    {
        if (charStats.Oven.GetComponent<OvenScript>().isCooking)
        {
            ChangeCurrentMovementTarget(charStats.Oven);

            Debug.Log("Waiting for it to finish baking");
        }
        else
        {
            if (charStats.gameObject.GetComponent<HeldWheatScript>().heldWheat.activeSelf)
            {
                ChangeCurrentAction("Bringing Wheat To Oven");
                target = charStats.Oven;
                if (Vector2.Distance(target.transform.position, charStats.gameObject.transform.position) < 2.0f)
                {
                    ChangeCurrentAction("Baking Bread");
                    charStats.gameObject.GetComponent<HeldWheatScript>().heldWheat.SetActive(false);
                    target.GetComponent<OvenScript>().StartCooking();
                    ChangeCurrentMovementTarget(null);
                }
            }
            else
            {
                Debug.Log("looking for wheat");
                //currentActionName = "Looking For Wheat";

                ChangeCurrentMovementTarget(GameObject.FindGameObjectWithTag("WheatField"));
                if (target == null)
                {
                    Debug.LogError("NO WHEATFIELDS FOUND");
                }
                else
                {
                    ChangeCurrentAction("Heading To Wheat");
                }

                if (Vector2.Distance(target.transform.position, charStats.gameObject.transform.position) < 2.0f)
                {
                    Debug.Log("got wheat");
                    //currentActionName = "Grabbing Wheat";
                    charStats.gameObject.GetComponent<HeldWheatScript>().heldWheat.SetActive(true);
                }

            }
        }

    }

    public override void SnippetUpdate()
    {
        if (GameObject.FindGameObjectWithTag("Bread"))
            actionValue = ((1.0f - charStats.hunger) * 100) - 20;
        else
            actionValue = ((1.0f - charStats.hunger) * 100) + 10;
    }
}
