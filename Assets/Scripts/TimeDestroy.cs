using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyObject", LifeTime);
        bool isFirst=true;
        bool isSecond=true;
        if(isFirst){
        isFirst=false;
    }
    if(isSecond && isFirst!=false){
        LifeTime=20f;
        isSecond=false;
    }
        
    }

     void DestroyObject()
    {
        
            Destroy(gameObject);
    }


    public float LifeTime = 40f;
   
}
