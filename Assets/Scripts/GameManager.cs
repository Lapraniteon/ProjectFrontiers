using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    public int solved_firstSwitch;
    public int solved_keypadPuzzle;
    public int solved_wirePuzzle;
    public int solved_pipePuzzle;

    void Awake()
    {
        _instance = this;
    }
}