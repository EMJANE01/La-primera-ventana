using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparojugador : MonoBehaviour
{
    [SerializeField] private Transform controladorDisparo;
    [SerializeField] private GameObject bala;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            DispararBala();
        }
    }

    private void DispararBala()
    {
        // Determinar la dirección del disparo basándose en el movimiento del jugador
        float direccion = Input.GetAxisRaw("Horizontal");

        // Instanciar la bala con la posición y la rotación predeterminadas
        GameObject nuevaBala = Instantiate(bala, controladorDisparo.position, Quaternion.identity);

        // Obtener el componente Rigidbody2D de la nueva bala
        Rigidbody2D rbBala = nuevaBala.GetComponent<Rigidbody2D>();

        // Establecer una velocidad en la dirección obtenida
        rbBala.velocity = new Vector2(direccion * 30f, rbBala.velocity.y); // Velocidad horizontal ajustada, la velocidad vertical se mantiene igual
    }
}