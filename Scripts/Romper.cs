using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Romper : MonoBehaviour
{

    public GameObject particles;


        void OnTriggerEnter2D (Collider2D collision){

            if (collision.gameObject.CompareTag("Player"))
            {
                Instantiate(particles, transform.position, transform.rotation);
                Destroy(gameObject);
            }

        }
   
}
