using UnityEngine;
using System.Collections;

public class AccessChecker : MonoBehaviour {

    RoomProperties centerRoomProperties;
    AccessTotal totalAccess;
    string lastRoom;
    float timer;

	// Use this for initialization
	void Start () {
        centerRoomProperties = GetComponent<RoomProperties>();
        centerRoomProperties.accessible = true;
        totalAccess = GameObject.Find("RoomControllers").GetComponent<AccessTotal>();
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(lastRoom);
        //Check all availible paths from here
        if (timer < 0.5f)
        {
            timer += Time.deltaTime;
            if(timer > 0.5f)
            {
                UpdateAccess(transform);
            }
        }
        
    }

    void SpawnBombs()
    {

    }

    void UpdateAccess(Transform roomTransform)
    {
        RoomProperties room = (RoomProperties)(roomTransform.GetComponent<RoomProperties>());
        //Debug.Log(room.name);
        for (int i = 0; i < 4; i++)
        {
            //If this door is open, then move forward.
            if (room.doorLocations[i] == true && !room.doorsChecked[i])
            {
                room.doorsChecked[i] = true;
                room.accessible = true;
                string targetName = room.name;
                int x = int.Parse(targetName.Substring(16, 1));
                int y = int.Parse(targetName.Substring(20, 1));

                //Modify the x and y for the next room depending on the door direction.
                if (i == 0) y += 1; else if (i == 1) x += 1; else if (i == 2) y -= 1; else if (i == 3) x -= 1;

                //Debug.Log("AccessChecker is looking for : " + x + " , " + y);
                GameObject newRoom = GameObject.Find("RoomController (" + x + " , " + y + ")");
                RoomProperties newProperties = newRoom.GetComponent<RoomProperties>();
                //Debug.Log(newRoom.name);
                //Get the opposite index of the door
                int opposite = i + 2;
                if (opposite == 4) opposite = 0; else if (opposite == 5) opposite = 1;
                Debug.Log(room.transform.name + " " + (DoorLocations)(i) + " to " + newRoom.name);
                newProperties.doorsChecked[opposite] = true;
                if (!newProperties.accessible)
                    totalAccess.totalAccess++;
                newProperties.accessible = true;
                
                UpdateAccess(newRoom.transform);
            }
        }
    }
}
