using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

// Global Game Manager class to handle game logic and global variables.

public class GameManager : MonoBehaviour
{
    private static GameManager _instance; // Game Manager singleton pattern
    [HideInInspector] public static GameManager Instance
    {
        get
        {
            if (_instance is null) // Error checking in case the Game Manager is not assigned
                Debug.LogError("GameManager is null!");

            return _instance;
        }
    } // Game Manager instance property

    [Tooltip("Whether the camera is currently being prevented from moving by a target.")]
    public bool cameraIsLocked;

    public bool lightsTurnedOn;

    public int solved_firstSwitch;
    public int solved_keypadPuzzle;
    public int solved_wirePuzzle;
    public int solved_pipePuzzle;
    public int solved_total;

    public bool securityCamerasOn;

    [Space]
    [Header("Events")]
    public UnityEvent m_OnPuzzleCompletion;

    void Awake()
    {
        _instance = this;
    }

    public void PuzzleCompleted()
    {
        solved_total = solved_firstSwitch + solved_keypadPuzzle + solved_wirePuzzle + solved_pipePuzzle;
        
        Debug.Log("Current amount of puzzles solved: " + (solved_firstSwitch + solved_keypadPuzzle + solved_wirePuzzle + solved_pipePuzzle));
        m_OnPuzzleCompletion.Invoke();
    }

    public void TurnOnLights()
    {
        if (!lightsTurnedOn)
            return;
    }
}