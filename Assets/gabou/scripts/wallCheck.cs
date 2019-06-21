using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallCheck : MonoBehaviour
{
    private PlayerController controller;

    void Start()
    {
        controller = GetComponentInParent<PlayerController>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag.Contains("Ground") )
        {
            controller.wall = true;
        }
        if (collider.tag.Contains("PortalZone"))
        {
            controller.portail = true;
        }

    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.tag.Contains("Ground") )
        {
            controller.wall = true;
        }
        if (collider.tag.Contains("PortalZone"))
        {
            controller.portail = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag.Contains("Ground"))
        {
            controller.wall = false;
        }
        if (collider.tag.Contains("PortalZone"))
        {
            controller.portail = false;
        }
    }
}
