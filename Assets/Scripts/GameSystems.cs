using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSystems : MonoBehaviour
{
    public static GameSystems Instance;

    public int PlayerScore { get; set; }

    void  Awake()
    {
    if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    else
        {
            Destroy(gameObject);

        }

    }


    void Start()
    {
        SceneManager.LoadScene(GameScenes.LevelScene);
    }



}
