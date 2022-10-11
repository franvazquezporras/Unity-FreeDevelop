using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraControl : MonoBehaviour
{
    public GameObject seguir;
    public Vector2 minCamaraPosition, maxCamaraPosition;
    public float suavizarTiempo;

    private Vector2 velocidad;

   

    private void FixedUpdate()
    {
        float posX = Mathf.SmoothDamp(transform.position.x, seguir.transform.position.x, ref velocidad.x, suavizarTiempo);
        float posY = Mathf.SmoothDamp(transform.position.y, seguir.transform.position.y, ref velocidad.y, suavizarTiempo);

        transform.position = new Vector3(
            Mathf.Clamp(posX, minCamaraPosition.x, maxCamaraPosition.x),
            Mathf.Clamp(posY, minCamaraPosition.y, maxCamaraPosition.y),
            transform.position.z);

    }
}
