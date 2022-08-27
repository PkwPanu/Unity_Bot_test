using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class WanderingVer2 : MonoBehaviour
{
    public float angleRand, RotateSpeed;
    public float obstacleRange;
    private float angle , randrotate;
    public LayerMask obstructionMask;
    AI_control AI_Control;



    void Start()
    {
        AI_Control = GetComponent<AI_control>();
    }
    void Update()
    {
       
            if (angle <= 4)
            {
                radar();
            }

            if (Mathf.Abs(angle) > 4)
            {
                rotate();
            }
            AI_Control.move();

    }
        void radar()
        {
            RaycastHit hit;
            if (Physics.SphereCast(transform.position, obstacleRange, transform.forward, out hit, obstacleRange, obstructionMask))
            {

                if (hit.distance < obstacleRange)
                {

                    angle= Vector3.SignedAngle(-transform.forward, hit.normal, transform.up);
                    angle = Random.Range(-angleRand, angleRand)+(180-2*Mathf.Abs(angle))*Mathf.Sign(angle);

                }

            }
        }

    void rotate()
    {
        if (angle > 0)
        {
            rotate_left();
        }
        if (angle < 0)
        {
            rotate_right();
        }

    }


    void rotate_right()
    {
        angle += Time.deltaTime * RotateSpeed;
        transform.Rotate(transform.up, Time.deltaTime * RotateSpeed);
        
    }

    void rotate_left()
    {
        angle -= Time.deltaTime * RotateSpeed;
        transform.Rotate(-transform.up, Time.deltaTime * RotateSpeed);
    }

 

    private void OnDrawGizmos()
    {
        if (Application.isPlaying)
        {

            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.position, transform.position + transform.forward * obstacleRange);
            Gizmos.DrawWireSphere(transform.position, obstacleRange);

        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Obstruction"))
        {
            if (randrotate == 1)
            {
                transform.Rotate(Vector3.up * RotateSpeed * Time.deltaTime);
            }
            else
            {
                transform.Rotate(-Vector3.up * RotateSpeed * Time.deltaTime);
            }
        }

    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Obstruction"))

        {
            randrotate = Random.Range(1, 3);

        }
    }

}
