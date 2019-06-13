using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalReset : MonoBehaviour
{
    public GameObject portalLeft;
    public GameObject portalRight;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag.Contains("Player"))
        {
            portalLeft.SetActive(false);
            portalRight.SetActive(false);
        }
    }
}
