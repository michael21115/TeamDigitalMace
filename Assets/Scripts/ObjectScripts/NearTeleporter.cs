using UnityEngine;
using System.Collections;

public class NearTeleporter : MonoBehaviour {

    bool nearTeleporter = false;

	// Update is called once per frame
	void Update ()
    {
        var isEmitting = GetComponent<ParticleSystem>().emission;

        isEmitting.enabled = nearTeleporter;
    }

    void OnTriggerEnter (Collider other)
    {
        if (other.tag == "Player")
        {
            nearTeleporter = true;
            GetComponent<ParticleSystem>().startColor = other.GetComponent<PlayerController>().playerColor;
        }
    }

    void OnTriggerExit (Collider other)
    {
        if (other.tag == "Player")
        {
            nearTeleporter = false;
        }
    }
}
