using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LoadManager : MonoBehaviour
{
    public Slider slider;

    public int level;
    private int slidV;
    public int stepSlidV = 7;
    public int timeStep = 4;
    public int timeLimit = 2;
    public int maxSliderValue = 100;
    private float timer;

    public float timeScreenLoad = 2;


    private void Start()
    {
        //SceneManager.LoadScene(0);
        //StartCoroutine(LoadGameRoutine());
        //SceneManager.LoadScene(1);
        Invoke("LoadGame", timeScreenLoad);
        //Debug.Log("Ready");
    }

    private void Update()
    {
        SliderMuve();
        if (slider.value >= maxSliderValue)
        {
            SceneManager.LoadScene(1);
        }
    }

    void SliderMuve()
    {
        slider.value = slidV;
        timer += timeStep * Time.deltaTime;
        if (timer >= timeLimit)
        {
            slidV += stepSlidV;
            timer = 0;
        }
    }

    void LoadGame()
    {
        SceneManager.LoadScene(1);
    }

    //IEnumerator LoadGameRoutine()
    //{
    //    yield return new WaitForSeconds(5);
    //}

}
