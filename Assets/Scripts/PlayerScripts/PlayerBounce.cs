using UnityEngine;
using System.Collections;

public class PlayerBounce : MonoBehaviour {

    [SerializeField] float pushForce = 500f;
    private bool pushBack = false;
    private float timer = 0f;
    private Vector3 direction;

	// Update is called once per frame
	void Update () {
        gameObject.GetComponent<Rigidbody>().AddForce(Vector3.down * -9.8f * Time.deltaTime);

        if (pushBack)
        {
            if(timer < 0.2f)
            {
                timer += Time.deltaTime;
                gameObject.GetComponent<Rigidbody>().AddForce(direction * -400f);
            }
            else
            {
                pushBack = false;
                timer = 0f;
            }
        }
	}

    void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag.Contains("Player"))
        {
            Debug.Log("Its a player!");
            direction = (col.collider.transform.position - transform.position).normalized;
            direction.y = 0f;
            pushBack = true;
        }
    }
}
