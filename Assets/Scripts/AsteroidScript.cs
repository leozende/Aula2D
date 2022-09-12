using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    // Contem a velocidade do asteroide
    public int speed = -5;
    private Rigidbody2D rb;
    private PointScript ptScript; // Para se comunicar com o scriptNave

    void Start()
    {
        // Capturando a referência do componente Rigidbody2D
        rb = GetComponent<Rigidbody2D>();

        // Capturando a referência do componente PointScript (no objeto Pontuacao)
        ptScript = GameObject.Find("Pontuacao").GetComponent<PointScript>();

        MovimentoEmQueda();
        Rotacionar();
    }

    void MovimentoEmQueda()
    {
        //Adicionar speed à velocidade do asteroide
        rb.velocity = new Vector2(0, speed);

        //Destroi o asteroide após 3 segundos de ter sido lançado.
        Destroy(gameObject, 3);
    }

    void Rotacionar()
    {
        // Faz o asteroide rodar em si mesmo aleatoriamente entre -200 e 200 graus.
        rb.angularVelocity = Random.Range(-200, 200);

    }

    void OnTriggerEnter2D(Collider2D outro)
    {
        if (outro.gameObject.tag == "balaTag")
        {
            Destroy(this.gameObject);
            ptScript.pontos++;
        }
    }

}
