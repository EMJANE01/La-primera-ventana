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
    // Instanciar la bala con la posición y la rotación predeterminadas
    GameObject nuevaBala = Instantiate(bala, controladorDisparo.position, controladorDisparo.rotation);

    // Obtener el componente Rigidbody2D de la nueva bala
    Rigidbody2D rbBala = nuevaBala.GetComponent<Rigidbody2D>();

    // Establecer una velocidad en la dirección horizontal
    // Aquí, la velocidad se establece en 5 unidades por segundo en la dirección hacia la derecha
    rbBala.velocity = transform.right * 30f; // Puedes ajustar el valor 5f según la velocidad deseada
}
}