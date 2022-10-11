using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IABasica : MonoBehaviour
{
    public Animator anim;
    public SpriteRenderer spr;
    public float velocidad = 0.5f;
    private float tiempoEspera;
    public float inicioTiempoEspera = 2;
    public Transform[] targets;
    public float EnfriamientoAtaque;
    private float TiempoEsperadoAtaque;


    private int punto = 0;
    private Vector2 posicionActual;


    //variables ataque
    public GameObject Flecha;
    public Transform spawnFlecha;

    void Start()
    {
        tiempoEspera = inicioTiempoEspera;
    }


    void Update()
    {
        StartCoroutine(MovimientoEnemigo());
        if (targets.Length != 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, targets[punto].transform.position, velocidad * Time.deltaTime);
            Patrullar();
        }
        if(gameObject.tag == ("Rango"))
        {
            if (TiempoEsperadoAtaque <= 0)
            {                
                TiempoEsperadoAtaque = EnfriamientoAtaque;
                //animarAtaque();
                Invoke("animarAtaque", 0.6f);
                Invoke("Disparar", 0.6f);
            }
            else
            {                
                TiempoEsperadoAtaque -= Time.deltaTime;
            }
        }
        
    }
   
    public void Patrullar()
    {

        if (Vector2.Distance(transform.position, targets[punto].transform.position) < 0.1f)
        {
            if (tiempoEspera <= 0)
            {
                //recorre todos los puntos del array
                if (targets[punto] != targets[targets.Length - 1])
                {
                    punto++;
                }
                else
                {
                    punto = 0;
                }
                tiempoEspera = inicioTiempoEspera;
            }
            else
            {
                tiempoEspera -= Time.deltaTime;
            }
        }
    }

    public void animarAtaque()
    {       
            anim.Play("ATTACK");
        
    }
    public void Disparar()
    {
        GameObject nuevaFlecha;
        
        if (spr.flipX == true)
        {
            //ataca a la izquierda
            nuevaFlecha = Instantiate(Flecha, new Vector3(spawnFlecha.position.x - 0.6f, spawnFlecha.position.y, 0), new Quaternion(spawnFlecha.rotation.x, spawnFlecha.rotation.y, 1, 0));

        }
        else
        {
            //ataca a la derecha
            nuevaFlecha = Instantiate(Flecha, spawnFlecha.position, spawnFlecha.rotation);
        }
        
    }

    IEnumerator MovimientoEnemigo()
    {
        posicionActual = transform.position;

        yield return new WaitForSeconds(0.5f);

        if (transform.position.x > posicionActual.x)
        {
            spr.flipX = false;
            anim.SetBool("descansando", false);
        }
        else if (transform.position.x < posicionActual.x)
        {
            
            spr.flipX = true;
            anim.SetBool("descansando", false);
        }
        else if (transform.position.x == posicionActual.x)
        {
               
            anim.SetBool("descansando", true);
            
        }
    }
}
