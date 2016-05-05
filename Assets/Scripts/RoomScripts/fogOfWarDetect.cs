using UnityEngine;
using System.Collections;

public class fogOfWarDetect : MonoBehaviour {

	public GameObject roomLight;

//	void Start(){
//		// Randomizes lights on/off at the start of the game
//		float lightCheck = Random.value;
//		if (lightCheck <= .9f){
//			roomLight.SetActive(false);
//		}
//		else {
//			roomLight.SetActive(true);
//		}
//	}
//
//	// Randomly turn lights off
//	void Update () {
//		float flickerCheck = Random.value;
//		if (flickerCheck <= .0005f){
//			if (roomLight.activeInHierarchy){			
//				roomLight.SetActive(false);
//			}
// 			//TURN ON LIGHTS RANDOMLY
//			else if (roomLight.activeInHierarchy == false){
//				roomLight.SetActive(true);
//			} 
//			// ... or else nothing happens
//			else {
//				return;
//			}
//		}
//	}

	// FOG OF WAR ACTIVATION
	// very simple player detection
	void OnTriggerStay (Collider collider){
		// if an object with the player tag enters a room
		if (collider.tag == "Player"){
			//Debug.Log("Yes, it's a player");
			// turn on the lights
			roomLight.SetActive(true);
		}
	}

	// if an object with the player tag leaves the room
	void OnTriggerExit(Collider collider){
		if (collider.tag == "Player"){
			// turn off the lights
			roomLight.SetActive(false);
		} 
	}
}
