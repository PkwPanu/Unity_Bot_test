using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class AI_control : MonoBehaviour
{
    public float Move_force, Max_speed, fiction_constant;
    public LayerMask ObstructionLayer;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        Move_force = 10000;
        fiction_constant = 10000;
        Max_speed = 5f;
        //grav = 1000f;
        rb = GetComponent<Rigidbody>();
        move();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<FieldOfView>().canSeePlayer)
        {

            GetComponent<WanderingVer2>().enabled = false;
            GetComponent<AI_chaseVer2>().enabled = true;
        }
        else if (GetComponent<AI_chaseVer2>().gocheck)
        {
            
            GetComponent<WanderingVer2>().enabled = true;
            GetComponent<AI_chaseVer2>().gocheck = false;
        }
       
    }

    public void move()
    {
        //rb.velocity = rb.velocity + transform.forward * speed * Time.deltaTime;
        Maxspeed();
        fiction();
        rb.AddForce(transform.forward * Move_force * Time.deltaTime);
        rb.angularVelocity = Vector3.zero;
    }

    void fiction()
    {
        float velo = rb.velocity.magnitude;
        rb.AddForce( - rb.velocity.normalized * velo *fiction_constant* Time.deltaTime);
    }
    void Maxspeed()
    {
        float velo = rb.velocity.magnitude;
        velo=Mathf.Max(Max_speed, velo);
        rb.velocity= rb.velocity.normalized* velo;
    }

 
    void OnTriggerStay(Collider other)
    {
        //if(other.gameObject.tag=="Player")
            //speed = 0;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            GetComponent<WanderingVer2>().enabled = true;
    }

}
