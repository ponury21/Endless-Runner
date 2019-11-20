using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public bool isGrounded=true;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rigidbody = transform.GetComponent<Rigidbody>();
    }
 
    void onCollisionEnter(Collision col)
    {
        if(col.gameObject.tag==("Ground")&& isGrounded == false)
        {
            isGrounded = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
        
        if(Input.GetKey(KeyCode.UpArrow))
        {
            GetComponent<Rigidbody>().AddTorque(Vector3.left*50f);
        }

        if(Input.GetKey(KeyCode.LeftArrow))
        {
            GetComponent<Rigidbody>().AddTorque(Vector3.back*50f);
        }

        if(Input.GetKey(KeyCode.RightArrow))
        {
            GetComponent<Rigidbody>().AddTorque(Vector3.forward*50f);
        }

        if(Input.GetKey(KeyCode.DownArrow))
        {
            GetComponent<Rigidbody>().AddTorque(-Vector3.left*50f);
        }

        if (Input.GetKeyDown(KeyCode.Space)&& isGrounded)
        {
            
             GetComponent<Rigidbody>().AddForce(0, 0.7f, 0, ForceMode.Impulse);
            isGrounded = false;
        }
      
        
    }
}
