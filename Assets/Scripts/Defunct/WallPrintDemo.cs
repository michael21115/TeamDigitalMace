using UnityEngine;
using System.Collections;

public class WallPrintDemo : MonoBehaviour {

    [SerializeField]
    Transform wallPrefab;

    [SerializeField]
    Transform doorPrefab;

    //Counter controllers
    int counter = 0;
    int rotateCounter = 0;
    int columnCounter = 0;
    int completeCounter = 0;

    //Map size
    int mapWidth = 5;
    int mapLength = 5;

    //Room variables
    int roomWidth = 5;
    int romLength = 5;

	// Use this for initialization
	void Start () {
        spawnMap(5, 5);
	}
	
	// Update is called once per frame
	void Update () {
       
	}

    //Spawn map of width n and length m
    public void spawnMap(int width, int length)
    {
        spawnLeftMostColumn(5);
        transform.position += transform.right * 2 * roomWidth;
        transform.position += transform.forward * -2 * length * roomWidth;
        while(width > 1)
        {
            spawnColumn(length);
            transform.position += transform.right * 2 * roomWidth;
            transform.position += transform.forward * -2 * length * roomWidth;
            width--;
        }
    }
    
    //Spawn a full column
    public void spawnColumn(int length)
    {
        spawnLeftMissingRoom(1, 1);
        transform.position += transform.forward * 2 * roomWidth;

        int counter = 1;
        while(counter < length)
        {
            spawnHalfMissingRoom(1, 1);
            transform.position += transform.forward * 2 * roomWidth;
            counter++;
        }
    }

    //Creates the left most column of the map. Length is the length of the column.
    public void spawnLeftMostColumn(int length)
    {
        spawnFullRoom(1, 1);
        transform.position += transform.forward * 2 * roomWidth;

        int counter = 1;
        while(counter < length)
        {
            spawnBottomMissingRoom(1, 1);
            transform.position += transform.forward * 2 * roomWidth;
            counter++;
        }
    }

    //Identical to spawnFullRoom, but doesn't spawn the left side.
    public void spawnLeftMissingRoom(int width, int length)
    {
        width *= 5;
        length *= 5;
        transform.position += transform.forward * length * 2;
        transform.eulerAngles += new Vector3(0, 90, 0);
        spawnWall(width);
        transform.eulerAngles += new Vector3(0, 90, 0);
        spawnWall(length);
        transform.eulerAngles += new Vector3(0, 90, 0);
        spawnWall(width);
        transform.eulerAngles += new Vector3(0, 90, 0);
    }

    //Identical to spawnFullRoom, but doesn't spawn the bottom.
    public void spawnBottomMissingRoom(int width, int length)
    {
        width *= 5;
        length *= 5;
        spawnWall(length);
        transform.eulerAngles += new Vector3(0, 90, 0);
        spawnWall(width);
        transform.eulerAngles += new Vector3(0, 90, 0);
        spawnWall(length);
        transform.eulerAngles += new Vector3(0, 90, 0);
        transform.position += transform.forward * length * 2;
        transform.eulerAngles += new Vector3(0, 90, 0);
    }

    //Identical to spawnFullRoom, but doesnt spawn the left or bottom so we don't have duplicate walls.
    public void spawnHalfMissingRoom(int width, int length)
    {
        width *= 5;
        length *= 5;
        transform.position += transform.forward * length * 2;
        transform.eulerAngles += new Vector3(0, 90, 0);
        spawnWall(width);
        transform.eulerAngles += new Vector3(0, 90, 0);
        spawnWall(length);
        transform.eulerAngles += new Vector3(0, 90, 0);
        transform.position += transform.forward * length * 2;
        transform.eulerAngles += new Vector3(0, 90, 0);
    }

    //Note: using grid units. So 1 width is 5 walls wide, or 10 units
    public void spawnFullRoom(int width, int length)
    {
        width *= 5;
        length *= 5;
        spawnWall(length);
        transform.eulerAngles += new Vector3(0, 90, 0);
        spawnWall(width);
        transform.eulerAngles += new Vector3(0, 90, 0);
        spawnWall(length);
        transform.eulerAngles += new Vector3(0, 90, 0);
        spawnWall(width);
        transform.eulerAngles += new Vector3(0, 90, 0);

    }

    //Spawn a wall that length with a door.
    public void spawnWallWithDoor(int length)
    {
        while(length > 0)
        {
            Transform temp = Instantiate(wallPrefab, transform.position, transform.rotation) as Transform;
            transform.position += transform.forward* 2;
            length--;
        }
    }

    //Spawns a wall that length.
    public void spawnWall(int length)
    {
        //float doorChance = 0.2f;
        while(length > 0)
        {
            float randomNumber = Random.value;
            Transform temp = Instantiate(wallPrefab, transform.position, transform.rotation) as Transform;
            transform.position += transform.forward * 2;
            length--;
        }
    }
}
