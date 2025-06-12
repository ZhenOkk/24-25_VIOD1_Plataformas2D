using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movimiento2D : MonoBehaviour
{

    public AudioSource JumpPlayer;
    public AudioSource CoinCollected;
    public AudioSource VictorySound;
    public AudioSource DeathPlayer;
    public AudioSource LandingPlayer;

    private Rigidbody2D rb2D;

    [Header("Movimiento")]
    private float movimientoHorizontal = 0f;
    [SerializeField] private float speed;
    [SerializeField] private float speedSmooth;
    private Vector3 velocidad = Vector3.zero;
    private bool mirandoDerecha = true;

    [Header("Salto")]
    [SerializeField] private float jumpStrenght;
    [SerializeField] private LayerMask isGround;
    [SerializeField] private Transform groundController;
    [SerializeField] private Vector3 boxDimensions;
    [SerializeField] private bool touchGround;
    private bool jump = false;

    [Header("Animacion")]
    private Animator animator;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        movimientoHorizontal = Input.GetAxisRaw("Horizontal") * speed;

        animator.SetFloat("Horizontal", Mathf.Abs(movimientoHorizontal));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

    }

    private void FixedUpdate()
    {
        touchGround = Physics2D.OverlapBox(groundController.position, boxDimensions, 0f, isGround);
        Movimiento(movimientoHorizontal * Time.fixedDeltaTime, jump);
        jump = false;
        animator.SetBool("enSuelo", touchGround);
    }

    private void Movimiento(float mover, bool jump)
    {
        Vector3 objectSpeed = new Vector2(mover, rb2D.velocity.y);
        rb2D.velocity = Vector3.SmoothDamp(rb2D.velocity, objectSpeed, ref velocidad, speedSmooth);

        if (mover > 0 && !mirandoDerecha)
        {
            //Girar
            Girar();
            
        }
        else if (mover < 0 && mirandoDerecha)
        {
            //Girar
            Girar();
            
        }

        if (touchGround && jump)
        {
            touchGround = false;
            rb2D.AddForce(new Vector2(0f, jumpStrenght));
            JumpPlayer.Play();
        }
    }
    private void Girar()
    {
        mirandoDerecha = !mirandoDerecha;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(groundController.position, boxDimensions);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DeathVoid"))
        {
            DeathPlayer.Play();
        }
        if (collision.CompareTag("Key"))
        {
            CoinCollected.Play();
        }
        if (collision.CompareTag("Door"))
        {
            CoinCollected.Play();
        }
        if (collision.CompareTag("MovingGround"))
        {
            LandingPlayer.Play();
        }
    }
}
