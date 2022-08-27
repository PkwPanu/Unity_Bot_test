using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_rotateCam : MonoBehaviour
{
    public GameObject camemra;

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            Debug.Log("door");
        }
    }


    void rotateCam()
    {
        transform.localEulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + 45, transform.eulerAngles.z);
    }
}
