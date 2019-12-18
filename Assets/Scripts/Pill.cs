using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pill : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(Vector3.back,Time.deltaTime*rotateSpeed);
    }
    void OnTriggerEnter(Collider col){
        Destroy(this.gameObject);
        UIManager.Instance.IncreaseScore(100);
    }

    public float rotateSpeed=50f;
}
