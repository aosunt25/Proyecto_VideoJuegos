using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerConversaciones : MonoBehaviour
{
    public Oraciones oraciones;
    private bool colision = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (colision)
            {
                TriggerDialogo();
            }

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == GameMaster.instance.GetClonePLayere())
        {
            colision = true;
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        colision = false;
    }


    public void TriggerDialogo()
    {
        FindObjectOfType<ConversacionesManager>().StartDialogo(oraciones);
    }
}
