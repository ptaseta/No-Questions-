using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{

    public GameObject Player;
    

       void OnTriggerEnter2D (Collider2D collision)

        {
            if (collision.gameObject.CompareTag("Enemigo"))
            {
             transform.position = GameObject.FindWithTag("Respawn").transform.position;

            }
        }

}
