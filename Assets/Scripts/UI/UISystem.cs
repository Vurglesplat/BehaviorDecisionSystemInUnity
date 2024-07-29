using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// initial rough implementation of a fading system, going to be generalized beyond this single implementation

public class UISystem : MonoBehaviour
{
    [SerializeField] float FadeTimeSeconds;
    [SerializeField] UnityEngine.UI.Image blackCoverImage;

    bool isCurrentlyFading = false;
    float currentFadeTime = 0.0f;

    void Start()
    {
        StartFading(FadeTimeSeconds, blackCoverImage);
    }
    void Update()
    {
        if (isCurrentlyFading)
        {
            HandleFading();
        }
    }

    void StartFading(float timeToFullFadeSeconds, UnityEngine.UI.Image targetImage)
    {
        isCurrentlyFading = true;
        currentFadeTime = FadeTimeSeconds;
        targetImage.color = new Color(0, 0, 0, 1);
    }

    void HandleFading()
    {
        if (currentFadeTime > 0)
        {
            currentFadeTime -= Time.deltaTime;
            blackCoverImage.color = new Color(0, 0, 0, Mathf.Lerp(1, 0, 1 - (currentFadeTime / FadeTimeSeconds)));
        }
        else
        {
            blackCoverImage.color = new Color(0, 0, 0, 0);
            isCurrentlyFading = false;
        }
    }
}