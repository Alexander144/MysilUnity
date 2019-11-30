using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Ship : MonoBehaviour
{
    public List<Cannon> Cannons;
    public List<GameObject> Players;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return))
        {
            var random = new System.Random();
            int index = random.Next(Cannons.Count);
            int peopleIndex = random.Next(Players.Count);
            Cannons[index].Shoot(Players[peopleIndex].transform.position);
        }
    }
}
