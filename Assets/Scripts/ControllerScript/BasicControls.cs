using UnityEngine;
using System.Collections;

public class BasicControls : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        //Debug.Log(horizontal);
        Vector3 movement = new Vector3(horizontal, 0, vertical) * 10;
        //transform.position += movement * Time.deltaTime;
        transform.position = new Vector3(
                Mathf.Clamp(transform.position.x + (movement.x * Time.deltaTime), -60, 60),
                Mathf.Clamp(transform.position.y + (movement.y * Time.deltaTime), 0, 10),
                Mathf.Clamp(transform.position.z + (movement.z * Time.deltaTime), -36, 36)
            );
	}
}
