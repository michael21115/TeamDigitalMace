using UnityEngine;
using System.Collections;

public class BombDestruction : MonoBehaviour {

    private Transform spawner;
    [SerializeField] Transform explosion;
    private bool spawned = false;

    void Start()
    {
        spawner = GameObject.Find("BombSpawner").transform;
    }

    void OnTriggerEnter(Collider collider)
    {
        if (tag == "Projectile" && !spawned)
        {
            if (collider.gameObject.tag == "Wall" || collider.gameObject.tag == "Door")
            {
                spawner.GetComponent<SpawnBomb>().isBomb = false;
                spawned = true;
                Instantiate(explosion, transform.position, transform.rotation);
               
                Destroy(gameObject);
            }
        }
    }
}
