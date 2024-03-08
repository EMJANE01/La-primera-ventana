using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
   public Transform jugador;

   private float tamañoCamara;
   private float alturaPantalla;


   void Start()
   {
     tamañoCamara = Camera.main.orthographicSize;
     alturaPantalla = tamañoCamara * 2;
   }

   void Update()
   {
    CalcularPosicionCamara();
    
   }

   void CalcularPosicionCamara()
   {
      // Obtenemos la posición del jugador en la pantalla
    Vector3 posicionJugadorEnPantalla = Camera.main.WorldToViewportPoint(jugador.position);

    // Calculamos la posición de la cámara para seguir al jugador dentro del área visible de la pantalla
    Vector3 posicionCamara = transform.position;
    posicionCamara.y = Mathf.Clamp(jugador.position.y, tamañoCamara, alturaPantalla - tamañoCamara);
    posicionCamara.x = transform.position.x;
    transform.position = posicionCamara;
   }
}