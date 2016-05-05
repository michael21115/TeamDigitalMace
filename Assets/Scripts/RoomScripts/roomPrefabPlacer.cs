using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class roomPrefabPlacer : MonoBehaviour {

	// Creates a list of room prefabs; assigned in the inspector
	public List<Transform> roomList = new List<Transform>();

	// Update is called once per frame
	void Update () {
        for (int i=0; i < 1; i++) {
			float randNum = Random.value;
            if (randNum < .2f && randNum > 0f) {
				Instantiate(roomList[Random.Range(0, roomList.Capacity + 1)], transform.position, Quaternion.identity);
			} else {
                Debug.Log("failed, " + randNum);
            }
        }
		// Removes the generator when rooms are complete
        Destroy(gameObject);

    }
}
