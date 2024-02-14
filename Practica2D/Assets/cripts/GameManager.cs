using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public int TotalPoint { get { return TotalPoints; } }
    private int TotalPoints;
    
    public void ScorePoints(int socrepoint)
    {
        TotalPoints += socrepoint;
        Debug.Log(TotalPoints);
    }
}
