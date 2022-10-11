using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SemiPlataforma : MonoBehaviour
{
    private PlatformEffector2D effector;

    public float inicioEspera;//tiempo que tarda en poder bajar de la plataforma(evitar que sea instantaneo)

    private float tiempo;

    void Start()
    {
        effector = GetComponent<PlatformEffector2D>();

    }


    void Update()
    {
        //reset tiempo espera
        if (Input.GetKeyUp("down") || Input.GetKeyUp("s"))
        {
            tiempo = inicioEspera;

        }


        //bajar de la plataforma
        if (Input.GetKey("down") || Input.GetKey("s"))
        {
            if (tiempo <= 0)
            {
                effector.rotationalOffset = 180f;
                tiempo = inicioEspera;
            }
            else
            {
                tiempo -= Time.deltaTime;
            }
        }

        //saltar de la plataforma
        if (Input.GetKey("space") || Input.GetKey("up"))
        {
            effector.rotationalOffset = 0;
        }
    }
}
