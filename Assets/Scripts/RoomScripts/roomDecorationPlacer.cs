using UnityEngine;
using System.Collections;

public class roomDecorationPlacer : MonoBehaviour {
    
    Vector3 pos;
    int counter;

    [SerializeField] Transform[] furniture;
    [SerializeField]
    Transform teleporter;
    [SerializeField] Transform blueprint;
    [SerializeField] float totalChance;
    [SerializeField]
    int maxFurniture;

    private float uniformChance;
    private float currentChance;

    private Transform defaultParent;

	void SpawnObject(Object furniture) {
		Transform temp = (Transform)Instantiate(furniture, pos, Quaternion.Euler(0f, Random.Range(0f, 360f), 0f));
        temp.transform.parent = defaultParent;
        counter--;
	}

    // Use this for initialization
    void Start()
    {
        counter = maxFurniture;
        defaultParent = GameObject.Find("Furniture").transform;
        uniformChance = totalChance / furniture.Length;
        //Debug.Log(uniformChance);
        currentChance = uniformChance;
        for (int x = -1; x < 2; x++) //this creates a 9x9 square area where objects can spawn
        {
            for (int z = -1; z < 2; z++)
            {
                pos = new Vector3(x * 2, 0, z * -2) + blueprint.transform.position;  
                float randomNumber = Random.Range(0.0f, 1.0f);
                currentChance = uniformChance;
                //New Loop to generate furniture. Allows for more furniture to be added.
                foreach(Transform obj in furniture)
                {
                    //Debug.Log(currentChance);
                    if (randomNumber < currentChance && counter > 0)
                    {
                        currentChance = uniformChance;
                        pos.y = obj.transform.position.y;
                        SpawnObject(obj);
                        counter--;
                        break;
                    }
                    else
                    {
                        currentChance += uniformChance;
                    }
                    randomNumber = Random.Range(0.0f, 1.0f);
                    if (randomNumber < 0.005f)
                    {
                        pos.y = teleporter.transform.position.y;
                        SpawnObject(teleporter);
                    }
                }
                if (counter == 0) //this ensures that only a max of around 4-5 objects spawn. 0 objects spawned is also possible
                {
                    Destroy(gameObject);
                    break;
                }

            }
        }
        Destroy ( gameObject ); //destroy the placer after job is done
    }
}
