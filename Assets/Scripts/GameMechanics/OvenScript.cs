using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OvenScript : MonoBehaviour
{
    [SerializeField] GameObject breadPrefab;
    [SerializeField] GameObject grate;


    [Space]
    [Space]
    [Space]

    public bool isCooking = false;


    public float fullCookTime = 10.0f;
    [Range(0.0f, 10.0f)]public float timeLeft = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isCooking)
        {
            timeLeft -= 0.01f;
            grate.SetActive(true);
        }
        else
        {
            grate.SetActive(false);
        }

        if (timeLeft < 0.0f && isCooking == true)
        {
            FinishCooking();
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            StartCooking();
        }
    }

    public void StartCooking()
    {
        timeLeft = fullCookTime;
        isCooking = true;
    }
    public void FinishCooking()
    {
        isCooking = false;
        Vector3 offset = this.transform.position + new Vector3(0.7f,-0.4f,0);
        Instantiate(breadPrefab, offset, Quaternion.identity);
    }
}
