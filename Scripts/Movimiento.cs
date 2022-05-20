using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public float velocidad;
    public float saltoFuerza;
    public float dashFuerza;

    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    private float Horizontal;
    private bool EnTierra;
    private int CargaDash;
    

    public float DistanciaDash = 15f;
    bool dasheando;



    
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        SpawnPoint =  transform.position;    
    }


    void Update()
    {

       Horizontal  = Input.GetAxisRaw("Horizontal");

        if(Horizontal < 0.0f)
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if(Horizontal > 0.0f)
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
       

        Animator.SetBool("Corriendo",Horizontal != 0.0f);
       
       if(Physics2D.Raycast(transform.position, Vector3.down, 0.47f))
       {
        EnTierra = true;
        CargaDash = 1;
       }
       else 
       {
        EnTierra = false;
        
       }
       

       if(Input.GetKeyDown(KeyCode.Space) &&  EnTierra)
       {
           salto();
       }


       if(Input.GetKeyDown(KeyCode.Mouse0) &&  CargaDash == 1 && !EnTierra)
       {
           if(Horizontal > 0.0f)
            StartCoroutine(dash(1f));
           else if(Horizontal < 0.0f)
            StartCoroutine(dash(-1f));
       }


    }

    private IEnumerator dash(float direccion)
    {
        dasheando = true;
        Rigidbody2D.velocity = new Vector2(Rigidbody2D.velocity.x, 0f);
        Rigidbody2D.AddForce(new Vector2(DistanciaDash * direccion, 0f), ForceMode2D.Impulse);
        float gravity = Rigidbody2D.gravityScale;
        Rigidbody2D.gravityScale = 0.1f;
        yield return new WaitForSeconds(0.13f);
        Rigidbody2D.gravityScale = gravity;
        dasheando = false;
        
        CargaDash = 0;
    }


    private void salto()
    {
        Rigidbody2D.AddForce(Vector2.up * saltoFuerza);
    }


    private void FixedUpdate()
    {
        
        if(!dasheando)
            Rigidbody2D.velocity = new Vector2(Horizontal * velocidad, Rigidbody2D.velocity.y); 

    }

}
