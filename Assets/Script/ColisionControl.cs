using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ColisionControl : MonoBehaviour
{
    public static bool suelo;
    MenuControl ControlNiveles;
    PlayerRespawn VidaPlayer;
    
    private void Awake()
    {
        VidaPlayer = GameObject.Find("Player").GetComponent(typeof(PlayerRespawn)) as PlayerRespawn;
        ControlNiveles = GameObject.Find("GameManager").GetComponent(typeof(MenuControl)) as MenuControl;
        
    }

  
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == Layers.INICIO)
        {
            //inicio nivel

        }
        if (col.gameObject.layer == Layers.CHECKPOINT)
        {
            //enciende el fuego del chekpoint
            col.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
        if (col.gameObject.layer == Layers.FIN && gameObject.layer ==Layers.PLAYER)
        {
            
            //Desbloquea nivel siguiente
            ControlNiveles.DesbloquearNivel();
            

        }
        if (col.gameObject.layer == Layers.ENEMIGO)
        {
            if(col.gameObject.tag == "Melee")
            {
                col.gameObject.GetComponent<IABasica>().animarAtaque();
            }

            VidaPlayer.DamageToPlayer();            
            gameObject.GetComponent<PlayerControl>().KnockBack(col.gameObject.transform.position.x);
            
            
        }

        if (col.gameObject.layer == Layers.ESTATUA)
        {
            
            col.gameObject.transform.GetChild(1).gameObject.SetActive(true);
            col.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }

    }

    //utilizar este metodo si mas de un item tienen el mismo tag y se puede pisar al mismo tiempo

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.layer == Layers.SUELO && gameObject.layer == Layers.PIES)
        {
            suelo = true;
        }
        if (col.gameObject.layer == Layers.PLATAFORMA && gameObject.layer == Layers.PIES)
        {

            GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().velocity = new Vector3(0f, 0f, 0f);
            GameObject.FindGameObjectWithTag("Player").transform.parent = col.transform;
            suelo = true;

        }
    }
    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.layer == Layers.SUELO && gameObject.layer == Layers.PIES)
        {
            suelo = false;
        }
        if(col.gameObject.layer == Layers.PLATAFORMA && gameObject.layer == Layers.PIES)
        {

            GameObject.FindGameObjectWithTag("Player").transform.parent = null;
            suelo = false;
        }
    }
}
