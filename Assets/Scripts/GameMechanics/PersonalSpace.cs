using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonalSpace : MonoBehaviour
{

    public List<GameObject> otherNPCsInRange = new List<GameObject>();
    CharacterStats charStats;

    private void Start()
    {
        charStats = this.gameObject.GetComponentInParent<CharacterStats>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == charStats.Friend1 || collision.gameObject == charStats.Friend2)
        {
            otherNPCsInRange.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == charStats.Friend1 || collision.gameObject == charStats.Friend2)
        {
            otherNPCsInRange.Remove(collision.gameObject);
        }
    }

    private void Update()
    {
        charStats.social += charStats.socialRestoreRate * (otherNPCsInRange.Count * 0.5f);
    }
}
