using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kamera : MonoBehaviour
{

    public Transform sfera;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 wektor = new Vector3(0, 20, 100);
        Rigidbody rigidbody = sfera.GetComponent<Rigidbody>();
        float velocity = rigidbody.velocity.sqrMagnitude;
        wektor = wektor * (1 + velocity / 100);
        transform.position = Vector3.Lerp(sfera.position, sfera.position + wektor,0.1f);
        transform.LookAt(sfera);
    }
}
