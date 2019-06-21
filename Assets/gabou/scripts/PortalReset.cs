using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalReset : MonoBehaviour
{
    public GameObject portalLeft;
    public GameObject portalRight;
    public GameObject trigger;

    private Dropzone dropzone;
    private SpriteRenderer r;
    private BoxCollider2D c;

    void Start()
    {
        r = GetComponent<SpriteRenderer>();
        c = GetComponent<BoxCollider2D>();

        if (trigger)
        {
            dropzone = trigger.GetComponent<Dropzone>();
        }
        else
        {
            dropzone = null;
        }
    }

    void Update()
    {
        if (dropzone && dropzone.isActive)
        {
            Deactivate();
        }
        else
        {
            Activate();
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag.Contains("Player"))
        {
            portalLeft.SetActive(false);
            portalRight.SetActive(false);
        }
    }

    private void Deactivate()
    {
        r.enabled = false;
        c.enabled = false;
    }

    private void Activate()
    {
        r.enabled = true;
        c.enabled = true;
    }
}
