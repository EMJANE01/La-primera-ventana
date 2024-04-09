using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class money : MonoBehaviour
{
    [SerializeField] private float cantidadPuntos;
    private puntaje puntaje; // Esta variable almacenará una referencia al script puntaje

    private void Start()
    {
        // Encontrar el objeto que contiene el script puntaje
        puntaje = FindObjectOfType<puntaje>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Asegurarse de que puntaje no sea nulo y sumar los puntos
            if (puntaje != null)
            {
                puntaje.SumarPuntos(cantidadPuntos);
            }

            Destroy(gameObject); // Destruir la moneda
        }
    }
}