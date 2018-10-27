using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraBullet : MonoBehaviour
{
    public GameObject player;
    private Rigidbody2D playerTrans;
    public float ballSpeed;
    private Rigidbody2D theRB;

    //public GameObject ballEffect;
    public float bulletLife;

    private void Awake()
    {
        theRB = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerTrans = player.GetComponent<Rigidbody2D>();
    }
    // Use this for initialization
    void Start()
    {
 
        if (playerTrans.velocity.x > 0)
        {
            Debug.Log("derecha");
            theRB.velocity = new Vector2(ballSpeed, theRB.velocity.y);
        }
        else if(playerTrans.velocity.x < 0)
        {
            Debug.Log("izq");
            theRB.velocity = new Vector2(-ballSpeed, theRB.velocity.y);
        }
        

    }

    // Update is called once per frame
    void Update()
    {

        //direction
        //bulletLife -= Time.deltaTime;

        //if (bulletLife == 0)
        //{ 
        //Instantiate(ballEffect, transform.position, transform.rotation);
        //}

       Destroy(gameObject, bulletLife);
       
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        //when bullet interacts with other collider 2d
        if (other.gameObject.tag != "Player")
        {
            //Instantiate(ballEffect, transform.position, transform.rotation);
            Destroy(gameObject);

        }




    }
    
}
