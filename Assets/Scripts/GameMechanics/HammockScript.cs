using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammockScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        CharacterStats charStats = other.gameObject.GetComponent<CharacterStats>();
        if(charStats)
        {
            charStats.canSleep = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        CharacterStats charStats = other.gameObject.GetComponent<CharacterStats>();
        if (charStats)
        {
            charStats.canSleep = false;
        }
    }
}
