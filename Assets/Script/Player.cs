using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float JumpSpeed;
    private Rigidbody2D rb;

    public Transform GroundCheck;
    public float CheckRadius;
    public LayerMask whatIsGround;
    public bool isGrounded;

    // Grind
    public LayerMask whatIsGrind;
    public bool isGrinding;
    public bool firstGrind;

    // Extra jump
    public int maxJumpValue;
    int maxJump;


    
    private void Start() {
        maxJump = maxJumpValue;
        firstGrind = true;
        rb = GetComponent<Rigidbody2D>();    
    }

    private void Update() {
        isGrounded = Physics2D.OverlapCircle(GroundCheck.position, CheckRadius, whatIsGround);
        isGrinding = Physics2D.OverlapCircle(GroundCheck.position, CheckRadius, whatIsGrind);
        
        // Si el jugador presiona el botón del mouse y está en el suelo o grindeando, salta.
        if (Input.GetMouseButtonDown(0) && (isGrounded || isGrinding)) {
            Jump();
        }
        // Si el jugador presiona el botón del mouse mientras está en el aire, imprime "Trick" y agrega al puntaje.
        else if (Input.GetMouseButtonDown(0) && !(isGrounded || isGrinding)) {
            Debug.Log("Trick");
            GameManager.Instance.AddScore(10);
        }

        // Si el jugador toca un grind, se teletransporta encima de este si es la primera vez que lo toca
        if(!isGrinding){
            firstGrind = true;
        }

        // Si el jugador esta grindeando, se sumeran puntos
        if(isGrinding){
            GameManager.Instance.AddScore(1);
        }

        // Restablece las oportunidades de salto y trucos cuando el jugador toca el suelo o grind.
        if(isGrounded || isGrinding){
            maxJump = maxJumpValue;
        }
    }

    void Jump(){
        // Salta y establece la bandera de salto en verdadero.
        rb.velocity = Vector2.zero;
        rb.AddForce(new Vector2(0, JumpSpeed));
    }

    // Colisiones entre el jugador y el grind
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Grind") {
            BoxCollider2D grindCollider = other.gameObject.GetComponent<BoxCollider2D>();
            Vector3 grindPosition = other.transform.position;
            if(firstGrind){
                Grind(grindPosition);
                grindCollider.isTrigger = false;
                firstGrind = false;
            }
        }
    }

    public void Grind(Vector3 grindPosition){
        // Establece la posición del jugador por encima de la posición de grindPosition.
        transform.position = new Vector3(transform.position.x, grindPosition.y + 0.5f, transform.position.z);
    }
}
