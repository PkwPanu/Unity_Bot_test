using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_chaseVer2 : MonoBehaviour
{
    public float gotoArea;
    public bool gocheck;
    private Vector3 Direction;
    bool cooldown = false;
    [SerializeField] GameObject Skill1;
    AI_control AI_Control;
    private Vector3 lastPosition;
   

    // Start is called before the first frame update
    void Start()
    {
        AI_Control = GetComponent<AI_control>();
        gotoArea = 5f;
    }

    // Update is called once per frame

    void Update()
    {
        lastPosition = GetComponent<FieldOfView>().lastseetarget;
        go2LastPosiiton(); 
    }

    private void go2LastPosiiton()
    {
        float dis = Vector3.Distance(lastPosition, transform.position);
        if (dis > gotoArea)
        {
            Direction = (lastPosition - transform.position).normalized;
            rotate(Direction);
            AI_Control.move();   
        }
        else if (GetComponent<FieldOfView>().canSeePlayer)
        {
            if(!cooldown)
            StartCoroutine(skill1_functionIE());
        }
        else
        {
            gocheck = true;
            this.enabled=false;
        }
    }

    private void rotate(Vector3 direction)
    {
        transform.rotation = Quaternion.LookRotation(direction);
    }

    IEnumerator skill1_functionIE()
    {
        cooldown = true;
        Vector3 direction = GetComponent<FieldOfView>().lastseetarget - transform.position;
        transform.rotation = Quaternion.LookRotation(direction);
        GameObject skill = Instantiate(Skill1, transform.position, Quaternion.identity);
        skill.GetComponent<Rigidbody>().velocity = transform.forward * 10;
        yield return new WaitForSeconds(5);
        Destroy(skill);
        cooldown = false;
    }

}
