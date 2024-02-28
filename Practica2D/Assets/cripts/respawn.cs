using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class respawn : MonoBehaviour
{
    // Método para reiniciar el juego
    public void Restart()
    {
        // Cargar la escena actual
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Método para detectar colisiones
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Si el objeto que colisiona tiene la etiqueta "Player", reiniciar el juego
        if (collision.CompareTag("Player"))
        {
            Restart();
        }
    }
}
