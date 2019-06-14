using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathZone : MonoBehaviour
{
    public StageManager stage;


    void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider && collider.tag.Contains("Player"))
        {
            stage.lost = true;
        }
    }
}
