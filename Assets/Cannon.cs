using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public ParticleSystem Flash;
    public ParticleSystem Smoke;
    public GameObject Ball;

    public void Shoot(Vector3 Position)
    {
        var ball = Instantiate(Ball, this.transform.position, Quaternion.identity);
        ball.GetComponent<Ball>().Target = Position;
        var rigid = ball.GetComponent<Rigidbody>();
        rigid.AddForce(new Vector3(0f, 500f, 0f));
        Flash.Play();
        Smoke.Play();
        this.GetComponent<AudioSource>().Play();
    }
}
