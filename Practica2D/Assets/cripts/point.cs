using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class point : MonoBehaviour
{

    public int worth = 10;
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameManager.ScorePoints(worth);
            Destroy(this.gameObject);
        }
        
    }
}
