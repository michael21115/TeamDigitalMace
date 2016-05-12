using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class WinScript : MonoBehaviour {

    string text;

    // Use this for initialization
    void Start()
    {
        text = ScoreLogic.winner + " wins!";
        GetComponent<Text>().text = text;
    }

    // Update is called once per frame
    void Update ()
    {

        if (Input.GetKey(KeyCode.Space))
        {
            ScoreLogic.winner = null;
            ScoreLogic.ScoreP1 = 0;
            ScoreLogic.ScoreP2 = 0;
            ScoreLogic.ScoreP3 = 0;
            ScoreLogic.ScoreP4 = 0;

            SceneManager.LoadScene(1);
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            ScoreLogic.winner = null;
            ScoreLogic.ScoreP1 = 0;
            ScoreLogic.ScoreP2 = 0;
            ScoreLogic.ScoreP3 = 0;
            ScoreLogic.ScoreP4 = 0;

            Application.Quit();
        }
	}
}
