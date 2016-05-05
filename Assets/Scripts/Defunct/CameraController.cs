using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class CameraController : MonoBehaviour {

    [SerializeField]
    Transform player1, player2, player3, player4;

    [SerializeField]
    float maxHeight = 40;

    List<Transform> players;

    
	// Use this for initialization
	void Start () {
        players = new List<Transform>();
        players.Add(player1);
        players.Add(player2);
        players.Add(player3);
        players.Add(player4);
	}
	
	// Update is called once per frame
	void Update () {

        foreach(Transform player in players)
        {
            Vector3 viewPos = Camera.main.WorldToViewportPoint(player.position);
            if(viewPos.y < 0.1 || viewPos.y > 0.9 || viewPos.x < 0.1 || viewPos.x > 0.9)
            {
                if(transform.position.y < maxHeight)
                {
                    Vector3 targetPosition = transform.position + new Vector3(0, 1, 0);
                    transform.position = Vector3.Lerp(transform.position, targetPosition, 0.2f);
                }
            }
        }
	}
}
