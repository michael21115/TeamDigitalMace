using UnityEngine;
using System.Collections;

public class DeleteSelf : MonoBehaviour {

    [SerializeField]
    Transform doorPrefab;

    [SerializeField]
    Transform wallPrefab;

    float timer;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Ray leftCheckRay = new Ray(transform.position, transform.right * -1);
        RaycastHit leftRayInfo = new RaycastHit();
        
        Ray rightCheckRay = new Ray(transform.position, transform.right);
        RaycastHit rightRayInfo = new RaycastHit();
        
        if(Physics.Raycast(leftCheckRay, out leftRayInfo, 3f))
        {
            if(leftRayInfo.collider.tag == "Wall")
            {
                Destroy(leftRayInfo.collider.gameObject);
                Vector3 spawnRotation = transform.parent.rotation.eulerAngles;
                spawnRotation.y += 180;
                Vector3 spawnPosition = transform.parent.position - (transform.parent.forward * 2) - (transform.parent.right * 0.5f);
                Transform temp = Instantiate(doorPrefab, spawnPosition, Quaternion.Euler(spawnRotation)) as Transform;
                temp.position += transform.right * -0.5f;
                temp.transform.parent = transform.parent;
            }
			if(leftRayInfo.collider.tag == "Outer")
            {
                Transform temp = Instantiate(wallPrefab, transform.parent.position, transform.parent.rotation) as Transform;
                temp.transform.parent = transform.parent.parent;
                Destroy(transform.parent.gameObject);
                Destroy(gameObject);
            }
            if(leftRayInfo.collider.tag == "Unique")
            {
                Transform temp = Instantiate(wallPrefab, transform.parent.position, transform.parent.rotation) as Transform;
                temp.transform.parent = transform.parent.parent;
                Destroy(transform.parent.gameObject);
                Destroy(gameObject);
            }
        }

		//Debug.DrawRay(transform.position, transform.right);       

        if(Physics.Raycast(rightCheckRay, out rightRayInfo, 3f))
        {

            if (rightRayInfo.collider.tag == "Wall")
            {
                Destroy(rightRayInfo.collider.gameObject);
                Vector3 spawnRotation = transform.parent.rotation.eulerAngles;
                spawnRotation.y += 180;
                Vector3 spawnPosition = transform.parent.position + (transform.parent.forward * 2) - (transform.parent.right * 0.5f);
                Transform temp = Instantiate(doorPrefab, spawnPosition, Quaternion.Euler(spawnRotation)) as Transform;
                temp.position += transform.right * 0.5f;
                temp.transform.parent = transform.parent;
            }
			else if(rightRayInfo.collider.tag == "Untagged"){
				Debug.DrawRay(transform.position, transform.right, Color.red);    
//				Debug.Log(rightRayInfo.collider.tag);
			}
            
            if (rightRayInfo.collider.tag == "Outer")
            {
                Transform temp = Instantiate(wallPrefab, transform.parent.position, transform.parent.rotation) as Transform;
                temp.transform.parent = transform.parent;
                //Debug.Log("OUTER WALL DETECTED");
                Destroy(transform.parent);
                Destroy(gameObject);
            }
            if (rightRayInfo.collider.tag == "Unique")
            {
                Transform temp = Instantiate(wallPrefab, transform.parent.position, transform.parent.rotation) as Transform;
                temp.transform.parent = transform.parent.parent;
                Destroy(transform.parent.gameObject);
                Destroy(gameObject);
            }
        }

        timer += Time.deltaTime;
        if (timer > 0.2f) 
            Destroy(this);
	}

    void OnTriggerStay(Collider col)
    {
        Debug.Log(col.tag);
        if(col.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
