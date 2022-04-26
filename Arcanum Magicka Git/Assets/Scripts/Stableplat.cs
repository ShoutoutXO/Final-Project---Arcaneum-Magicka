using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stableplat : MonoBehaviour
{

    public GameObject magePlayer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == magePlayer)
        {
            magePlayer.transform.parent = transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == magePlayer)
        {
            magePlayer.transform.parent = null;
        }
    }
}