using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Vector2 moving = new Vector2();
    public bool standing;

    private Rigidbody2D body2D;
    
    void Start()
    {
        body2D = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        moving.x = moving.y = 0;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            moving.x += 1;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            moving.x -= 1;
        }

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Space))
        {
            moving.y += 1;
        }
    }
}
