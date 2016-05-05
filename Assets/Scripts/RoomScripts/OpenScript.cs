using UnityEngine;
using System.Collections;

public class OpenScript : MonoBehaviour
{

    private bool open = false;
    private Vector3 openPosition, closedPosition;
    private float timer;

    void Start ()
    {
        closedPosition = transform.position;
        openPosition = transform.position - transform.forward * 3;
        timer = 2.1f;
    }

	// Update is called once per frame
	void Update () {
		if (open) {
			transform.position = Vector3.Lerp (transform.position, openPosition, 0.15f);
			if (timer < 2f) {
                timer += Time.deltaTime;
				if (timer > 2f) {
                    open = false;
                }
            }
        }

		if (!open) {
			transform.position = Vector3.Lerp (transform.position, closedPosition, 0.15f);
       
    }
	}

	void OnTriggerStay (Collider collider){
        //Debug.Log(collider.tag);
		if (collider.tag == "Player") {
            open = true;
            timer = 0;
        }
	}
}
