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

    //    //����� ������ �����, �� ������� �� �������������, �������� ������� ���� ����������� MainManager,
    //    //���������� ���� MainManager, ���� �� �� ������������.
    //    if (Instance != null)
    //    {
    //        Destroy(gameObject);
    //        return;
    //    }

    //    //�� ���� ��� ������������, �� ����������� ���
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
        //���� ��������� � ���������, ���������� ���������. 
        //    ����� ����� �� ����.
        Application.Quit();
    }

     void Start()
    {

    }

    private void Update()
    {
        
    }
}
