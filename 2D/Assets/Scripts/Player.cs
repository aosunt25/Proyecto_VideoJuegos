using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour

{
    private  Animator animacion;
    private Rigidbody2D rb2d;
    private Vector2 mov = new Vector2(23,-11);

    float speed = 1.75f;

     void Start()
    {
        //Get a component reference to the Player's animator component
        animacion = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

        void Update()
    {
        mov = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
       
        if(mov != Vector2.zero)
        {
            animacion.SetFloat("moverX", mov.x);
            animacion.SetFloat("moverY", mov.y);
            animacion.SetBool("Caminando", true);
        }
        else
        {
            animacion.SetBool("Caminando", false);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            GameMaster.instance.DesactivarPresioneE();
        }
        
       
       
    }
    private void FixedUpdate()
    {
        rb2d.MovePosition(rb2d.position + mov * speed * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "CPU")
            GameMaster.instance.ActivarPresionarE();
        
    }
    private void onCollisionExit2D(Collider2D collision)
    {
        GameMaster.instance.DesactivarPresioneE();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "MuebleAct" || collision.gameObject.tag=="Cartas")
            GameMaster.instance.ActivarPresionarE();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        GameMaster.instance.DesactivarPresioneE();
    }
    


}
