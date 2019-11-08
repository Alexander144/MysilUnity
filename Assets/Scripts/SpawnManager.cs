using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    public bool StartSpawnWineBottles = false;
    public Transform SpawningPoint;
    public GameObject WineBottle;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (StartSpawnWineBottles)
        {
            Instantiate(WineBottle, SpawningPoint.position + new Vector3(Random.Range(-5f, 5f), 5f, Random.Range(-5f, 5f)), Quaternion.identity);
        }
    }
}
