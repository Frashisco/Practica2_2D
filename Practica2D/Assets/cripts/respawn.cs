using UnityEngine;
using UnityEngine.SceneManagement;

public class respawn : MonoBehaviour
{
    public Transform respawnPoint; // Punto de respawn del jugador

    // M�todo para detectar colisiones
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Si el objeto que colisiona tiene la etiqueta "Player"
        if (collision.CompareTag("Player"))
        {
            // Mover al jugador al punto de respawn
            collision.transform.position = respawnPoint.position;

            // Restar una vida al jugador
            GameManager.Instance.PerderVida();
        }
    }
}