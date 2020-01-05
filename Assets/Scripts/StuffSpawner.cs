using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StuffSpawner : MonoBehaviour
{

    public Transform[] StuffSpawnPoints;
    public GameObject[] Bonus;

    public GameObject[] Obstacle;
    public float minX = -2f, maxX = 2f;
    void Start()
    {
       

        for (int i = 0; i < StuffSpawnPoints.Length; i++)
        {
            if (Random.Range(0, 2) == 0) 
            {
                CreateObject(StuffSpawnPoints[i].position, Bonus[Random.Range(0, Bonus.Length)]);
            }
            else if (Random.Range(0,2)==1)
            {
                CreateObject(StuffSpawnPoints[i].position,Obstacle[Random.Range(0,Obstacle.Length)]);
            }
        }
    }
    void CreateObject(Vector3 position, GameObject prefab)
    {
            position += new Vector3(Random.Range(minX, maxX), 0, 0);

        Instantiate(prefab, position, Quaternion.identity);
    }
    
    
}
