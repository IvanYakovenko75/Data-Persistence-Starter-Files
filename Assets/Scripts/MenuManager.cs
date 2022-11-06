using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    //public /*static*/ MenuManager Instance;

    //private void Awake()
    //{
    //    SceneManager.LoadScene(1);

    //    //Когда другая сцена, на которую вы переместились, пытается создать свой собственный MainManager,
    //    //уничтожаем этот MainManager, если он не единственный.
    //    if (Instance != null)
    //    {
    //        Destroy(gameObject);
    //        return;
    //    }

    //    //Но если это единственное, не уничтожайте его
    //    Instance = this;

    //    DontDestroyOnLoad(gameObject);

    //    //LoadHighScore();

    //}


    public void Game()
    {
        SceneManager.LoadScene(0);
    }

    public void LeaderBoard()
    {
        SceneManager.LoadScene(2);
    }

    public void Quit()
    {
        //если тестируем в редакторе, прекратить симуляцию. 
        //    иначе выйти из игры.
        Application.Quit();
    }

     void Start()
    {

    }

    private void Update()
    {
        
    }
}
