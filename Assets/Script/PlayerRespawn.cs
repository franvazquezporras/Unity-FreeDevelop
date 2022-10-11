using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerRespawn : MonoBehaviour
{
    
    public Animator anim;
    public GameObject[] vidas;
    private int vida;

    private Image VidaOn; 
    private Image VidaOff;
    void Start()
    {
        vida = vidas.Length;
        
        if (PlayerPrefs.GetFloat("checkPointPosX") != 0)
        {
            transform.position = (new Vector2(PlayerPrefs.GetFloat("checkPointPosX"), PlayerPrefs.GetFloat("checkPointPosY")));
        }
    }

    private void checkVidas(int vida)
    {
    
        if (vida == 0)
        {            
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            vidas[vida].gameObject.SetActive(false);
            anim.Play("HURT");
        }
        
    }
    public void checkingPoint(float x, float y)
    {
        //Guardamos la info del checkpoint
        PlayerPrefs.SetFloat("checkPointPosX", x);
        PlayerPrefs.SetFloat("checkPointPosY", y);
    }


    public void DamageToPlayer()
    {
        vida--;
        checkVidas(vida);
    }

}
