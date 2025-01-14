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
    
    

    void Awake()
    {
        _instance = this;
    }
    
    void Update()
    {

    }
}