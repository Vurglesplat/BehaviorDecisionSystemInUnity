using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeScaleChanger : MonoBehaviour
{

    [SerializeField]
    Slider timeScaleSlider;
    [Space] 
    [SerializeField]
    float maxTimeScale = 3.0f;
    [SerializeField]
    float minTimeScale = 0.0f;
    [SerializeField] 
    public float currentTimeScalePercentage = 1.0f;

    float baseTimeScalePercent;

    // Start is called before the first frame update
    void Start()
    {
        baseTimeScalePercent = 1.0f / (maxTimeScale - minTimeScale);

        timeScaleSlider.value = baseTimeScalePercent;

        timeScaleSlider.value = baseTimeScalePercent;
        currentTimeScalePercentage = timeScaleSlider.value;
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = Mathf.Lerp(minTimeScale, maxTimeScale, currentTimeScalePercentage);
    }

    public void UpdateSliderValue(float newValue)
    {
        currentTimeScalePercentage = newValue;
    }
}
