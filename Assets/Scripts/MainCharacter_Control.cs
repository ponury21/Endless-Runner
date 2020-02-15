using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainCharacter_Control : MonoBehaviour
{
    public CharacterController characterControler;
    public Vector3 moveDir = new Vector3(0,0,0);
    //public Vector3 xde = new Vector3(0, 0, -1);
    public float predkoscporuszania = 100f;
    public bool isGrounded=true;
    public bool canJump=true;
    public int i=0;
    public int dTime=0;
    public float moveSpeed=0f;
    public float sideSpeed=0f;
    public int pauza = 0;

    public float isPressedR = 1;
    public float isPressedL = 1;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rigidbody = transform.GetComponent<Rigidbody>();
        characterControler = GetComponent<CharacterController>();
        UIManager.Instance.ResetScore();
        moveDir = characterControler.transform.position;

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
        
        float x=0;
        float z=0;
        if (pauza == 0)
        {
            characterControler.Move(new Vector3(0, 0, -1) * predkoscporuszania * 10 * Time.deltaTime);
            x = Input.GetAxis("Horizontal");
            z = Input.GetAxis("Vertical");
        }

        //float x = Input.GetAxis("Horizontal");
        //float z = Input.GetAxis("Vertical");

        
        if (characterControler.transform.position.x < -3 && characterControler.transform.position.x > -14)
        {

            Vector3 move = transform.right * x + transform.forward * z;
            characterControler.Move(move * predkoscporuszania * 10 * Time.deltaTime);


        }
        if (characterControler.transform.position.x > -3)
        {
            characterControler.Move(new Vector3(-0.1f, 0, 0));
        }

        if (characterControler.transform.position.x < -14)
        {
            characterControler.Move(new Vector3(0.1f, 0, 0));
        }



        switch (GameManager.Instance.GameState){
            
            case GameState.Playing:

            UIManager.Instance.SetStatus("Status: Playing");

            //GetComponent<Rigidbody>().AddTorque(Vector3.left*moveSpeed);
            if(Input.GetKeyDown(KeyCode.Escape)){
                GameManager.Instance.Pause();
            }

            if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
                {
                    Input.ResetInputAxes();
                }


                //klawiatura();

                i++;
                if(i==60){UIManager.Instance.IncreaseScore(1); i=0;}

            break;

            case GameState.Pause:

            UIManager.Instance.SetStatus("Status: Pause");

                pauza = 1;

                if(Input.GetKeyDown(KeyCode.Escape)){


                    GameManager.Instance.Play();
                    pauza = 0;
            }
                break;

            case GameState.Dead:

            UIManager.Instance.SetStatus("Status: Dead");

                characterControler.transform.position = moveDir;

                break;
        }
    }



}
