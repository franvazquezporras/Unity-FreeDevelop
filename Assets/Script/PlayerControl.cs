using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float velocidad = 2;
    public float fuerzaSalto = 3;

    //salto mejorado
    public bool mejorarSalto = true;
    public float saltoNormal = 0.5f;
    public float saltoMejorado = 1f;

    //doble salto
    private bool dobleSaltoDisponible;
    public float fuerzaDobleSalto = 2.5f;


    //variables ataque
    public GameObject Conjuro;
    public Transform spawnConjuro;
    


    Rigidbody2D rb2b;
    SpriteRenderer spr;
    Animator anim;
    

    private void Awake()
    {
        rb2b = GetComponent<Rigidbody2D>();
        spr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        
    }
    void Start()
    {
        transform.position = GameObject.FindGameObjectWithTag("Inicio").transform.position;
        
    }
    public void LanzarConjuro()
    {
        GameObject nuevoConjuro;
        if (spr.flipX == true)
        {
            //ataca a la izquierda
            nuevoConjuro = Instantiate(Conjuro, new Vector3(spawnConjuro.position.x-0.6f,spawnConjuro.position.y,0), new Quaternion (spawnConjuro.rotation.x,spawnConjuro.rotation.y,1,0));
        }
        else
        {
            //ataca a la derecha
            nuevoConjuro = Instantiate(Conjuro, spawnConjuro.position, spawnConjuro.rotation);
        }        
    }
    private void Update()
    {
        //salto y doble salto
        if ((Input.GetKey("space") || Input.GetKey("up")))
        {
            Salto();    
        }

        AnimarSalto();

        //atacar
        if (Input.GetKeyDown("q"))
        {
            anim.Play("ATTACK");
            LanzarConjuro();
        }

    }
    

    void AnimarSalto()
    {

        //controlar animacion salto
        if (ColisionControl.suelo == false)
        {
            anim.SetBool("Saltando", true);

        }
        else if (ColisionControl.suelo == true)
        {
            anim.SetBool("Saltando", false);
            anim.SetBool("DobleSalto", false);
            anim.SetBool("Cayendo", false);

        }

        if (rb2b.velocity.y < 0 && ColisionControl.suelo == false)
        {
            anim.SetBool("Cayendo", true);
        }
        else if (rb2b.velocity.y > 0)
        {
            anim.SetBool("Cayendo", false);
        }
    }
    void Salto()
    {
        
        if (ColisionControl.suelo)
        {
            dobleSaltoDisponible = true;
            rb2b.velocity = new Vector2(rb2b.velocity.x, fuerzaSalto);
            
        }
        else
        {
            
            if ((Input.GetKeyDown("space") || Input.GetKeyDown("up")))
            {
                if (dobleSaltoDisponible)
                {
                    anim.SetBool("DobleSalto", true);
                    rb2b.velocity = new Vector2(rb2b.velocity.x, fuerzaDobleSalto);
                    dobleSaltoDisponible = false;
                }
            }
        }
    }
    private void FixedUpdate()
    {

        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            //Movimiento derecha
            rb2b.velocity = new Vector2(velocidad, rb2b.velocity.y);
            spr.flipX = false;
            anim.SetBool("Corriendo", true);

        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            //Movimiento izquierda
            rb2b.velocity = new Vector2(-velocidad, rb2b.velocity.y);
            spr.flipX = true;
            anim.SetBool("Corriendo", true);
        }
        else
        {
            //Parado IDLE
            rb2b.velocity = new Vector2(0, rb2b.velocity.y);
            anim.SetBool("Corriendo", false);
        }


        //salto mejorado
        if (mejorarSalto)
        {
            if (rb2b.velocity.y < 0)
            {
                //pulsacion simple
                rb2b.velocity += Vector2.up * Physics2D.gravity.y * (saltoNormal) * Time.deltaTime;
            }
            if (rb2b.velocity.y > 0 && !(Input.GetKey("space") || Input.GetKey("up")))
            {
                //mantener pulsado
                rb2b.velocity += Vector2.up * Physics2D.gravity.y * (saltoMejorado) * Time.deltaTime;
            }
        }

    }

    public void KnockBack(float posicionEnemigo)
    {
        
        float lado = Mathf.Sign(posicionEnemigo - transform.position.x);
        rb2b.AddForce(Vector2.left * lado * fuerzaSalto, ForceMode2D.Impulse);
        
        Invoke("ActivarMovimiento", 0.7f);
        Color color = new Color(255 / 255f, 106 / 255f, 0 / 255f);
        spr.color = color;
    }
    void ActivarMovimiento()
    {
        
        spr.color = Color.white;
    }
}
