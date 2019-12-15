using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Gamemanager : MonoBehaviour
{

    public List<MovementManager> Persons;
    public SpawnManager SpawnManager;
    public Text Countdown;
    private System.TimeSpan time;
    public Transform Winnerspot;
    public Transform Loserspot;
    private bool startGame = false;
    public List<GameObject> Players;
    public List<GameObject> Points;
    private bool gameover = false;

    // Start is called before the first frame update
    void Start()
    {
        time = System.TimeSpan.FromSeconds(120);
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
        if (startGame)
        {
            time = time.Subtract(System.TimeSpan.FromSeconds(Time.deltaTime));
            Countdown.text = time.Minutes + ":" + time.Seconds;
        }
        if (time <= System.TimeSpan.Zero && !gameover)
        {
            this.GetComponent<AudioSource>().Stop();
            startGame = false;
            gameover = true;
            SpawnManager.StartSpawnWineBottles = false;
            var bottles = GameObject.FindGameObjectsWithTag("Wine");
            foreach (var bottle in bottles)
                Destroy(bottle);

            var higgestPoint = ((Points.Select(point => int.Parse(point.transform.Find("Points").GetComponent<Text>().text))).ToArray()).Max();
            var bestPoints = Points.FindAll(point => double.Parse(point.transform.Find("Points").GetComponent<Text>().text) >= higgestPoint);
            var worstPoints = Points.FindAll(point => double.Parse(point.transform.Find("Points").GetComponent<Text>().text) < higgestPoint);
            var bestPersons = Players.FindAll(player => bestPoints.Find(point => point.name == player.name));
            var loserPersons = Players.FindAll(player => worstPoints.Find(point => point.name == player.name));

            MovePlayers(Winnerspot.transform.position + new Vector3(Random.Range(-1f, 1f), 0, 0), bestPersons);
            MovePlayers(Loserspot.transform.position + new Vector3(Random.Range(-1f, 1f), 0, 0), loserPersons);
            if (bestPersons.Count > 1)
            {
                loserPersons.ForEach(person => Destroy(person.transform.gameObject));
                Players.RemoveAll(player => player == null);                
                Points.ForEach(point => point.transform.Find("Points").GetComponent<Text>().text = "0");
            }
            //bestPersons.ForEach(person => { var mvPerson = person.GetComponent<MovementManager>(); mvPerson.GameDone(Winnerspot.transform.position); });
            //loserPersons.ForEach(person => { var mvPerson = person.GetComponent<MovementManager>(); mvPerson.GameDone(Loserspot.transform.position); });
        }
    }

    private void MovePlayers(Vector3 position, List<GameObject> persons)
    {
        foreach (var person in persons)
        {
            if (person) {
                var mvPerson = person.GetComponent<MovementManager>();
                mvPerson.GameDone(position);
            }
        }
    }

    public void StartGame()
    {
        Debug.Log("Start");
        Persons.ForEach(person => { if (person) { person.startRunning = true; person.StartRunningAnimation(); } });
        SpawnManager.StartSpawnWineBottles = true;
        startGame = true;
        this.GetComponent<AudioSource>().Play();
    }
}
