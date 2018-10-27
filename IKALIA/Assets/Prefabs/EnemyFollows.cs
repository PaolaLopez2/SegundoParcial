using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollows : MonoBehaviour {


    public float speed = 10;
    float initialPosition;
    private Transform target; //player
    public bool canMove;
    private int bulletsCount;
    public bool enemyHit;
    public GameObject splash;



    // Use this for initialization
    void Start () {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        canMove = true;
        initialPosition = transform.position.x;

        bulletsCount = 0;
        enemyHit = false;

        
	}
	
	// Update is called once per frame
	void Update () {

        if (transform.position.x > (initialPosition + 4f))
        {
            canMove = false;
        }
        if (transform.position.x < (initialPosition - 4f))
        {
            canMove = true;
        }




        if (canMove)
        {
            if (Vector2.Distance(transform.position, target.position) < 8 && Vector2.Distance(transform.position, target.position) > 3)
            {
                //(from, to)
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

            }

        }
     
     

            

	}

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Rollo"))
        {
         
            bulletsCount++;
            
            colorPlayerHit();
            moveEnemyHit();

            if (bulletsCount == 3)
            {
                Instantiate(splash, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
           
        }
    }

    void colorPlayerHit()
    {

        GetComponent<SpriteRenderer>().color = new Color32(255, 190, 210, 255);
        enemyHit = true;


    }

    void moveEnemyHit()

    {

        Vector3 temp = new Vector3(-3.0f, 0, 0);

        if (Input.GetAxis("Horizontal") < 0)
        {
            this.transform.position += -(temp);

        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            this.transform.position += temp;
        }


    }



}
