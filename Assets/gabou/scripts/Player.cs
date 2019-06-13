using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector2 velocity = new Vector2(100, 200);
    public float maxSpeed = 15;
    public GameObject portalLeft;
    public GameObject portalRight;

    private Rigidbody2D body2D;
    private SpriteRenderer rendered2D;
    private PlayerController controller;
    
    void Start()
    {
        body2D = GetComponent<Rigidbody2D>();
        rendered2D = GetComponent<SpriteRenderer>();
        controller = GetComponent<PlayerController>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SetPortal(portalLeft);
        }
        if (Input.GetMouseButtonDown(1))
        {
            SetPortal(portalRight);
        }
    }

    void FixedUpdate()
    {
        var scale = transform.localScale;

        if (controller.moving.x != 0)
        {
            body2D.AddForce(new Vector2(controller.moving.x, 0) * velocity.x);
            scale.x = controller.moving.x;
        }

        if (controller.standing && controller.moving.y > 0)
        {
            body2D.AddForce(Vector2.up * velocity.y);
        }

        if (Mathf.Abs(body2D.velocity.x) > maxSpeed)
        {
            var speed = body2D.velocity.x > 0 ? maxSpeed : -maxSpeed;
            body2D.velocity = new Vector2(speed, body2D.velocity.y);
        }

        transform.localScale = scale;
    }

    void SetPortal(GameObject portal)
    {
        var worldMousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
        var direction = worldMousePosition - transform.position;
        direction.Normalize();

        var hit = Physics2D.Raycast(transform.position, direction);
        var collider = hit.collider;

        if (collider && collider.tag.Contains("PortalZone"))
        {
            Debug.Log("Portal");
            portal.transform.position = collider.transform.position;
            portal.transform.rotation = collider.transform.rotation;
        }
    }
}
