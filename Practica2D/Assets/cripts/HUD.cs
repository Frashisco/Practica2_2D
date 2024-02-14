using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{
    public GameManager gameManager;
    public TextMeshProUGUI score;

    // Update is called once per frame
    void Update()
    {
        score.text = gameManager.TotalPoint.ToString();
    }
}
