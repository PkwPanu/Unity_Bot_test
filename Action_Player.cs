using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_Player : MonoBehaviour
{
  
    Rigidbody rb;
    [SerializeField] GameObject Skill1;
    [SerializeField] GameObject MouseObject;

    public float Force;
 
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //Camera = GameObject.Find("Door_collider");
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            //Debug.Log("update1");
            //if (enemy_rb != null)
            StartCoroutine(skill1_functionIE());
            //Debug.Log("update2");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("enemy");
            //enemy_rb = other.gameObject.GetComponent<Rigidbody>();

        }

        if (other.gameObject.tag == "bullet")
            Debug.Log("Damage");
        {
            GetComponent<Player_control>().Health -= 10f;
        }

    }

    void OnTriggerExit(Collider other)
    {
        //enemy_rb = null;
       
    }
    
   

    IEnumerator skill1_functionIE()
    {
        Vector3 direction = MouseObject.transform.position- transform.position;
        transform.rotation = Quaternion.LookRotation(direction);
        yield return new WaitForSeconds(0.5f);
        GameObject skill = Instantiate(Skill1, transform.position, Quaternion.identity);
        skill.GetComponent<Rigidbody>().velocity = transform.forward * 50;
        yield return new WaitForSeconds(1);
        Destroy(skill);
    }

}
