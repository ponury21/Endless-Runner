using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacter_Control : MonoBehaviour
{
    public bool isGrounded=true;
    public bool canJump=true;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rigidbody = transform.GetComponent<Rigidbody>();
    }
 
    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag==("Ground")&& isGrounded == false)
        {
            isGrounded = true;
        }
    }
    void OnCollisionExit(Collision col){isGrounded=false;}
    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody>().AddTorque(Vector3.left*100f); //ruch do przodu
    
        

        if(Input.GetKey(KeyCode.LeftArrow))
        {
            GetComponent<Rigidbody>().AddTorque(Vector3.back*50f);
        }

        if(Input.GetKey(KeyCode.RightArrow))
        {
            GetComponent<Rigidbody>().AddTorque(Vector3.forward*50f);
        }

        if (Input.GetKey(KeyCode.Space)&& isGrounded)
        {
             GetComponent<Rigidbody>().AddForce(0, 5f, 0, ForceMode.Impulse);
        }
      
        
    }
}
