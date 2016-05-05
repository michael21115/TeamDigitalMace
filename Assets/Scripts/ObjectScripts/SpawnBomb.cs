using UnityEngine;
using System.Collections;

public class SpawnBomb : MonoBehaviour {

    [SerializeField] float cooldown;

    [SerializeField] GameObject bomb;

	public bool isBomb = false;
    private float timer;

	void bombSpawn() {
		Debug.Log("Bomb Spawn");
		Vector3 currentLocation = transform.position;
		Instantiate(bomb, currentLocation, Quaternion.identity);
		isBomb = true;
	}

	void Start() {
		isBomb = false;
		timer = 0.1f;
	}

	// Update is called once per frame
	void Update () {
        if (!isBomb) {
            if(timer > 0) {
                timer -= Time.deltaTime;
                if(timer < 0) {
					bombSpawn();
                }
            }
        }
        else {
            timer = cooldown;
        }
	}
}
