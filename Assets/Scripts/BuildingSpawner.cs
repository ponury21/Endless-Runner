using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSpawner : MonoBehaviour
{
    public GameObject[] Building;
    public Transform[] BuildingSpawnPoints;
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0;i<BuildingSpawnPoints.Length;i++){
            CreateObject(BuildingSpawnPoints[i].position, Building[Random.Range(0, Building.Length)]);
        }
    }

    void CreateObject(Vector3 position, GameObject prefab)
    {
        Instantiate(prefab, position, Quaternion.identity);
    }
}
