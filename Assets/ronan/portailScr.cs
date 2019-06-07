using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portailScr : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject otherPortail;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<Transform>().position = new Vector3(otherPortail.GetComponent<Transform>().position.x + 1, otherPortail.GetComponent<Transform>().position.y + 1, otherPortail.GetComponent<Transform>().position.z);
        Vector2 CurrentVelocity = collision.gameObject.GetComponent<Rigidbody2D>().velocity;
        float YVelocity = Mathf.Abs(CurrentVelocity.y);
        CurrentVelocity.y = 0;
        collision.gameObject.GetComponent<Rigidbody2D>().velocity = CurrentVelocity;
        collision.gameObject.GetComponent<Rigidbody2D>().AddForce(otherPortail.transform.up * YVelocity, ForceMode2D.Impulse);
    }
}
