using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandingCheck : MonoBehaviour
{
    private PlayerController controller;
    
    void Start()
    {
        controller = GetComponentInParent<PlayerController>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag.Contains("Ground"))
        {
            controller.standing = true;
        }
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.tag.Contains("Ground"))
        {
            controller.standing = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag.Contains("Ground"))
        {
            controller.standing = false;
        }
    }
}
