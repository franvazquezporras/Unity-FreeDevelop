using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaInestable : MonoBehaviour
{
    public float delayCaida = 1f;
    public float delayRespawn = 5f;

    private Rigidbody2D rb2b;
    private BoxCollider2D bc2d;
    private Vector3 posicionInicial;

    // Start is called before the first frame update
    void Start()
    {
        rb2b = GetComponent<Rigidbody2D>();
        bc2d = GetComponent<BoxCollider2D>();
        posicionInicial = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        //transforma la fisica
        if (col.gameObject.layer == Layers.PLAYER)
        {
            Invoke("Caida", delayCaida);
            Invoke("Respawn", delayCaida + delayRespawn);
        }
    }

    void Caida()
    {
        rb2b.isKinematic = false;
        bc2d.isTrigger = true;
    }

    void Respawn()
    {
        transform.position = posicionInicial;
        rb2b.isKinematic = true;
        rb2b.velocity = Vector3.zero;
        bc2d.isTrigger = false;
    }
}
