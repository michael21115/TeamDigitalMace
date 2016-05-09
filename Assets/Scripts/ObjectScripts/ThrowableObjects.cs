using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent (typeof (Rigidbody))]

public class ThrowableObjects : MonoBehaviour {

    float waitTime = 0.2f;
    float currTime = 0f;

    public float mass;
    Rigidbody thisRB;

    public string pointGoesTo;

    void Start ()
    {
        thisRB = GetComponent<Rigidbody>();
        mass = thisRB.mass;
    }

	// Update is called once per frame
	void Update ()
    {
        if (thisRB.velocity.magnitude > 1f)
        {
            gameObject.tag = "Projectile";
        }
        else
        {
            gameObject.tag = "Grabby Thing";
        }
    }

    void OnCollisionEnter (Collision other)
    {
        if (other.collider.name.Contains("Player"))
        {
            pointGoesTo = other.gameObject.name;
        }
    }
}
