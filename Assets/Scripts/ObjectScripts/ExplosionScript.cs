using UnityEngine;
using System.Collections;

public class ExplosionScript : MonoBehaviour {

    private float timer;

    void Start()
    {
        timer = 0;
    }

    void Update()
    {

        timer += Time.deltaTime;
        if(timer > 3f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerStay(Collider collider)
    {
        Debug.Log(collider.name);
        if (collider.gameObject.tag == "Wall" || collider.gameObject.tag == "Door")
        {
            Destroy(collider.gameObject);
        }
    }
}
