using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpaceshipScript : MonoBehaviour
{
    public int speed = 10;
    public GameObject bala;
    public int vidas = 3;
    public Text vidasUI; // Arrastar vidas da hierarquia nesta variavel


    void Start()
    {
        print("Start");
    }

    void Update()
    {   
        print(Time.deltaTime);

        Movimentar();
        DispararBala();
        LimitarCena();

        vidasUI.text = "Vidas: " + vidas;

    }   

    void Movimentar()
        {
            //Move a nave horizontalmente com setas ou com as teclas A e D
            //Eixo X - na horizontal
            float horizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
            float vertical = Input.GetAxis("Vertical") * speed * Time.deltaTime;

            transform.Translate(horizontal, vertical, 0);
        }

    void DispararBala()
        {
            if(Input.GetKeyDown("space"))
                {
                // Cria uma nova bala na posição atual da nave para que siga a nave
                Instantiate(bala, transform.position, Quaternion.identity);
                }
        }
        
    void LimitarCena()
        {
            //Restringindo o movimento entre dois valores.
            if(transform.position.x<=-6f || transform.position.x >= 6f)
            {
                //Criando o limite
                float xPos = Mathf.Clamp(transform.position.x, 6f, -6f);
                //Limitando
                transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
            }

            //Restringindo o movimento entre dois valores.
            if (transform.position.y <= -4.5f || transform.position.y >= 4.5f)
            {
                //Criando o limite
                float yPos = Mathf.Clamp(transform.position.y, -4.5f, 4.5f);
                //Limitando
                transform.position = new Vector3(transform.position.x, yPos, transform.position.z);
            }

    }

    void OnTriggerEnter2D(Collider2D outro)
    {
        if(outro.gameObject.tag == "asteroidTag")
        {
            vidas = vidas - 1; // Cada colisao perde uma vida
            if(vidas == 0)
            {
                vidasUI.text = "Vidas: " + vidas;

                // Quando topar 3 vezes com o inimigo, a nave morre
                Destroy(this.gameObject);
            }

        }


    }
}
