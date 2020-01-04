using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StuffSpawner : MonoBehaviour
{

    public Transform[] StuffSpawnPoints;
    public GameObject[] Bonus;

    public GameObject[] Obstacle;
    public float minX = -2f, maxX = 2f;
    // Start is called before the first frame update
    void Start()
    {
       // bool placeObstacle=Random.Range(0,2)==0;
       // int obstacleIndex=-1;
       // if(placeObstacle){
       //     obstacleIndex=Random.Range(1,StuffSpawnPoints.Length);
       //     CreateObject(StuffSpawnPoints[obstacleIndex].position,Obstacle[Random.Range(0,Obstacle.Length)]);
       // }

        for (int i = 0; i < StuffSpawnPoints.Length; i++)
        {
           // if (i == obstacleIndex) continue;
            if (Random.Range(0, 2) == 0) //33% chances to create candy
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
