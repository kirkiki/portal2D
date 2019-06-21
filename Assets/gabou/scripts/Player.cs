using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector2 velocity = new Vector2(100, 200);
    public Vector2 maxSpeed = new Vector2(15, 25);
    public GameObject portalLeft;
    public GameObject portalRight;
    public int speed;
    public int maxJump;

    private Rigidbody2D body2D;
    private SpriteRenderer rendered2D;
    private PlayerController controller;
    private StageManager stage;
    private Animator animator;
    private float defaultScale;
    
    void Start()
    {
        body2D = GetComponent<Rigidbody2D>();
        rendered2D = GetComponent<SpriteRenderer>();
        controller = GetComponent<PlayerController>();
        stage = GetComponentInParent<StageManager>();
        animator = GetComponent<Animator>();
        defaultScale = transform.localScale.x;
    }

    void Update()
    {
        if (!stage.paused && !stage.lost && !stage.ended)
        {
            if (Input.GetMouseButtonDown(0))
            {
                SetPortal(portalLeft);
            }
            else if (Input.GetMouseButtonDown(1))
            {
                SetPortal(portalRight);
            }
            else
            {
                if (Input.GetMouseButtonDown(2))
                {
                    if (portalLeft.activeSelf) { portalLeft.SetActive(false); }
                    if (portalRight.activeSelf) { portalRight.SetActive(false); }

                }
                animator.SetBool("shooting", false);
            }

            if (controller.standing)
            {
                animator.SetBool("standing", true);
            }
            else
            {
                animator.SetBool("standing", false);
            }
        }
    }

    void FixedUpdate()
    {
        if (!stage.paused && !stage.lost && !stage.ended)
        {
            var scale = transform.localScale;
            if(!controller.wall)
                body2D.velocity = new Vector2(controller.moving.x * speed, body2D.velocity.y);
            else if(controller.wall && !controller.portail)
                body2D.velocity = new Vector2(0, body2D.velocity.y);
            if (controller.moving.x != 0)
            {
                scale.x = defaultScale * controller.moving.x;
            }

            transform.localScale = scale;
            if (controller.standing )
            {
                body2D.velocity = new Vector2(body2D.velocity.x, controller.moving.y * maxJump);
            }
        }
    }

    void SetPortal(GameObject portal)
    {
        animator.SetBool("shooting", true);

        var worldMousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
        var playerPosition = transform.position;
        //playerPosition.y += 2;
        var worldPlayerPosition = Camera.main.ScreenToWorldPoint(new Vector3(playerPosition.x, playerPosition.y, 0));
        var direction = worldMousePosition - playerPosition;
        direction.Normalize();

        var hit = Physics2D.Raycast(playerPosition, direction);
        var collider = hit.collider;

        if (collider && collider.tag.Contains("PortalZone"))
        {
            portal.transform.position = collider.transform.position;
            portal.transform.rotation = collider.transform.rotation;
            portal.SetActive(true);
        }
    }
}
