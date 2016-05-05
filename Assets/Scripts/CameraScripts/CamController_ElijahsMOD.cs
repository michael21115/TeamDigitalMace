using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CamController_ElijahsMOD : MonoBehaviour {

    [SerializeField] Transform[] players;
    [SerializeField] float minHeight = 10;
    [SerializeField] float maxHeight = 40;

    List<Transform> listOfPlayers = new List<Transform>();
    List<float> xPositions = new List<float>();
    List<float> zPositions = new List<float>();

    float averageXpos = 0;
    float averageZpos = 0;

    // Use this for initialization
    void Start()
    {
        // Adding the players to a list just in case (I could also use the array but idk if we will be destroying objects)
        foreach (Transform player in players)
        {
            listOfPlayers.Add(player);
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Transform player in listOfPlayers)
        {
            // Creating a list, tracking x and z positions
            xPositions.Add(player.position.x);
            zPositions.Add(player.position.z);
        }

        CalculateDistance();

        AverageTracking();
    }

    float CalculateDistance()
    {
        // Distances between each player's position
        float distance01 = Vector3.Distance(players[0].position, players[1].position);
        float distance02 = Vector3.Distance(players[0].position, players[2].position);
        float distance03 = Vector3.Distance(players[0].position, players[3].position);
        float distance04 = Vector3.Distance(players[1].position, players[2].position);
        float distance05 = Vector3.Distance(players[1].position, players[3].position);
        float distance06 = Vector3.Distance(players[2].position, players[3].position);
        float distances = (distance01 + distance02 + distance03 + distance04 + distance05 + distance06) / 6f;

        return Mathf.Clamp(distances, minHeight, maxHeight);
    }

    float MaxPosition(List<float> positions)
    {
        float MaxPosition = positions[0];

        foreach (float posValue in positions)
        {
            if (posValue >= MaxPosition)
            {
                MaxPosition = posValue;
            }
        }
        return MaxPosition;
    }

    float MinPosition(List<float> positions)
    {
        float MinPosition = positions[0];

        foreach (float posValue in positions)
        {
            if (posValue <= MinPosition)
            {
                MinPosition = posValue;
            }
        }
        return MinPosition;
    }

    void AverageTracking()
    {
        // Gather minimum and maximum positions to average cam position
        averageXpos = (MaxPosition(xPositions) + MinPosition(xPositions)) / 2f;
        averageZpos = (MaxPosition(zPositions) + MinPosition(zPositions)) / 2f;

        //Debug.Log(MaxPosition(zPositions) + " " + MinPosition(zPositions));
        //Debug.Log(players[0].transform.position);

        transform.position = new Vector3(averageXpos, CalculateDistance(), averageZpos);
        xPositions.Clear();
        zPositions.Clear();
    }
}
