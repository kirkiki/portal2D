using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    public int currentStage;
    public bool ended;
    public GameObject player;
    public GameObject start;
    public GameObject end;
    public GameObject pauseScreen;
    public GameObject finishScreen;
    public GameObject nextButton;

    private Rigidbody2D playerBody2D;
    private bool paused;

    void Start()
    {
        if (GameManager.stageUnlock < currentStage)
        {
            GoMenu();
        }

        playerBody2D = player.GetComponent<Rigidbody2D>();
        playerBody2D.position = start.transform.localPosition;
        pauseScreen.SetActive(false);
        finishScreen.SetActive(false);
        paused = false;
        Time.timeScale = 1;

        if (GameManager.stageCount <= currentStage)
        {
            nextButton.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Pause();
        }

        if (ended)
        {
            Time.timeScale = 0;
            finishScreen.SetActive(true);
            if (GameManager.stageCount > currentStage)
            {
                GameManager.stageUnlock = currentStage + 1;
            }
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Pause()
    {
        pauseScreen.SetActive(true);
        paused = true;
        Time.timeScale = 0;
    }

    public void Resume()
    {
        pauseScreen.SetActive(false);
        paused = false;
        Time.timeScale = 1;
    }

    public void GoMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void NextLevel()
    {
        SceneManager.LoadScene("Stage_" + (currentStage + 1));
    }
}
