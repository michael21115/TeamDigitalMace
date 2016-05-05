using UnityEngine;
using System.Collections;

public class SpikeScript : MonoBehaviour {

    [SerializeField]
    float slowSpeed;

    [SerializeField]
    float defaultSpeed;

    private PlayerController playerController;

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            col.GetComponent<PlayerController>().speed = slowSpeed;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            col.GetComponent<PlayerController>().speed = defaultSpeed;
        }
    }
}
