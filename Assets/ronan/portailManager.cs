using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portailManager : MonoBehaviour
{
    public GameObject portail1;
    public GameObject portail2;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    GameObject getOtherPort(GameObject _portail)
    {
        return (_portail == portail1 ? portail2 : portail1);
    }
     void tp(GameObject portailToGo)
    {
        portailToGo.GetComponent<Transform>().position = new Vector3(portailToGo.GetComponent<Transform>().position.x + 1, portailToGo.GetComponent<Transform>().position.y + 1, getOtherPort(portailToGo).GetComponent<Transform>().position.z);
        Vector2 CurrentVelocity = portailToGo.GetComponent<Rigidbody2D>().velocity;
        float YVelocity = Mathf.Abs(CurrentVelocity.y);
        CurrentVelocity.y = 0;
        portailToGo.GetComponent<Rigidbody2D>().velocity = CurrentVelocity;
        portailToGo.GetComponent<Rigidbody2D>().AddForce(portailToGo.transform.up * YVelocity, ForceMode2D.Impulse);


    }
}
