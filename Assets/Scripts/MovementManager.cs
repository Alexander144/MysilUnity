using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class MovementManager : MonoBehaviour
{
    private NavMeshAgent Agent;
    private Animator Animator;
    public bool startRunning = false;
    public Text Score;
    public bool gameIsDone = false;
    public AudioClip Orc;
    public AudioClip ScoreSound;
    // Start is called before the first frame update
    void Start()
    {
        Agent = this.GetComponent<NavMeshAgent>();
        Animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Agent.hasPath && startRunning)
        {
            Agent.SetDestination(GetRandomPoint(this.transform.position, 2f));
        }
        else
        {
            if (gameIsDone)
            {
                this.StopRunningAnimation();
            }
        }

    }

    public void GameDone(Vector3 moveToPoint)
    {
        this.startRunning = false;
        this.MoveToPoint(moveToPoint);
        this.gameIsDone = true;
    }

    public void StartRunningAnimation()
    {
        Animator.SetBool("Run", true);
    }

    public void StopRunningAnimation()
    {
        Animator.SetBool("Run", false);
    }


    public void MoveToPoint(Vector3 point)
    {
        Agent.SetDestination(point);
    }

    public static Vector3 GetRandomPoint(Vector3 center, float maxDistance)
    {
        // Get Random Point inside Sphere which position is center, radius is maxDistance
        Vector3 randomPos = Random.insideUnitSphere * maxDistance + center;

        UnityEngine.AI.NavMeshHit hit; // NavMesh Sampling Info Container

        // from randomPos find a nearest point on NavMesh surface in range of maxDistance
        UnityEngine.AI.NavMesh.SamplePosition(randomPos, out hit, maxDistance, UnityEngine.AI.NavMesh.AllAreas);

        return hit.position;
    }

    private void AddPoints(int number)
    {
        Score.text = (double.Parse(Score.text) + number).ToString();
        if (number > 0)
        {
            PointsAdded(Color.green);
        }
        else
        {
            PointsAdded(Color.red);
        }
    }

    void PointsAdded(Color color)
    {
        Score.color = color;
        this.GetComponent<SpriteRenderer>().color = color;
        StartCoroutine(PointsEndAnimation());
    }

    IEnumerator PointsEndAnimation()
    {
        yield return new WaitForSeconds(2);
        Score.color = Color.white;
        this.GetComponent<SpriteRenderer>().color = Color.white;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wine")
        {

            var audio = this.GetComponent<AudioSource>();
            audio.clip = ScoreSound;
            audio.Play();
            Destroy(other.gameObject);
            AddPoints(1);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Ball")
        {
            collision.transform.GetComponent<SphereCollider>().isTrigger = true;
            AddPoints(-1);

            var audio = this.GetComponent<AudioSource>();
            audio.clip = Orc;
            audio.Play();
        }
    }
}