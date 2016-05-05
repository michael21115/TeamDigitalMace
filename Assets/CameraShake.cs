using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour {

    Vector3 originalPosition;

    float duration = 0f;
    public bool camShake = false;

	// Use this for initialization
	void Start () {
        originalPosition = transform.position;
        //cameraShake(0.5f);
	}
	
	// Update is called once per frame
	void Update () {

        if (duration > 0 && camShake)
        {
            duration -= Time.deltaTime;
            transform.position = Random.insideUnitSphere + originalPosition;
            if(duration <= 0)
            {
                transform.position = originalPosition;
                camShake = false;
            }
        }


    }

    public void cameraShake(float num)
    {
        duration = num;
        camShake = true;
        
    }
}
