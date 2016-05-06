using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WinScript : MonoBehaviour {

    string text;

    // Use this for initialization
    void Start() {
        text = ScoreLogic.winner + " wins!";
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Text>().text = text;
	}
}
