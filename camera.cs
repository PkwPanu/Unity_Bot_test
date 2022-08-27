using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class camera : MonoBehaviour
{
    public GameObject myplay;
    public float hieght, back, angle;
    private float rotateSpeed;
    Vector3 myview;
    // Start is called before the first frame update
    void Start()
    {
        hieght = 20;
        back = 10;
        angle = 60;
        rotateSpeed = 10;
        transform.localEulerAngles = new Vector3(angle, transform.eulerAngles.y, transform.eulerAngles.z);
    }

    // Update is called once per frame
    void Update()
    {
        myview = Vector3.up * hieght - Vector3.forward * back;
        transform.position = myplay.transform.position + myview;

        float diffang = myplay.GetComponent<Player_control>().relativeAngleCamera - transform.eulerAngles.y;
        if (Mathf.Abs(diffang) > 0.1)
        {
            if (diffang > 0)
            {
                transform.localEulerAngles = new Vector3(transform.eulerAngles.x,
                                                  transform.eulerAngles.y + Time.deltaTime * rotateSpeed, transform.eulerAngles.z);
            }
            else
            {
                transform.localEulerAngles = new Vector3(transform.eulerAngles.x,
                                              transform.eulerAngles.y - Time.deltaTime * rotateSpeed, transform.eulerAngles.z);
            }
        }
        else
        {
            transform.localEulerAngles = new Vector3(transform.eulerAngles.x, myplay.GetComponent<Player_control>().relativeAngleCamera
                                              , transform.eulerAngles.z);
        }


       
    }
}
