using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using UnityEngine.AI;

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
            var validPlayers = Players.Where(player => player.GetComponent<NavMeshAgent>().enabled == true).ToList();
            int peopleIndex = random.Next(validPlayers.Count);
            Cannons[index].Shoot(validPlayers[peopleIndex].transform.position);
        }
    }
}
