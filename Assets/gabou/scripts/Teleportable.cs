using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportable : MonoBehaviour
{
    public bool teleporting = false;

    public void changeTeleporting()
    {
        teleporting = !teleporting;
    }
    public bool getTeleporting()
    {
        return teleporting;
    }
}
