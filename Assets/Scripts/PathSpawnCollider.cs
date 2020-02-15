using UnityEngine;
using System.Collections;

public class PathSpawnCollider : MonoBehaviour {

    public float positionY = 0.81f;
    public Transform[] PathSpawnPoints;
    public GameObject Path;

    void OnTriggerEnter(Collider hit)
    {
        //player has hit the collider
        if (hit.gameObject.tag == "Player")
        {
            
            for (int i = 0; i < PathSpawnPoints.Length; i++)
            {
                    Instantiate(Path, PathSpawnPoints[i].position, PathSpawnPoints[i].rotation);
            }
            
        }
    }

}
