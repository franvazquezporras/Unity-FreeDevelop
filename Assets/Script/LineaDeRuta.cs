using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineaDeRuta : MonoBehaviour
{
    public Transform salida;
    public Transform destino;

    private void OnDrawGizmosSelected()
    {
        if (salida != null && destino != null)
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawLine(salida.position, destino.position);

        }
    }
}
