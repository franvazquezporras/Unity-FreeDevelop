using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundParallax : MonoBehaviour
{
    [SerializeField]
    private Vector2 parallaxEfectoMultiplicador;
    [SerializeField]
    private bool infinitoX;
    [SerializeField]
    private bool infinitoY;
    
    private Transform camPosicion;
    private Vector3 ultimaPosicionCam;
    private float tamTexturaX;
    private float tamTexturaY;
    

    private void Start()
    {
        camPosicion = Camera.main.transform;
        ultimaPosicionCam = camPosicion.position;
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Texture2D textura = sprite.texture;
        tamTexturaX = textura.width / sprite.pixelsPerUnit;
        tamTexturaY = textura.height / sprite.pixelsPerUnit;
    }

    private void LateUpdate()
    {
        Vector3 movimiento = camPosicion.position - ultimaPosicionCam;
        transform.position += new Vector3(movimiento.x * parallaxEfectoMultiplicador.x, movimiento.y * parallaxEfectoMultiplicador.y);
        ultimaPosicionCam = camPosicion.position;
        if (infinitoX) { 
            if (Mathf.Abs(camPosicion.position.x - transform.position.x) >= tamTexturaX)
            {
                float cambiarPosicionX = (camPosicion.position.x - transform.position.x) % tamTexturaX;
                transform.position = new Vector3(camPosicion.position.x + cambiarPosicionX, transform.position.y);
            }
        }
        if (infinitoY)
        {
            if (Mathf.Abs(camPosicion.position.y - transform.position.y) >= tamTexturaY)
            {
                float cambiarPosicionY = (camPosicion.position.y - transform.position.y) % tamTexturaY;
                transform.position = new Vector3(transform.position.x, camPosicion.position.y, cambiarPosicionY);
            }
        }
        
    }
}
