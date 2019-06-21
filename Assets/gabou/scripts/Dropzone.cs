using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropzone : MonoBehaviour
{
    public bool active = false;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag.Contains("Ball"))
        {
            active = true;
        }
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.tag.Contains("Ball"))
        {
            active = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag.Contains("Ball"))
        {
            active = false;
        }
    }
}
