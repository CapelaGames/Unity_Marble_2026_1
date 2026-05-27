using System.Collections.Generic;
using UnityEngine;

public class HighScore : MonoBehaviour
{

    int score = 5;

    int[] topFiveScores = new int[5];
    List<int> allScores = new List<int>();



    void Start()
    {
        ArrayExample();
        ListExample();
        
    }


    void ListExample()

    {

        allScores.Add(4200);
        allScores.Add(4290);
        allScores.Add(4240);
        allScores.Add(4200);
        allScores.Add(2200);
        allScores.Add(4600);
        allScores.Add(4200);
        allScores.Add(800);
        allScores.Add(900);

        //   Arrays you use .Length
        //   int length = topFiveScores.Length

        Debug.Log("Total scores:" + allScores.Count);
        Debug.Log("First Score: " + allScores[0]);
        Debug.Log("Last Score: " + allScores[allScores.Count - 1]);

    }
    void ArrayExample()

    {

        topFiveScores[0] = 9800;
        topFiveScores[1] = 8500;
        topFiveScores[2] = 7200;
        topFiveScores[3] = 6100;
        topFiveScores[4] = 5000;

        Debug.Log(message: "1st Place" + topFiveScores[0]);
        Debug.Log(message: "2nd Place" + topFiveScores[1]);
        Debug.Log(message: "3rd Place" + topFiveScores[2]);

    }


}