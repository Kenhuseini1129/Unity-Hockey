using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    private GameObject playerGoal;
    private GameObject enemyGoal;
    public GameObject resultUI;
    public GameObject winUI;
    public GameObject loseUI;
    public GameObject pauseUI;

    Goal playerScore;
    Goal enemyScore;

    // Start is called before the first frame update
    void Start()
    {
        playerGoal = GameObject.Find("LeftGoal");
        playerScore = playerGoal.GetComponent<Goal>();

        enemyGoal = GameObject.Find("RightGoal");
        enemyScore = enemyGoal.GetComponent<Goal>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerScore.score == 11 && GameResult())
        {
            resultUI.SetActive(true);
            winUI.SetActive(true);
        }
        else if(enemyScore.score == 11 && GameResult())
        {
            resultUI.SetActive(true);
            loseUI.SetActive(true);
        }

        GamePause();
    }


    private bool GameResult()
    {
        if (playerScore.score == 11 || enemyScore.score == 11)
        {
            return true;
        }
        return false;
    }

    public void GameRetry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        if(Time.timeScale == 0)
        {
            Time.timeScale = 1.0f;
        }
    }


    public void GamePause()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Time.timeScale = 0f;
            pauseUI.SetActive(true);
        }
    }

    public void GameUnpause()
    {
        Time.timeScale = 1.0f;
        pauseUI.SetActive(false);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Title");
        Time.timeScale = 1.0f;
    }
}
