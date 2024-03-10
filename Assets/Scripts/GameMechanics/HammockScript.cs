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
            charStats.canCurrentlySleep = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        CharacterStats charStats = other.gameObject.GetComponent<CharacterStats>();
        if (charStats)
        {
            charStats.canCurrentlySleep = false;
        }
    }
}
