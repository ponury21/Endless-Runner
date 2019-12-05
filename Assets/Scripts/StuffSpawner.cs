using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StuffSpawner : MonoBehaviour
{

    public Transform[] StuffSpawnPoints;
    public GameObject[] Bonus;
    public float minX = -2f, maxX = 2f;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < StuffSpawnPoints.Length; i++)
        {
            
            if (Random.Range(0, 2) == 0) //33% chances to create candy
            {
                CreateObject(StuffSpawnPoints[i].position, Bonus[Random.Range(0, Bonus.Length)]);
            }
        }
    }
    void CreateObject(Vector3 position, GameObject prefab)
    {
            position += new Vector3(Random.Range(minX, maxX), 0, 0);

        Instantiate(prefab, position, Quaternion.identity);
    }
    // Update is called once per frame
    
}
