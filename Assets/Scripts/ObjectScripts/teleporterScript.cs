using UnityEngine;
using System.Collections;

public class teleporterScript : MonoBehaviour {

    void OnTriggerEnter (Collider collider)
    {
        if (collider.tag == "Player")
        {
            Debug.Log(collider.tag);
            int randCoordHeight = Random.Range(0, 4);
            int randCoordWidth = Random.Range(0, 3);
            Debug.Log(randCoordHeight + "," + randCoordWidth);
            GameObject destination = GameObject.Find("RoomController (" + randCoordHeight.ToString() + " , " + randCoordWidth.ToString() + ")");
            collider.transform.position = destination.transform.position + Vector3.up;
        }
    }
}
