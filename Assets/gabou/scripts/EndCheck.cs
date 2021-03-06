﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCheck : MonoBehaviour
{
    private StageManager manager;
    
    void Start()
    {
        manager = GetComponentInParent<StageManager>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag.Contains("Player"))
        {
            manager.ended = true;
        }
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.tag.Contains("Player"))
        {
            manager.ended = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag.Contains("Player"))
        {
            manager.ended = false;
        }
    }
}
