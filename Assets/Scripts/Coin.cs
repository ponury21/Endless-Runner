using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(Vector3.up,Time.deltaTime*rotateSpeed);
        transform.Rotate(Vector3.forward,Time.deltaTime*rotateSpeed);
    } 
    public float rotateSpeed=50f;
    
    void OnTriggerEnter(Collider col){
        Destroy(this.gameObject);
        UIManager.Instance.IncreaseScore(500);
    }
}
