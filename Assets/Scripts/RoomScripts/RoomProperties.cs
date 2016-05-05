using UnityEngine;
using System.Collections;

public enum DoorLocations { North, East, South, West };

public class RoomProperties : MonoBehaviour {

    /* Door Locations
        0 : North
        1 : East
        2 : South
        3 : West
    */
    [SerializeField]
    Transform furniturePlacerPrefab;
   
    public bool[] doorLocations;
    public bool[] wallDestruction;
    public bool[] doorsChecked;
    public string type;
    public bool accessible = false;
    public bool furniture = true;

    float timer = 0;
    int numberOfDoors = 0;

    [SerializeField]
    Transform roomPrinter;

	// Use this for initialization
	void Start () {
        doorsChecked = new bool[4];

        //Count the number of set doors in this room
        foreach(bool isDoor in doorLocations)
        {
            if (isDoor)
                numberOfDoors++;
        }
        //If there are no set doors, we need to randomly generate all of them.
        if(numberOfDoors == 0)
        {
            //Add one door then a second.
            while(numberOfDoors < 2)
            {
                int randomNumber = (int)(Random.value * 4.99f);
                if (randomNumber >= 4)
                {
                    randomNumber = (int)(Random.value * 3.99f);
                    if (!wallDestruction[randomNumber])
                    {
                        wallDestruction[randomNumber] = true;
                        doorLocations[randomNumber] = true;
                        numberOfDoors++;
                    }
                }
                else if (randomNumber <= 3) {    
                    if (!doorLocations[randomNumber])
                    {
                        doorLocations[randomNumber] = true;
                        numberOfDoors++;
                    }
                }
            }
        }
        //If there is only one set door, we need to randomly generate one more.
        else if(numberOfDoors == 1)
        {
            //Add one door
            while (numberOfDoors < 2)
            {
                int randomNumber = (int)(Random.value * 4.99f);
                if (randomNumber >= 4)
                {
                    randomNumber = (int)(Random.value * 3.99f);
                    if (!wallDestruction[randomNumber])
                    {
                        wallDestruction[randomNumber] = true;
                        doorLocations[randomNumber] = true;
                        numberOfDoors++;
                    }
                }
                else if (randomNumber <= 3)
                {    
                    if (!doorLocations[randomNumber])
                    {
                        doorLocations[randomNumber] = true;
                        numberOfDoors++;
                    }
                }
            }
        }
        //If there are 2 or more, we don't need to add any more doors.

        //Instantiate room printer.
        Transform printer = Instantiate(roomPrinter, transform.position, transform.rotation) as Transform;
        printer.transform.parent = transform;
	}
	
	// Update is called once per frame
	void Update () {

        //Update how many doors are in this room.
        Ray northRay = new Ray(transform.position, transform.forward);
        RaycastHit northRayInfo = new RaycastHit();

        Ray eastRay = new Ray(transform.position, transform.right);
        RaycastHit eastRayInfo = new RaycastHit();

        Ray southRay = new Ray(transform.position, -transform.forward);
        RaycastHit southRayInfo = new RaycastHit();

        Ray westRay = new Ray(transform.position, -transform.right);
        RaycastHit westRayInfo = new RaycastHit();

        float checkRange = 10f;

        if(Physics.Raycast(northRay, out northRayInfo, checkRange))
        {
            if(northRayInfo.collider.tag == "Door")
            {
                doorLocations[(int)(DoorLocations.North)] = true;
            }
            else if (northRayInfo.collider.tag == "Wall")
            {
                doorLocations[(int)(DoorLocations.North)] = false;
            }
        }

        if (Physics.Raycast(eastRay, out eastRayInfo, checkRange))
        {
            if (eastRayInfo.collider.tag == "Door")
            {
                doorLocations[(int)(DoorLocations.East)] = true;
            }
            else if (eastRayInfo.collider.tag == "Wall")
            {
                doorLocations[(int)(DoorLocations.East)] = false;
            }
        }

        if (Physics.Raycast(southRay, out southRayInfo, checkRange))
        {
            if (southRayInfo.collider.tag == "Door")
            {
                doorLocations[(int)(DoorLocations.South)] = true;
            }
            else if (southRayInfo.collider.tag == "Wall")
            {
                doorLocations[(int)(DoorLocations.South)] = false;
            }
        }

        if (Physics.Raycast(westRay, out westRayInfo, checkRange))
        {
            if (westRayInfo.collider.tag == "Door")
            {
                doorLocations[(int)(DoorLocations.West)] = true;
            }
            else if (westRayInfo.collider.tag == "Wall")
            {
                doorLocations[(int)(DoorLocations.West)] = false;
            }
        }

        //When timer reaches a certain point place furniture.
        if (!furniture)
        {
            if (timer < 1f)
            {
                timer += Time.deltaTime;
                if (timer > 1f)
                {
                    Instantiate(furniturePlacerPrefab, transform.position, transform.rotation);
                }
            }
        }
    }
}
