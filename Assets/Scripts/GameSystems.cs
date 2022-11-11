using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class GameSystems : MonoBehaviour
{
    public static GameSystems Instance;

    //ПЕРЕМЕННЫЕ ДЛЯ ТЕКУЩЕЙ СЕССИИ
    public string playerName { get; set; }
    public int currentScore { get; set; }

    //ПЕРЕМЕННЫЕ ДЛЯ СЕАНСА ВЫСОКИХ ОЦЕНОК
    public int highScore { get; set; }
    public string highScoreName { get; set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            //    LoadHighScore();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //    void Start()
    //{
    //    SceneManager.LoadScene(GameScenes.LevelScene);
    //}

    [System.Serializable]
    public class SaveData
    {
        public int highScore;
        public string highScoreName;
    }

    public void SaveHighScore(int currentScore, string playerName)
    {
        //Сначала создайте новый экземпляр данных сохранения
        SaveData data = new SaveData();

        //Затем укажите, что вы хотите сохранить
        data.highScore = currentScore;
        data.highScoreName = playerName;

        //преобразование в JSON с помощью JsonUtility.ToJson:
        string json = JsonUtility.ToJson(data);

        //метод File.WriteAllText для записи строки в файл
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScore = data.highScore;
            highScoreName = data.highScoreName;
        }
    }
}

