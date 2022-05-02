using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pit : MonoBehaviour
{
    public Transform falling;
    public GameObject player;

    void OnTriggerEnter(Collider other)
    {
        player.transform.position = falling.transform.position;
    }
}

