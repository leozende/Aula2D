using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Quando eu colocar um text.
    
    
    // Esse Script foi anexado a um GameObject Empty arrastado dentro da Main Camera
    // Este script precisa ficar anexado a um objeto que esteja a um tempo todo.
    // valendo, como a main camera ou o background.


public class PointScript : MonoBehaviour
{
    public Text pontosUi; // Arrastar da hierarquia Pontos para a variavel publica
                          // Pontos da Main Camera
    public Text recordeUI; // Arrasta da hierarquia Recorde para a variavel publica
                           // Recorde da Main Camera
    public int pontos = 0; // Dar acesso ao script nave, por isso public.

    void Update()
    {
        if(pontos > PlayerPrefs.GetInt("Recorde"))
        {
            PlayerPrefs.SetInt("Recorde", pontos);
        }
        pontosUi.text = "Pontos: " + pontos;
        recordeUI.text = "Recorde: " + PlayerPrefs.GetInt("Recorde");
        
    }
}
