using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventario : MonoBehaviour
{
    public EscritoDeCarta carta;
    public GameObject[] botones;
    

    public void ActivarInventario()
    {
        gameObject.SetActive(true);
    }
    public void Desactivar()
    {
        gameObject.SetActive(false);
    }
    public void checkAnswer(int bot)
    {
        carta.SetActive();
        carta.ActivarTexto(bot);
    }
    public void Continuar()
    {
        carta.Continuar();

    }
    public void ActivarBoton(int num)
    {
        botones[num - 1].SetActive(true);
    }
}

   
