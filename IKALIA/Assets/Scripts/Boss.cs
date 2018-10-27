using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour {
    public GameObject BulletEmissor;
    public int health = 30;
    public GameObject Bala;
    public bool bossHit;
    public double timeLeft = 1;

    // Use this for initialization
    void Start () {
        InvokeRepeating("Shoot", 0, 2);
        Debug.Log(health);
        bossHit = false;
        
}
	
	// Update is called once per frame
	void Update () {


        returnBossHit();

    }
    void Shoot()
    {
        Instantiate(Bala, BulletEmissor.transform.position, Quaternion.identity);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Rollo"))
        {
            health = health - 1;
            colorBossHit();
            
            destroyBoss();
           
        }else if (collision.gameObject.CompareTag("TlacuacheRabia"))
        {
            health = health - 5;
            colorBossHit();
            destroyBoss();

        }
        else if (collision.gameObject.CompareTag("TlacuacheAtaca"))
        {
            health = health - 3;
            colorBossHit();
            destroyBoss();
        }



    }

    public void destroyBoss()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void colorBossHit()
    {

        GetComponent<SpriteRenderer>().color = new Color32(255, 190, 210, 255);
        bossHit = true;


    }
    void returnBossHit()
    {
        if (bossHit)
        {

            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                bossHit = false;
                GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);

            }
        }
        else
        {
            timeLeft = 1;

        }

    }
}
