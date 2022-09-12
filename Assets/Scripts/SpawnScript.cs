using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clona o Asteroide aleatoriamente na tela

public class SpawnScript : MonoBehaviour
{
    public GameObject asteroid; //Armazenará o prefab Asteroide

    // Variável para conhecer quando devemos começar a instanciar os asteroids
    public float spawnStartTime = 2;

    // Variável para conhecer quão rápido nós devemos criar novos Asteroides
    public float spawnTime = 1;

    void Start()
    {
        // Chamar a função 'addEnemy' a cada 'spawnTime' segundos
        InvokeRepeating("addEnemy", spawnStartTime, spawnTime);

    }

    // Nova função para clonar/spawn um Asteroide

    void addEnemy()
    {
        // Variável para armazenar a posição X do objeto spawn.
        Renderer renderer = GetComponent<Renderer>();
        var x1 = transform.position.x - renderer.bounds.size.x / 2;
        var x2 = transform.position.x + renderer.bounds.size.x / 2;

        // Aleatoriamente escolhe um ponto dentro do objeto spawn
        var spawnPoint = new Vector2(Random.Range(x1, x2), transform.position.y);

        // Criar um Asteroide na posição 'spawnPoint'
        Instantiate(asteroid, spawnPoint, Quaternion.identity);

    }


    void Update()
    {
        
    }
}
