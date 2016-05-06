using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreLogic : MonoBehaviour {

	[SerializeField] Transform PlayerContainer, GoalItem, WinZone, BombSpawner;
    public static int ScoreP1, ScoreP2, ScoreP3, ScoreP4;
    public static string winner = null;
    public int winNumber;
	[SerializeField] Text P1, P2, P3, P4;

	int maxWidth = 3;
	int maxHeight = 4;
	float timer = 0f;
	bool playersSpawned = false;

	void placeComponent (Transform currentThing) {
		int tempHeight = Random.Range (0, maxHeight);
		int tempWidth = Random.Range (0, maxWidth);
		//Debug.Log (tempHeight + " , " + tempWidth);
		GameObject destination = GameObject.Find ("RoomController (" + tempHeight + " , " + tempWidth + ")");
		currentThing.transform.position = destination.transform.position;
		//Debug.Log ("Placing " + currentThing + " at " + destination);
		destination.GetComponent<RoomProperties>().furniture = true;
	}

	// Use this for initialization
	void Start () {
		
		P1.text = ScoreP1.ToString();
		P2.text = ScoreP2.ToString();
		P3.text = ScoreP3.ToString();
		P4.text = ScoreP4.ToString();
	}

	void Update() {

        if(P1.text == winNumber.ToString())
        {
            winner = "Player Red";
        }
        else if(P2.text == winNumber.ToString())
        {
            winner = "Player Blue";
        }
        else if(P3.text == winNumber.ToString())
        {
            winner = "Player Yellow";
        }
        else if(P4.text == winNumber.ToString())
        {
            winner = "Player Green";
        }

        if(winner != null)
        {
            SceneManager.LoadScene(2);
        }

        if(timer < 1f)
        {
            timer += Time.deltaTime;
            if(timer > 1f)
            {
                GoalItem = GameObject.Find("GoalItem").transform;
                placeComponent(GoalItem);

                WinZone = GameObject.Find("WinZone").transform;
                placeComponent(WinZone);

                BombSpawner = GameObject.Find("BombSpawner").transform;
                placeComponent(BombSpawner);

                PlayerContainer = GameObject.Find("PlayerContainer").transform;
                placeComponent(PlayerContainer);
                playersSpawned = true;
            }
        }
	}

    public void addOne(int n)
    {
        if(n == 1)
        {
            ScoreP1++;
        }
        else if( n == 2)
        {
            ScoreP2++;
        }
        else if (n == 3)
        {
            ScoreP3++;
        }
        else if (n == 4)
        {
            ScoreP4++;
        }
    }
}
