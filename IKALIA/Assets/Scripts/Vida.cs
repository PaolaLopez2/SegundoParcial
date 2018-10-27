using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vida : MonoBehaviour {

    [SerializeField]
    private float health;
    [SerializeField]
    private float maxHealth;
    [SerializeField]
    public Image healthBar;
    public Image flabio;
    //public GameObject FlavioLleno;
    //public GameObject FlavioMedio;
    //public GameObject FlavioMuerto;


    // Use this for initialization
    void Start () {
        health = maxHealth;
        flabio = GameObject.Find("ImagenFlavio").GetComponent<Image>();
    }
	
	void Update () {
        
        if (health <= maxHealth && health >10)
        {
            flabio.sprite = Resources.Load<Sprite>("Sprites/lifeBar1");

        }
        if (health <= 10 && health > 1)
        {

            flabio.sprite = Resources.Load<Sprite>("Sprites/lifeBar2");
        }
        if (health <= 1)
        {

            flabio.sprite = Resources.Load<Sprite>("Sprites/lifeBar3");
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            health = health - 1;
            healthBar.fillAmount = (1 / maxHealth) * health;
        }

        if (collision.gameObject.CompareTag("OlmecaRoja"))
        {
            health = health - 2;
            healthBar.fillAmount = (1 / maxHealth) * health;
        }
        if (collision.gameObject.CompareTag("Picos"))
        {

            health = health - 2;
            healthBar.fillAmount = (1 / maxHealth) * health;
        }
        if (collision.gameObject.CompareTag("Colmillo"))
        {

            health = health - 4;
            healthBar.fillAmount = (1 / maxHealth) * health;
        }

        if (health<= 0)
        {
            //Destroy(gameObject);
            
        }
    }

    
}
