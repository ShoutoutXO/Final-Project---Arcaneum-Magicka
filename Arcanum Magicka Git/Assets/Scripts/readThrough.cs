using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class readThrough : MonoBehaviour
{
    public GameObject unlockDisplay;
    public GameObject button;

    // Start is called before the first frame update
    void Start()
    {
        unlockDisplay.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            unlockDisplay.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerExit(Collider other)
    {
        unlockDisplay.SetActive(false);
    }

}