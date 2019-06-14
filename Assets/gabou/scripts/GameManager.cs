using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static public int stageCount = 5;
    static public int stageUnlock = 1;

    public void Play()
    {
        SceneManager.LoadScene("Stage_" + stageUnlock);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
