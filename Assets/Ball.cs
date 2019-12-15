using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Vector3 Target;
    private Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Target != Vector3.zero)
        {
            var direction = Target - transform.position;
            rigidbody.MovePosition(transform.position + direction * Time.deltaTime);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "MovementPlane")
        {
            this.GetComponent<SphereCollider>().isTrigger = true;
        }
    }
    }
