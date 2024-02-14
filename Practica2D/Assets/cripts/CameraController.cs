using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform personaje;

    private float ScreenSize;
    private float ScreenHeight;

    // Start is called before the first frame update
    void Start()
    {
        ScreenSize = Camera.main.orthographicSize;
        ScreenHeight = ScreenSize * 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CalcularPosition()
    {
        int pantallaPersonaje = (int)(personaje.position.y / ScreenHeight);
        float alturaCamara = (pantallaPersonaje * ScreenHeight) + ScreenSize;

        transform.position = new Vector3(transform.position.x, alturaCamara,transform.position.z);
    }
}
