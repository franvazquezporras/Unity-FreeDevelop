using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConjuroControl : MonoBehaviour
{
    float velocidad = 2;
    float tiempoVida = 2;
    


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
        
        if (col.gameObject.layer == Layers.ENEMIGO)
        {
            
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
    }
}
