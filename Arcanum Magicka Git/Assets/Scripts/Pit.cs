using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pit : MonoBehaviour
{
    //public Transform falling;
    //public GameObject player;

    void OnTriggerEnter(Collider other)
    {
        //if (other.CompareTag("Pit"))
        //{
        SceneManager.LoadScene(2);
        //}
    }
}