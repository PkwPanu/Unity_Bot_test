

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class FieldOfView : MonoBehaviour
{
    public float radius;
    [Range(0, 360)]
    public float angle;

    public GameObject playerRef;

    public LayerMask targetMask;
    public LayerMask obstructionMask;
    public Collider[] rangeChecks;
    public bool canSeePlayer;
    public Vector3 lastseetarget, directionToTarget;
    CapsuleCollider CapCollider;

    private void Start()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player");
        CapCollider = GetComponent<CapsuleCollider>();
    }

    void Update()
    {
        //if (canSeePlayer)
        //{ Debug.Log("player"); }
    }

    private void FixedUpdate()
    {
        FieldOfViewCheck();
     
    }

    private void FieldOfViewCheck()
    {
        rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);

        if (rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
           
            directionToTarget = (target.position+ Vector3.up*CapCollider.height - CapCollider.bounds.center).normalized;
      

            if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);
             
                if (!Physics.Raycast(CapCollider.bounds.center, directionToTarget, distanceToTarget, obstructionMask))
                {
                    canSeePlayer = true;
                    lastseetarget = target.position;
                    Debug.DrawRay(CapCollider.bounds.center, directionToTarget * distanceToTarget, Color.red);
                }
                else
                {
                    Debug.DrawRay(CapCollider.bounds.center, directionToTarget * distanceToTarget, Color.white);
                    canSeePlayer = false;
                }
            }
            else
                canSeePlayer = false;
        }
        else if (canSeePlayer)
            canSeePlayer = false;
    }


    private void OnDrawGizmos()
    {
        if (Application.isPlaying)
        {

            Vector3 viewAngle01 = DirectionFromAngle(transform.eulerAngles.y, -angle / 2);
            Vector3 viewAngle02 = DirectionFromAngle(transform.eulerAngles.y, angle / 2);
            
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(transform.position, transform.position + viewAngle01 * radius);
            Gizmos.DrawLine(transform.position, transform.position + viewAngle02 * radius);

        }
    }

    private Vector3 DirectionFromAngle(float eulerY, float angleInDegrees)
    {
        angleInDegrees += eulerY;

        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }
}
