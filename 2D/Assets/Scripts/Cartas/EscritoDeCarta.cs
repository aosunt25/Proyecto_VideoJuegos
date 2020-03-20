using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscritoDeCarta : MonoBehaviour
{
    private int numero;
    private static int[] numDeCartas = GameMaster.arregloDeCartas;
    public GameObject[] textocartas;
    // Update is called once per frame
    public void Continuar()
    {
       gameObject.SetActive(false);
       textocartas[numero].SetActive(false);
    }
    public void ActivarTexto(int num)
    {
        numero = num - 1;
        textocartas[numero].SetActive(true);
    }
   
    public void SetActive()
    {
        gameObject.SetActive(true);
    }
}
