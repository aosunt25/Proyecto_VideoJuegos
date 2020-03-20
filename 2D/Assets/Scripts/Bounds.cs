using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounds : MonoBehaviour
{
    private BoxCollider2D bounds;
    private ControladorDeCamara camara;
    // Start is called before the first frame update
    void Start()
    {
        bounds = GetComponent<BoxCollider2D>();
        camara = FindObjectOfType<ControladorDeCamara>();
        camara.SetBounds(bounds);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject== GameMaster.instance.GetClonePLayere())
        {
            camara.SetBounds(bounds);
            
        }
    }
}
