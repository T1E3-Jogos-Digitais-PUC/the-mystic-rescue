using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EfeitoParallax : MonoBehaviour
{
    [SerializeField] private Image fundo;
    [SerializeField] private float velocidade;

    // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // Update is called once per frame
    void Update()
    {
        MoveFundo();
    }

    public void MoveFundo()
    {
        //Multiplicando por Input.GetAxis("Horizontal") o script identifica para qual lado o personagem esta deslocando (esquerda = -1, parado = 0, direita = 1)
       //transform.position = new Vector3(transform.position.x - velocidade * Time.deltaTime * Input.GetAxis("Horizontal"), 0, 0);

        //Como o cenário vai se movimentar sempre para a direita, não é necessário pegar o sentido do movimento do personagem
        transform.position = new Vector3(transform.position.x - velocidade * Time.deltaTime, transform.position.y, transform.position.z);

        //Estava dando erro de objeto nulo, no if abaixo, coloquei esta linha para eliminar qualquer referência nula captada pelo script
        if (fundo == null) return;

        //Script de rolagem infinita - identifica a borda da imagem e repete
        if(transform.localPosition.x >= fundo.preferredWidth)
        {
            transform.localPosition = new Vector3(transform.localPosition.x - fundo.preferredWidth * 2, transform.position.y, transform.position.z);            
        } else if(transform.localPosition.x <= -fundo.preferredWidth)
        {
            transform.localPosition = new Vector3(transform.localPosition.x + fundo.preferredWidth * 2, transform.position.y, transform.position.z);
        }

    }
}
