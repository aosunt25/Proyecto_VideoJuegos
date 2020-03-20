using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoAactivarConE : MonoBehaviour
{
    public GameObject carta;
    private bool colision = false;

   
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (colision)
            {
                activarCarta();
                Destroy(gameObject);
            }

        }
        if (carta == null)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == GameMaster.instance.GetClonePLayere())
        {
            colision = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        colision = false;
    }
    private void activarCarta()
    {
             carta.SetActive(true);
             
    }

}
