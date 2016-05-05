using UnityEngine;
using System.Collections;

public class ObjectInteraction : MonoBehaviour {

    [SerializeField] GameObject iGotIt;
    public Transform[] hands;
    public float throwForce;
    public bool throwItem, keyItem;
    public string throwItemName, keyItemName;
    public float objectMass;

	// Use this for initialization
	void Start ()
    {
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (hands[0].childCount == 0)
        {
            throwItem = false;
            throwItemName = null;
        }
        if (hands[1].childCount == 0)
        {
            keyItem = false;
            keyItemName = null;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        Rigidbody otherRB = other.gameObject.GetComponent<Rigidbody>();

        // If another player bumps into you then apply a bounce force in their direction
        // If a projectile or player hits you, drop the key item you are holding and apply knockback
        if (other.collider.tag == "Projectile" || other.collider.tag == "Player")
        {
            if (keyItem)
            {
                Rigidbody keyItemRB = hands[1].FindChild(keyItemName).GetComponent<Rigidbody>();

                keyItemRB.constraints = RigidbodyConstraints.None;
                keyItemRB.constraints = RigidbodyConstraints.FreezeRotation;
                keyItemRB.detectCollisions = true;
                keyItemRB.useGravity = true;
                hands[1].DetachChildren();
            }

            GetComponent<Rigidbody>().AddForce(-transform.forward * 500 + Vector3.up * 300);
        }
        // If the item you bump into is a grabable item and you currently don't have one, pick it up
        if (other.collider.tag == "Grabby Thing" && !throwItem)
        {
            objectMass = other.gameObject.GetComponent<ThrowableObjects>().mass;
            throwItemName = other.gameObject.name;

                otherRB.constraints = RigidbodyConstraints.FreezeAll;
                otherRB.mass = 0;
                other.transform.position = hands[0].position;
                other.transform.SetParent(hands[0]);
            otherRB.mass = 0f;
                otherRB.useGravity = false;
                throwItem = true;
        }
        // If the other item is a key item and you aren't holding a key item, pick it up
        if (other.collider.tag == "Key Item" && !keyItem)
        {
            keyItemName = other.gameObject.name;

            otherRB.constraints = RigidbodyConstraints.FreezeAll;
            other.transform.position = hands[1].position;
            other.transform.SetParent(hands[1]);
            otherRB.detectCollisions = false;
            otherRB.useGravity = false;
            keyItem = true;

            // Add particle effect of your color to indicate that you are holding a key item
            GameObject iGotItClone = (GameObject)Instantiate(iGotIt, transform.position, iGotIt.transform.rotation);
            iGotItClone.transform.SetParent(transform);
            iGotItClone.GetComponent<ParticleSystem>().startColor = GetComponent<PlayerController>().playerColor;
        }
    }
}
