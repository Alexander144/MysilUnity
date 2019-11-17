using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
            if (Random.Range(0f, 100f)>80f)
            {         
                Instantiate(WineBottle, SpawningPoint.position + new Vector3(Random.Range(-5f, 5f), 5f, Random.Range(-5f, 5f)), Quaternion.identity);
            }
        }
    }
}
