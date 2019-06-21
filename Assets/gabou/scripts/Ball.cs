using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public GameObject player;

    private Rigidbody2D body2D;
    private CircleCollider2D collider;
    private Rigidbody2D playerBody2D;
    private bool holdable = false;
    private bool holded = false;
    private bool ready = true;

    void Start()
    {
        body2D = GetComponent<Rigidbody2D>();
        collider = GetComponent<CircleCollider2D>();
        playerBody2D = player.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (holded)
        {
            body2D.transform.position = new Vector3(playerBody2D.transform.position.x, playerBody2D.transform.position.y + 35, 0);

            if (ready && Input.GetKey(KeyCode.E))
            {
                SetTimeout();
                holded = false;
                collider.enabled = true;
            }
        }
        else
        {
            if (ready && holdable && Input.GetKey(KeyCode.E))
            {
                holded = true;
                collider.enabled = false;
            }
        }
    }

    IEnumerator SetTimeout()
    {
        ready = false;
        yield return new WaitForSeconds(1f);
        ready = true;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag.Contains("Player"))
        {
            holdable = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag.Contains("player"))
        {
            holdable = true;
        }
    }
}
