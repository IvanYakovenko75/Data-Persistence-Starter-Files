using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int LineCount = 6;
    public Rigidbody Ball;
    public Text ScoreText;
    public GameObject GameOverText;
    public GameObject StartMenuDialog;

    [SerializeField] private Brick _brickPrefab;
    [SerializeField] private float _lineLength = 4f;
    [SerializeField] private Vector3 startFirstLinePosition = new Vector3(-1.5f, 2f, 0);

    private bool m_Started = false;
    private bool m_GameOver = false;
    private float lineStep = 0.3f;
    private float forceModefiler = 2.0f;
    private int m_Points;

    const float step = 0.6f;

    private void Start()
    {
        CreateField();
    }

    public void StartGame()
    {
        if (!m_Started)
        {
            m_Started = true;
            BalloonFlight();
        }
        else if (m_GameOver)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void BalloonFlight()
    {
        float randomDirection = Random.Range(-1.0f, 1.0f);
        Vector3 forceDir = new Vector3(randomDirection, 1, 0);
        forceDir.Normalize();
        Ball.transform.SetParent(null);
        Ball.AddForce(forceDir * forceModefiler, ForceMode.VelocityChange);
    }

    public void AddPoint(int point)
    {
        m_Points += point;
        ScoreText.text = $"Score : {m_Points}";
    }

    public void CreateField()
    {
        int perLine = Mathf.FloorToInt(_lineLength / step);
        int[] pointCountArray = new[] { 1, 1, 2, 2, 5, 5 };
        for (int i = 0; i < LineCount; ++i)
        {
            for (int x = 0; x < perLine; ++x)
            {
                Vector3 position = startFirstLinePosition + new Vector3(step * x, i * lineStep, 0);
                var brick = Instantiate(_brickPrefab, position, Quaternion.identity);
                brick.PointValue = pointCountArray[i];
                brick.onDestroyed.AddListener(AddPoint);
            }
        }
    }
    public void GameOver()
    {
        m_GameOver = true;
        GameOverText.SetActive(true);
        StartMenuDialog.SetActive(true);
    }
}
