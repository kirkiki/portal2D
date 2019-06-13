using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
 public class moveArmRobot : MonoBehaviour
{

    public float speed = 3f;
    public SpriteRenderer direction_sprite;
    new bool enabled = false;
    
    private void Start()
    {
        direction_sprite = this.gameObject.GetComponent<SpriteRenderer>();
        direction_sprite.enabled = false;
    }
    // Update is called once per frame
    void Update()
    {

        // INIT 
        Vector2 mouse = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        Vector3 objpos = Camera.main.WorldToViewportPoint(transform.position);
        Vector2 relobjpos = new Vector2(objpos.x , objpos.y );
        Vector2 relmousepos = new Vector2(mouse.x , mouse.y ) - relobjpos;
        
        // VALUE ANGLE MOUSE
        float angle = Vector2.Angle(Vector2.up, relmousepos);

        // Management hidden shoot direction


        if (Input.GetMouseButtonDown(0))
        {
            //enabled = Input.GetMouseButtonDown(0) ? false : true;

            enabled = true;
           //direction_sprite.enabled = true;
        }


        if (Input.GetMouseButtonUp(0))
        {
            enabled = false;
        }

        direction_sprite.enabled = enabled;


        if (relmousepos.x > 0) angle = 360 - angle;

        Quaternion rotation = Quaternion.identity; // No rotation object. perfectly aligned with with the world or parent axes
        rotation.eulerAngles = new Vector3(0, 0, angle); // Get angle for rotate object

        transform.rotation = rotation; // Apply angle for rotate object

        //directionObject.GetComponent<SpriteRenderer>().enabled = enabled;

    }
}