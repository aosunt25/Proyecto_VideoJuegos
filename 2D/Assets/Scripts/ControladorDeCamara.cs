using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorDeCamara : MonoBehaviour
{
    public GameObject player;       //Public variable to store a reference to the player game object
    float tlX, tlY, brX, brY;
    private Vector2 velocidad;
    private float vel = 1.75f;
    Transform target;
    private Vector3 targetPos;
    public float tiempoY;
    public float tiempoX;

    public BoxCollider2D bounds;
    private Vector3 minBound;
    private Vector3 maxBound;

    private Camera camara;
    private float halfheigth;
    private float halfwidth;

    private void Awake()
    {
    }

    void Start()
    {
            player = GameObject.FindGameObjectWithTag("Player");
            targetPos = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
        

        minBound = bounds.bounds.min;
        maxBound = bounds.bounds.max;

        camara = GetComponent<Camera>();
        halfheigth = camara.orthographicSize;
        halfwidth = halfheigth * Screen.width / Screen.height;
    }
    private void Update()
    {
        targetPos = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPos, vel * Time.deltaTime);
        float clampX = Mathf.Clamp(transform.position.x, minBound.x + halfwidth, maxBound.x - halfwidth);
        float clampY = Mathf.Clamp(transform.position.y, minBound.y + halfheigth, maxBound.y - halfheigth);   
        transform.position = new Vector3(clampX, clampY, transform.position.z);

    }  
    public void SetBound(GameObject map)
    {
        Tiled2Unity.TiledMap config = map.GetComponent<Tiled2Unity.TiledMap>();
        float camaraSize = Camera.main.orthographicSize;

        tlX = map.transform.position.x + camaraSize;
        tlY = map.transform.position.y - camaraSize;
        brX = map.transform.position.x + config.NumTilesWide - camaraSize;
        brY = map.transform.position.y - config.NumTilesHigh + camaraSize; 
    }
    public void SetBounds(BoxCollider2D newBounds)
    {
        bounds = newBounds;

        minBound = newBounds.bounds.min;
        maxBound = newBounds.bounds.max;
    }
    
}