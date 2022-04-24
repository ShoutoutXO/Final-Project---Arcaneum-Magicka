using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorOpen : MonoBehaviour
{
    [SerializeField]
    GameObject lockDoor;

    bool unlockDoor = false;

    void OnTriggerEnter(Collider col)
    {   // 
        if (!unlockDoor)
        {
            unlockDoor = true;
            lockDoor.transform.position += new Vector3(-15, 0, 0);
        }
    }
}
