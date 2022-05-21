using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SierraYCaballero : MonoBehaviour
{
    private Rigidbody2D rb;

    public float waitTime;
    private float waitTimeVar;
    public float veloSierra;
    public float veloCaballero;
    public float direccion;

    bool parado;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
        waitTimeVar = waitTime;
    }

    public void FixedUpdate()
    {
        Mover();
        if(veloCaballero == 0)
        transform.Rotate(new Vector3(0, 0, 3));
    }


    public void Update()
    {
        if(parado)
        {
            waitTimeVar -=Time.deltaTime;
        }       

    }

    public void Mover()
    {
        if(!parado)
            rb.velocity = new Vector2(direccion * veloCaballero, direccion * veloSierra);

    }

    public void OnTriggerEnter2D(Collider2D collisionInfo)
    {
    if(collisionInfo.CompareTag("limite")){
        direccion *=-1;
        rb.velocity=new Vector2(rb.velocity.x,0);
        parado=true;
        }
    }


    public void OnTriggerStay2D(Collider2D collisionInfo)
    {
        if(waitTimeVar <=0){
            parado=false;
        }
    }

    public void OnTriggerExit2D(Collider2D collisionInfo)
    {
        waitTimeVar = waitTime;
        parado = false;
    }

}
