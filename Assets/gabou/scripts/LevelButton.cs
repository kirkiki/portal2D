using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour
{
    public int level = 1;

    void Update()
    {
        if (GameManager.stageUnlock < level)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }

    public void GoTo()
    {
        SceneManager.LoadScene("Stage_" + level);
    }
}
