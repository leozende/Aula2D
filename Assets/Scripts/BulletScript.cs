using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    // Atributos / Características
    public float speed = 6;
    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        rb.velocity = new Vector2(0, speed);
    }



    //OnBecameInvisible = Quando um objeto sai da tela.
    // Quando a bala fica invisível será destruída
    private void OnBecameInvisible()
    {
        // Destroi a bala quando já está fora da tela
        Destroy(gameObject);
    }


    void Update()
    {
        
    }
}
