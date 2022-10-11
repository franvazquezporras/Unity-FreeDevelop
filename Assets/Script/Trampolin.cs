using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampolin : MonoBehaviour
{
    public Animator anim;
    public float fuerzaSalto = 5f;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == Layers.PLAYER)
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = (Vector2.up * fuerzaSalto);
            anim.Play("JUMPTRAMPOLIN");
        }
    }
}
