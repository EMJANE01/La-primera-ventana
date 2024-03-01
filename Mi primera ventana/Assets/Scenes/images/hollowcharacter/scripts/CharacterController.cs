using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    
public LayerMask capaSuelo;
public float saltosMaximos;
    public float velocidad;
    public float fuerzaSalto;
   
    
    private Rigidbody2D rigidBody;
    private BoxCollider2D boxCollider;
    private bool mirandoDerecha = true;
    private float saltosRestantes;
    private Animator animator;

    private void Start(){
        rigidBody = GetComponent<Rigidbody2D>(); 
        boxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        ProcesarMovimiento();
        ProcesarSalto();
    }

    bool EstaEnSuelo(){
       RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, new Vector2(boxCollider.bounds.size.x, boxCollider.bounds.size.y), 0f, Vector2.down, 0.2f, capaSuelo);
       return raycastHit.collider != null;
    }

   void ProcesarSalto(){
    if (EstaEnSuelo())
    {
        saltosRestantes = saltosMaximos;
    }

    if (Input.GetKeyDown(KeyCode.Space) && saltosRestantes > 0)
    {
        saltosRestantes--;

        rigidBody.velocity = new Vector2(rigidBody.velocity.x, 0f); // Detener el movimiento vertical actual.
        rigidBody.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse); // Aplicar fuerza de salto.
    }
}
    void ProcesarMovimiento()
    {
        float inputMovimiento = Input.GetAxis("Horizontal");
       
       if(inputMovimiento != 0f){
        animator.SetBool("isRunning", true);
       }
       else{
        animator.SetBool("isRunning", false);
       }

        rigidBody.velocity = new Vector2(inputMovimiento * velocidad, rigidBody.velocity.y);
        GestionarOrientacion(inputMovimiento);
    
    
    }

    void GestionarOrientacion(float inputMovimiento)
{
    if ((mirandoDerecha == true && inputMovimiento < 0) || (mirandoDerecha == false && inputMovimiento > 0))
    {
        mirandoDerecha = !mirandoDerecha;
        transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
    }
}
}