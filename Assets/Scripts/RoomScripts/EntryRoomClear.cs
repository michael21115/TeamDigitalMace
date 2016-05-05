using UnityEngine;
using System.Collections;

public class EntryRoomClear : MonoBehaviour {

	float timer;
    public int direction;


	// Removes the walls that the collider touches in the main entryway
	void OnTriggerEnter (Collider collider){
		if (collider.gameObject.tag == "Wall" || collider.gameObject.tag == "Door"){
			Destroy(collider.gameObject);
		}
	}
		
	void Update () {
        // Removes the object to keep it from causing problems later
        Ray leftCheckRay = new Ray(transform.position, transform.right * -1);
        RaycastHit leftRayInfo = new RaycastHit();

        Ray rightCheckRay = new Ray(transform.position, transform.right);
        RaycastHit rightRayInfo = new RaycastHit();

        if(Physics.Raycast(leftCheckRay, out leftRayInfo, 3f))
        {
            if(leftRayInfo.collider.tag == "Outer")
            {
                transform.parent.GetComponent<RoomProperties>().doorLocations[direction] = false;
            }
        }

        if(Physics.Raycast(rightCheckRay, out rightRayInfo, 3f))
        {
            if(rightRayInfo.collider.tag == "Outer")
            {
                transform.parent.GetComponent<RoomProperties>().doorLocations[direction] = false;
            }
        }

        timer += Time.deltaTime;
		if (timer > 0.5f) {
			Destroy(gameObject);
		}
	}
}
