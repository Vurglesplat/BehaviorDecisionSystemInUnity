using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMode : MonoBehaviour
{
    enum GameModeTypes
    {
        Simulation,
        Interactable,
        Debug
    };

    [SerializeField] GameModeTypes currentGameMode = GameModeTypes.Debug;

    public static GameMode Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }

        Instance = this;
    }

    public bool isDebugMode()
    {
        return currentGameMode == GameModeTypes.Debug;  
    }
}