using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TVScript : MonoBehaviour
{
    public GameObject screen;
    public TextMeshProUGUI ElectricBill;
    public float currentElectricBill;
    public float electricBillRate;

    // Start is called before the first frame update
    void Start()
    {
        screen.SetActive(false);
        currentElectricBill = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(screen.activeInHierarchy)
            currentElectricBill += electricBillRate * Time.deltaTime;
        ElectricBill.text = "Electric Bill: " + currentElectricBill.ToString("c2"); //convert it to currency, $ included!
    }
}
