using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFinal : MonoBehaviour
{
    public Oraciones oraciones;
   
    void Awake()
    {
        TriggerDialogo();
    }

    public void TriggerDialogo()
    {
        FindObjectOfType<ConversacionesManager>().StartDialogo(oraciones);
    }
}
