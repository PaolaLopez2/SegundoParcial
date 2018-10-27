using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    
    Rigidbody2D enemyRb;
    float timeBeforeChange;
    public float delay;
    public float speed ;
    SpriteRenderer enemySpriteRend;
   
    Animator enemyAnim;
    public GameObject splash;

   
    // Use this for initialization
    void Start () {
        enemyRb = GetComponent<Rigidbody2D>();
        enemyAnim = GetComponent<Animator>();
        enemySpriteRend = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        enemyRb.velocity = Vector2.right * speed;

        if (speed > 0)
        {
            enemySpriteRend.flipX = false;

        }
        else if (speed < 0)
        {
            enemySpriteRend.flipX = true;
        }
        if (timeBeforeChange < Time.time) //tiempo desde que empezo la app
        {
            speed *= -1; //cambiar direccion
            timeBeforeChange = Time.time + delay;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {


            if (transform.position.y + 2 < collision.transform.position.y)
            {
                Debug.Log("HitByPlayer");
                Instantiate(splash, transform.position, Quaternion.identity);
                enemyAnim.SetBool("isDead", true);
                DisableEnemy();
            }
            
          
        }

        if(collision.gameObject.tag == "Rollo")
        {
            Instantiate(splash, transform.position, Quaternion.identity);

            DisableEnemy();
        }

    }

    public void DisableEnemy()
    {
        gameObject.SetActive(false);
    }
}
