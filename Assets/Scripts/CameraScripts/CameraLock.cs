using UnityEngine;
using System.Collections;

public class CameraLock : MonoBehaviour {

    [SerializeField]
    Camera mainCam;

    [SerializeField]
    float borderPercentage;

    float minX, maxX, minY, maxY;

	// Use this for initialization
	void Start () {
	       
	}
	
	// Update is called once per frame
	void Update () {
        minX = mainCam.pixelWidth * borderPercentage;
        maxX = mainCam.pixelWidth * (1 - borderPercentage);
        minY = mainCam.pixelHeight * borderPercentage;
        maxY = mainCam.pixelHeight * (1 - borderPercentage);

        Vector3 screenPosition = mainCam.WorldToScreenPoint(transform.position);
       // Debug.Log(screenPosition);


        if(screenPosition.x < minX)
        {
            screenPosition.x = minX;
        }

        if(screenPosition.x > maxX)
        {
            screenPosition.x = maxX;
        }

        if(screenPosition.y < minY)
        {
            screenPosition.y = minY;
        }

        if(screenPosition.y > maxY)
        {
            screenPosition.y = maxY;
        }

        transform.position = mainCam.ScreenToWorldPoint(screenPosition);
        

	}
}
