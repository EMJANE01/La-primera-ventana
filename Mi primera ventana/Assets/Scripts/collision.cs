using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision : MonoBehaviour
{
   private void OnCollisionEnter2D(Collision2D other) {
    if(other.collider.CompareTag("Player")){
        Debug.Log("Jugador entro");

    }
   }

   private void OnCollisionExit2D(Collision2D other) {
     if(other.collider.CompareTag("Player")){
        Debug.Log("Jugador salio");
   }
}
}