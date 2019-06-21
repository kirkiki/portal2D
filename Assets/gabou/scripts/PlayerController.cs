using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Vector2 moving = new Vector2();
    public bool standing;
    public bool wall;
    public bool portail;
    private Rigidbody2D body2D;
    
    void Start()
    {
        body2D = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        moving.x = moving.y = 0;

        var x = Input.GetAxisRaw("Horizontal");
        var y = Input.GetAxisRaw("Jump");

        if (x != 0)
        {
            moving.x = x;
        }

        if (y != 0)
        {
            moving.y = y;
        }
    }
}
