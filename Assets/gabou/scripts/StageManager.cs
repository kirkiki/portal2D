using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    public int currentStage;
    public bool ended;
    public bool lost;
    public bool paused;
    public GameObject player;
    public GameObject start;
    public GameObject end;
    public GameObject pauseScreen;
    public GameObject lostScreen;
    public GameObject finishScreen;
    public GameObject nextButton;

    private Rigidbody2D playerBody2D;

    void Start()
    {
        if (GameManager.stageUnlock < currentStage)
        {
            GoMenu();
        }

        playerBody2D = player.GetComponent<Rigidbody2D>();
        playerBody2D.position = start.transform.localPosition;
        pauseScreen.SetActive(false);
        lostScreen.SetActive(false);
        finishScreen.SetActive(false);
        paused = false;
        ended = false;
        lost = false;
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

        if (lost)
        {
            lostScreen.SetActive(true);
        }

        if (ended)
        {
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
