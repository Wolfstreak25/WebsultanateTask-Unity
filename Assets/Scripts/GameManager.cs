using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance{get {return instance;}}
    [SerializeField] private BallController m_ball;
    [SerializeField] private GameObject m_pauseScreen;
    [SerializeField] private TextMeshProUGUI m_pressToStart;
    [SerializeField] private TextMeshProUGUI m_scorePlayer1;
    private int m_p1Score;
    [SerializeField] private TextMeshProUGUI m_scorePlayer2;
    private int m_p2Score;
    [SerializeField] private GameObject m_endScreen;
    [SerializeField] private TextMeshProUGUI m_winnerTitle;
    [SerializeField] private TextMeshProUGUI m_winnerScore;
    [SerializeField] private int m_winningScore = 3;
    private bool m_isBallStatic = true;
    private bool m_isPaused = false;
    public bool IsGamePaused { get{return m_isPaused;}}
     private void Awake() 
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        m_pressToStart.gameObject.SetActive(true);
    }
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space) && m_isBallStatic && !m_isPaused)
        {
            m_isBallStatic = false;
            m_ball.LaunchBall();
            m_pressToStart.gameObject.SetActive(false);
        }
        if(Input.GetKeyUp(KeyCode.Escape) && !m_isPaused)
        {
            PauseGame();
        }
        else if(Input.GetKeyUp(KeyCode.Escape) && m_isPaused)
        {
            ResumeGame();
        }
        UpdateScore();
    }
    private void ResetBall()
    {
        m_isBallStatic = true;
        m_ball.ResetBall();
        m_pressToStart.gameObject.SetActive(true);
    }
    public void ResumeGame()
    {
        m_isPaused = false;
        ResetBall();
        m_pauseScreen.gameObject.SetActive(false);
    }
    private void PauseGame()
    {
        m_isPaused = true;
        m_pauseScreen.gameObject.SetActive(true);
    }
    public void Scored(PlayerType player)
    {
        if(player == PlayerType.Player1)
        {
            m_p1Score++;
            if(m_p1Score >= m_winningScore )
            {
                GameEnd(PlayerType.Player1);
            }
        }
        if(player == PlayerType.Player2)
        {
            m_p2Score++;
            if (m_p2Score >= m_winningScore)
            {
                GameEnd(PlayerType.Player2);
            }
        }
        ResetBall();
    }
    private void UpdateScore()
    {
        m_scorePlayer1.text = $"{m_p1Score}";
        m_scorePlayer2.text = $"{m_p2Score}";
    }
    private void GameEnd(PlayerType winner)
    {
        m_isPaused = true;
        m_endScreen.SetActive(true);
        m_winnerTitle.text = $"{winner + " Won"}";
        m_winnerScore.text = $"{m_p1Score +" : "+ m_p2Score}";
    }
}
