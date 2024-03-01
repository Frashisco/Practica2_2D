using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flagSpawn : MonoBehaviour
{
    private Vector3 flagLocation; // Variable para almacenar la ubicación de la bandera

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verificar si el objeto que colisiona es el jugador y tiene la etiqueta "Player"
        if (other.CompareTag("Player"))
        {
            // Guardar la posición de la bandera cuando el jugador la toca
            flagLocation = transform.position;

            // Guardar la posición de la bandera en PlayerPrefs para que persista entre sesiones
            PlayerPrefs.SetFloat("FlagPosX", flagLocation.x);
            PlayerPrefs.SetFloat("FlagPosY", flagLocation.y);
            PlayerPrefs.SetFloat("FlagPosZ", flagLocation.z);

            // Guardar los cambios en PlayerPrefs
            PlayerPrefs.Save();
        }
    }
}
