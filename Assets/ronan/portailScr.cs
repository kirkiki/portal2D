using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portailScr : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject otherPortail;
    public GameObject portailManager;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (portailManager.GetComponent<portailManager>().player.GetComponent<Teleportable>().getTeleporting() == false)
        {
            Debug.Log( "1: " + portailManager.GetComponent<portailManager>().player.GetComponent<Teleportable>().teleporting);

            portailManager.GetComponent<portailManager>().player.GetComponent<Teleportable>().changeTeleporting();
            Debug.Log("2: " + portailManager.GetComponent<portailManager>().player.GetComponent<Teleportable>().teleporting);

            collision.gameObject.GetComponent<Transform>().position = new Vector3(otherPortail.GetComponent<Transform>().position.x, otherPortail.GetComponent<Transform>().position.y, otherPortail.GetComponent<Transform>().position.z);
            Vector2 CurrentVelocity = collision.gameObject.GetComponentInParent<Rigidbody2D>().velocity;
            float YVelocity = Mathf.Abs(CurrentVelocity.y);
            CurrentVelocity.y = 0;
            collision.gameObject.GetComponentInParent<Rigidbody2D>().velocity = CurrentVelocity;
            collision.gameObject.GetComponentInParent<Rigidbody2D>().AddForce(otherPortail.transform.up * YVelocity, ForceMode2D.Impulse);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        portailManager.GetComponent<portailManager>().player.GetComponent<Teleportable>().changeTeleporting();
    }
}
