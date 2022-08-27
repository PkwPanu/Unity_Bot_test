using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject door;
    public bool open;
    private bool triggerEntered ;
    public float velocity = 1f;


    void Start()
    {
        open = false;
        triggerEntered = false;
    }
    void Update()
    {
        if(triggerEntered == true && Input.GetKeyDown(KeyCode.E))
        {     
                open = !open;
        }
        
        if (open &&  door.transform.position.y<5*1.5)
        {
            door.transform.Translate(transform.up*velocity);
        }
        if (!open && door.transform.position.y >= 5*0.5)
        {
            door.transform.Translate(-transform.up* velocity);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            Debug.Log("player in");
            triggerEntered = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag.Equals("Player"))
        {
            Debug.Log("player out");
            triggerEntered = false;
        }
    }

}
