using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuroConLlave : MonoBehaviour
{
    public GameObject llave;

    private void Update()
    {
        if (llave.activeInHierarchy == false)
        {
            Destroy(gameObject);
        }
    }
}
