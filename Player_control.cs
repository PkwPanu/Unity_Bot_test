using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_control : MonoBehaviour
{
    private Animation anim;
    public float speed;
    private Rigidbody rb;
    private float x, z;
    private Vector3 Direction;
    public Vector3 mousePosition;
    public float relativeAngleCamera;

    public float Health;


    // Start is called before the first frame update
    void Start()
    {
        speed = 1000;
        Health = 100; 
        relativeAngleCamera = 0;
        rb = GetComponent<Rigidbody>();
        anim = gameObject.GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {    
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
        Direction = new Vector3(x, 0, z);

        mousePosition = Input.mousePosition;


        if (Direction != Vector3.zero)
        {
            anim.Play("Run");
        }
        else
        {
            anim.Play("Dizzy");
        }

        if(Input.GetMouseButtonDown(0))
        {
           
        }

        if(Input.GetKeyDown(KeyCode.Alpha0))
        {
            transform.position = new Vector3(12, 300, 35);
        }
            
    }

    private void FixedUpdate()
    {
        float angleR = Mathf.PI * relativeAngleCamera / 180;
        float cosR = Mathf.Cos(angleR);
        float sinR = Mathf.Sin(angleR);
        movePlayer(new Vector3(x * cosR + z * sinR, 0, z * cosR - x * sinR).normalized);

    }


    void movePlayer(Vector3 direction)
    {
        //Debug.Log(direction);
        if (direction != Vector3.zero)
            transform.rotation = Quaternion.LookRotation(direction);
        //direction.y -= speedY;
        //direction.y = -10 * Time.deltaTime;
        rb.velocity = direction * speed * Time.deltaTime + new Vector3(0, rb.velocity.y, 0);
         
        rb.angularVelocity = Vector3.zero;
    }

   


    void OnTriggerExit(Collider other)
    {

        if (other.gameObject.tag == "Door")
        {
            Debug.Log("door");
            Vector3 dir = (transform.position - other.transform.position).normalized;
            float angle = Vector3.SignedAngle(other.transform.forward, dir, Vector3.up);
            RotateCam(angle);
        }

        if (other.gameObject.tag == "water")
        {
            Debug.Log("exit water");
        }
    }


    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "water")
        {
            Debug.Log("in water");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "water")
        {
            Debug.Log("Enter water");
        }
    }




    void RotateCam(float angle)
    {
        if (angle >= 0)
            relativeAngleCamera -= 45;
        else
            relativeAngleCamera += 45;
    }
}
