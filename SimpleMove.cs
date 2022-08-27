using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMove : MonoBehaviour
{
    //keyboard
    public float speed = 10f;
    private Rigidbody rb;
    public float x,z;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

    }

    private void FixedUpdate()
    {
        //rb.velocity = new Vector3(x*speed, rb.velocity.y, z*speed);
        //rb.AddForce(0, y*300, 0);

        movePlayer(new Vector3(z, 0, x));
    }
    
    void movePlayer(Vector3 direction)
    {
        rb.MovePosition(transform.position+(direction * speed));
    }


}
