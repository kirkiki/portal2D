using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropzone : MonoBehaviour
{
    public bool isActive = false;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag.Contains("Ball"))
        {
            isActive = true;
        }
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.tag.Contains("Ball"))
        {
            isActive = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag.Contains("Ball"))
        {
            isActive = false;
        }
    }
}
