using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class GameSystems : MonoBehaviour
{
    public static GameSystems Instance;

    //���������� ��� ������� ������
    public string playerName { get; set; }
    public int currentScore { get; set; }

    //���������� ��� ������ ������� ������
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
        //������� �������� ����� ��������� ������ ����������
        SaveData data = new SaveData();

        //����� �������, ��� �� ������ ���������
        data.highScore = currentScore;
        data.highScoreName = playerName;

        //�������������� � JSON � ������� JsonUtility.ToJson:
        string json = JsonUtility.ToJson(data);

        //����� File.WriteAllText ��� ������ ������ � ����
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

