using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainCharacter_Control : MonoBehaviour
{
    public bool isGrounded=true;
    public bool canJump=true;
    public int i=0;
    public int dTime=0;
    public float moveSpeed=0f;
    public float sideSpeed=0f;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rigidbody = transform.GetComponent<Rigidbody>();
        UIManager.Instance.ResetScore();
        //GameManager.Instance.Play();
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
         //ruch do przodu
                
        switch(GameManager.Instance.GameState){
            
            case GameState.Playing:

            UIManager.Instance.SetStatus("Status: Playing");

            GetComponent<Rigidbody>().AddTorque(Vector3.left*moveSpeed);
            if(Input.GetKeyDown(KeyCode.Escape)){
                GameManager.Instance.Pause();
            }
            if(Input.GetKey(KeyCode.LeftArrow))
                 {
                    GetComponent<Rigidbody>().AddTorque(Vector3.back*sideSpeed);
                 }

                if(Input.GetKey(KeyCode.RightArrow))
                {
                     GetComponent<Rigidbody>().AddTorque(Vector3.forward*sideSpeed);
                 }

                 if (Input.GetKey(KeyCode.Space)&& isGrounded)
                    {
                     GetComponent<Rigidbody>().AddForce(0, 5f, 0, ForceMode.Impulse);
                }

                i++;
                if(i==60){UIManager.Instance.IncreaseScore(1); i=0;}

            break;

            case GameState.Pause:

            UIManager.Instance.SetStatus("Status: Pause");

                GetComponent<Rigidbody>().velocity*=0.9f;
                GetComponent<Rigidbody>().angularVelocity*=0.9f;

                if(Input.GetKeyDown(KeyCode.Escape)){
                GameManager.Instance.Play();
            }
                break;

            case GameState.Dead:

            UIManager.Instance.SetStatus("Status: Dead");
            
                GetComponent<Rigidbody>().velocity*=0.9f;
                GetComponent<Rigidbody>().angularVelocity*=0.9f;

                break;
        }
    }
}
