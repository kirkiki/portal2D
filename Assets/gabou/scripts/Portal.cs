using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject otherPortail;

    void OnTriggerEnter2D(Collider2D collider)
    {
        var teleportable = collider.gameObject.GetComponent<Teleportable>();
        if (teleportable && otherPortail.activeSelf && !teleportable.teleporting)
        {
            teleportable.teleporting = true;
            var colliderTransform = collider.gameObject.GetComponent<Transform>();
            var colliderBody2D = collider.gameObject.GetComponent<Rigidbody2D>();
            var otherPortailPosition = otherPortail.GetComponent<Transform>().position;

            colliderTransform.position = new Vector3(otherPortailPosition.x, otherPortailPosition.y, otherPortailPosition.z);
            Vector2 currentVel = colliderBody2D.velocity;
            float absVelY = Mathf.Abs(currentVel.y);
            currentVel.y = 0;
            colliderBody2D.velocity = currentVel;
            Debug.Log(absVelY);
            colliderBody2D.AddForce(otherPortail.transform.up * absVelY, ForceMode2D.Impulse);
        }
    }

    IEnumerator OnTriggerExit2D(Collider2D collider)
    {
        var teleportable = collider.gameObject.GetComponent<Teleportable>();
        if (teleportable)
        {
            yield return new WaitForSeconds(.5f);
            teleportable.teleporting = false;
        }
    }
}
