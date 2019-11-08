using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{

    public List<MovementManager> Persons;
    public SpawnManager SpawnManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "Start")
                {
                    StartGame();
                }
            }
        }
    }

    public void StartGame()
    {
        Debug.Log("Start");
        Persons.ForEach(person => { person.startRunning = true; person.StartRunningAnimation(); });
        SpawnManager.StartSpawnWineBottles = true;
    }
}
