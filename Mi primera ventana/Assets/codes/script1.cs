using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public Text dialogText;
    private string[] dialogues; // Array de diálogos
    private int currentDialogIndex = 0;

    void Start()
    {
        // Inicialización de diálogos (puedes cargarlos desde un archivo, por ejemplo)
        dialogues = new string[]
        {
            "¡Hola! Soy un NPC.",
            "¿Cómo estás hoy?",
            "Espero que estés disfrutando del juego."
        };

        // Mostrar el primer diálogo
        MostrarDialogo();
    }

    void Update()
    {
        // Avanzar al siguiente diálogo al presionar la tecla de espacio
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AvanzarDialogo();
        }
    }

    void MostrarDialogo()
    {
        // Mostrar el diálogo actual en el UI
        dialogText.text = dialogues[currentDialogIndex];
    }

    void AvanzarDialogo()
    {
        // Avanzar al siguiente diálogo si hay más disponibles
        if (currentDialogIndex < dialogues.Length - 1)
        {
            currentDialogIndex++;
            MostrarDialogo();
        }
        else
        {
            // Si no hay más diálogos, ocultar el UI de diálogo
            dialogText.text = "";
        }
    }
}