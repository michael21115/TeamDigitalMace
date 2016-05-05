using UnityEngine;
using System.Collections;

public class AnimationController : MonoBehaviour {

    Animator anim;
    PlayerController move;

	// Use this for initialization
	void Start ()
    {
        anim = GetComponent<Animator>();
        move = GetComponentInParent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        //anim.SetFloat("isMoving", GetComponentInParent<PlayerController>().movement.magnitude);
        if (Mathf.Abs(move.horizontal) > 0.05f || Mathf.Abs(move.vertical) > 0.05)
        {
            anim.SetBool("isMoving", true);
            anim.SetFloat("isRunning", new Vector2(move.horizontal,move.vertical).magnitude);
        }
        else
        {
            anim.SetBool("isMoving", false);
            anim.SetFloat("isRunning", 0f);
        }
	}
}
