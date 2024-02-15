using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class point : MonoBehaviour
{

    public int valor = 10;
    public GameManager gameManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameManager.SumarPuntos(valor);
            Destroy(this.gameObject);
        }

    }
}
