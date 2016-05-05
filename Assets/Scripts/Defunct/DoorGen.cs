using UnityEngine;
using System.Collections;

public class DoorGen : MonoBehaviour {

	public Transform doorPrefab;
	public Vector3 generatorMove = new Vector3 (5f, 0f, 0f);
	
	// Update is called once per frame
	void Update () {
		transform.Translate(generatorMove);
	}

	void OnTriggerEnter(Collider collider){
		if (collider.tag == "Wall"){
			float doorGenRand = Random.value;
			if (doorGenRand <= .05f){
				if (collider.tag == "Wall"){
					Destroy(collider.gameObject);
				}
			}
			else if (doorGenRand <= .9f && doorGenRand >= .3f){
				if (collider.transform.rotation.eulerAngles.y >= 70f){
					Instantiate(doorPrefab, transform.position, Quaternion.Euler (0f, 90f, 0f));
					Debug.Log("Placing Horizontal Door");
				}
				else {
					Instantiate(doorPrefab, transform.position, Quaternion.identity);
					Debug.Log ("Placing Vertical Door");
				}
			}
			else {
				return;
			}
		}
		// Garantees the main entryway contains four doors
		if (collider.tag == "entryWall"){
			Instantiate(doorPrefab, transform.position, Quaternion.Euler (0f, 90f, 0f));
		}

		// removes the generator when it reaches the far end of the house
		if (collider.tag == "generatorDestroyer"){
			Destroy(gameObject);
		}
	}
}
