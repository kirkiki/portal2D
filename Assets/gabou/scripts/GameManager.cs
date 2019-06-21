using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static public int stageCount = 9;
    static public int stageUnlock = 1;

    public GameObject levelsScreen;

    public void Play()
    {
        SceneManager.LoadScene("Stage_" + stageUnlock);
    }

    public void OpenLevels()
    {
        levelsScreen.SetActive(true);
    }

    public void CloseLevels()
    {
        levelsScreen.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
