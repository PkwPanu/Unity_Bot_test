using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] GameObject[] Spawnpoints;
    [SerializeField] GameObject respawnItem;
    public bool Enter = false;

    void Start()
    {
        
        Spawnpoints[0] = GameObject.Find("Spawn_Point (1)");
        Spawnpoints[1] = GameObject.Find("Spawn_Point (2)");
        Spawnpoints[2] = GameObject.Find("Spawn_Point (3)");
        Spawnpoints[3] = GameObject.Find("Spawn_Point (4)");
        Spawnpoints[4] = GameObject.Find("Spawn_Point (5)");
        Spawnpoints[5] = GameObject.Find("Spawn_Point (6)");
        Spawnpoints[6] = GameObject.Find("Spawn_Point (7)");
        Spawnpoints[7] = GameObject.Find("Spawn_Point (8)");
        
    }
    void Update()
    {
        if (Enter)
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                Respawn_active();
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject== respawnItem)
        {
            Debug.Log("press K");
            Enter = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == respawnItem)
        {
            Debug.Log("bye");
            Enter = false;
        }
    }

    void Respawn_active()
    {
        int rand = Random.Range(0, 8);
        transform.position = Spawnpoints[rand].transform.position;
    }

}
