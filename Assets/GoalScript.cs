using UnityEngine;
using System.Collections;

public class GoalScript : MonoBehaviour {

    [SerializeField]
    Transform scoreLogic;

    void OnTriggerEnter(Collider col){

        Debug.Log(col.transform.name);
        if(col.transform.name == "GoalItem")
        {
            
            string player = col.transform.GetComponent<ThrowableObjects>().pointGoesTo;
            Debug.Log(player);
            if (player.Contains("1"))
            {
                scoreLogic.GetComponent<ScoreLogic>().addOne(1);
            }
            else if (player.Contains("2"))
            {
                scoreLogic.GetComponent<ScoreLogic>().addOne(2);
            }
            else if (player.Contains("3"))
            {
                scoreLogic.GetComponent<ScoreLogic>().addOne(3);
            }
            else if (player.Contains("4"))
            {
                scoreLogic.GetComponent<ScoreLogic>().addOne(4);
            }
        }
    }
}
