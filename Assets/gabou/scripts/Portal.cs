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
            var otherPortailPosition = otherPortail.GetComponent<Transform>().position;
            colliderTransform.position = new Vector3(otherPortailPosition.x + 1, otherPortailPosition.y + 1, otherPortailPosition.z);
            Vector2 CurrentVelocity = collider.gameObject.GetComponent<Rigidbody2D>().velocity;
            float YVelocity = Mathf.Abs(CurrentVelocity.y);
            CurrentVelocity.y = 0;
            collider.gameObject.GetComponent<Rigidbody2D>().velocity = CurrentVelocity;
            collider.gameObject.GetComponent<Rigidbody2D>().AddForce(otherPortail.transform.up * YVelocity, ForceMode2D.Impulse);
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
