using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Active : MonoBehaviour
{

    public GameObject whoa;
    public GameObject guy;

    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }



    //private void OnTriggerEnter(Collider other)
    //{
    //  if(other.CompareTag("Unlock"))
    //{
    // Destroy(other.gameObject);
    //     }////
    //}


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}