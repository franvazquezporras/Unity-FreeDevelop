using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlechaControl : MonoBehaviour
{
    float velocidad = 3;
    float tiempoVida = 5;



    private void Start()
    {
        Destroy(gameObject, tiempoVida);
    }
    private void Update()
    {
        transform.Translate(Vector2.right * velocidad * Time.deltaTime);

    }


    private void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.layer == Layers.PLAYER)
        {
            Destroy(gameObject);
        }
    }
}
