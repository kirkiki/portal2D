using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehaviour : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject cam;
    public float maxJump;
    public float speed;
    public bool isGrounded;
    public float x;
    public float y;
    public float offset;
    private float angle;
    private int vie;
    // Start is called before the first frame update
    void Start()
    {
        isGrounded = false;
        vie = 100;
        rb = GetComponent<Rigidbody2D>();
        offset = cam.GetComponent<CameraMovement>().offset;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Jump");
        Vector3 left = new Vector3(1, 0, 0);
        Vector3 right = new Vector3(1, 0, 0);
        rb.velocity = new Vector2(x * speed, rb.velocity.y);
        if ( x < 0)
        {
            if (transform.localScale.x > -0.6)
            {
                Vector3 test = transform.localScale;
                test.x -= 0.05f;
                transform.localScale = test;
            }
            if (cam.GetComponent<CameraMovement>().offset > -offset)
            {
                cam.GetComponent<CameraMovement>().offset -= 0.3f ;
            }
        }
        if (x > 0)
        {
            if (transform.localScale.x < 0.6)
            {
                Vector3 test = transform.localScale;
                test.x += 0.05f;
                transform.localScale = test;
            }
            if (cam.GetComponent<CameraMovement>().offset < offset)
            {
                cam.GetComponent<CameraMovement>().offset += 0.3f;
            }
        }
        if (isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, y * maxJump);
        }
    }
    void Jump()
    {
        rb.velocity += new Vector2(0, maxJump);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isGrounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isGrounded = false;
        }
    }
    private void reverse ()
    {

    }
}
