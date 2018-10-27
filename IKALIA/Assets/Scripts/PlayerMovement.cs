using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {
    public Rigidbody2D playerRigidBody;
    public float speed = 15f;
    public float jumpSpeed = 50;

    private float moveInput; //detect wheather or not is left or right
    public Animator playerAnim;
    


    //jump
    public bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    public static bool isFlip;

    private int extraJumps;
    public int extraJumpsvalue;

    //animation-fall
    // private bool justJumped;

    //BULLET
    public GameObject rolloRight;
    public GameObject rolloLeft;
    public Vector2 bulletPos;
    public float fireRate = 0.5f;
    public float nextFire = 0.0f;

    public GameObject tlacuacheRabia;
    public GameObject tlacuacheAtaca;

    private int numTlacuachesRabia;
    private int numTlacuachesAtaca;

    private int countTlacuachesRabia;
    private int countTlacuachesAtaca;



    //MONEDAS
    public int counterCoins;
    public Image imagenMonedas1;
    public Image imagenMonedas2;

    //tlacuaches
    public bool activateTlacuaches;

    //TIEMPO 
    public Text timerText;
    private float startTime;
    private bool finnished = false;




    // Use this for initialization
    void Start () {
        playerRigidBody = GetComponent<Rigidbody2D>();
        extraJumps = extraJumpsvalue;
        isFlip = false;

        imagenMonedas1 = GameObject.Find("Numeros").GetComponent<Image>();
        imagenMonedas2 = GameObject.Find("Numeros1").GetComponent<Image>();


        //justJumped = false;
        activateTlacuaches = false;

        countTlacuachesRabia = 0;
        countTlacuachesAtaca = 0;

        //TIEMPO
        startTime = Time.time;
}
	
	// Update is called once per frame
	void FixedUpdate () {

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        playerRigidBody.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, playerRigidBody.velocity.y);


        if (Input.GetAxis("Horizontal") == 0)
        {
            
            playerAnim.SetBool("isWalking", false);
            
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
           
            
            playerAnim.SetBool("isWalking", true);
            
            GetComponent<SpriteRenderer>().flipX = true;
            
            isFlip = true;
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            
            playerAnim.SetBool("isWalking", true);
            GetComponent<SpriteRenderer>().flipX = false;
            isFlip = false;
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            //GetComponent<AudioSource>().Play();
            //playerAnim.SetBool("isJumping", true);
            playerAnim.SetTrigger("IsJumping");
            playerRigidBody.AddForce(Vector2.up * jumpSpeed);
            //justJumped = true;
            isGrounded = false;
            //playerAnim.SetTrigger("Jump");

        }

     

        
    }

    void Update()
    {
        if (isGrounded == true)
        {
            extraJumps = extraJumpsvalue;
            playerAnim.SetTrigger("idle");
            playerAnim.SetBool("escaleras", false);

        }
        if (Input.GetKeyDown(KeyCode.Space) && extraJumps > 0)
        {
            playerRigidBody.velocity = Vector2.up * jumpSpeed;
            extraJumps--;



        }else if (Input.GetKeyDown(KeyCode.Space) && extraJumps == 0 && isGrounded == true)
        {
            playerRigidBody.velocity = Vector2.up * jumpSpeed;
        }

        
        if (isGrounded == false && (Input.GetAxis("Horizontal") < 0 || Input.GetAxis("Horizontal") > 0))
        {
            
            playerAnim.SetBool("isWalking", false);

        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && Time.time > nextFire)
        {

            nextFire = Time.time + fireRate;
            fireRollo();

        }

        if (Input.GetKey(KeyCode.X) && Time.time > nextFire && activateTlacuaches == true)
        {

            if (countTlacuachesRabia < numTlacuachesRabia)
            {
                nextFire = Time.time + fireRate;
                fireTlacuacheRabia();
                countTlacuachesRabia++;

            }
        }

        if (Input.GetKey(KeyCode.Z) && Time.time > nextFire && activateTlacuaches == true)
        {
            if (countTlacuachesAtaca < numTlacuachesAtaca)
            {
                nextFire = Time.time + fireRate;
                fireTlacuacheAtaca();
                countTlacuachesAtaca++;
            }

        }

        //Time
        if (finnished == false)
        {
            float t = Time.time - startTime;

            string minutes = ((int)t / 60).ToString();
            string seconds = (t % 60).ToString("f2");

            timerText.text = minutes + ":" + seconds;

        }
      

    }

    public void Finnish()
    {
        finnished = true;
        timerText.color = Color.yellow;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Lodo"))

        {

            Debug.Log("Lodo");
            this.speed = 3;
            if (GetComponent<PlayerMovement>().isGrounded)
            {

                


            }

        }
        else
        {
            this.speed = 15;
        }
        

        if (collision.gameObject.CompareTag("pltMov"))
        {
            this.transform.parent = collision.transform;

        }

        if (collision.gameObject.CompareTag("CheckPointBoss"))
        {
            activateTlacuaches = true;
            countMonedas();
        }

        if (collision.gameObject.CompareTag("EndLevel"))
        {
            finnished = true;
        }



    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("pltMov"))
        {
            this.transform.parent = null;
        }
        if (collision.gameObject.CompareTag("Abismo"))
        {
            Destroy(gameObject);
        }
    }



    public void fireRollo()
    {
        bulletPos = transform.position;

        if (isFlip == false)
        {
            bulletPos += new Vector2(1f, -0.437f);
            Instantiate(rolloRight, bulletPos, Quaternion.identity);
        }
        else if (isFlip == true)
        {
            bulletPos += new Vector2(-1f, -0.437f);
            Instantiate(rolloLeft, bulletPos, Quaternion.identity);
        }
    }

    public void fireTlacuacheRabia()
    {

        bulletPos = transform.position;

        if (isFlip == false)
        {
            bulletPos += new Vector2(1f, -0.2f);
            Instantiate(tlacuacheRabia, bulletPos, Quaternion.identity);
        }
        

    }

    public void fireTlacuacheAtaca()
    {

        bulletPos = transform.position;

        if (isFlip == false)
        {
            bulletPos += new Vector2(1f, -0.2f);
            Instantiate(tlacuacheAtaca, bulletPos, Quaternion.identity);
        }


    }



    void movePlayerHit()

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

    public void countMonedas()
    {
        if (counterCoins == 15)
        {
            numTlacuachesAtaca = 3;
            numTlacuachesRabia = 3;
        }else if (counterCoins >= 10 && counterCoins < 15)
        {
            numTlacuachesAtaca = 2;
            numTlacuachesRabia = 2;
        }else if (counterCoins >=5 && counterCoins < 10)
        {
            numTlacuachesAtaca = 1;
            numTlacuachesRabia = 1;
        }
        else
        {
            numTlacuachesAtaca = 0;
            numTlacuachesRabia = 0;
        }
        

    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Coin")
        {
            counterCoins++;
            if(counterCoins == 1)
            {
                imagenMonedas1.sprite = Resources.Load<Sprite>("Sprites/0");
                imagenMonedas2.sprite = Resources.Load<Sprite>("Sprites/1");
            }else if( counterCoins == 2)
            {
                imagenMonedas1.sprite = Resources.Load<Sprite>("Sprites/0");
                imagenMonedas2.sprite = Resources.Load<Sprite>("Sprites/2");
            }
            else if (counterCoins == 3)
            {
                imagenMonedas1.sprite = Resources.Load<Sprite>("Sprites/0");
                imagenMonedas2.sprite = Resources.Load<Sprite>("Sprites/3");
            }
            else if (counterCoins == 4)
            {
                imagenMonedas1.sprite = Resources.Load<Sprite>("Sprites/0");
                imagenMonedas2.sprite = Resources.Load<Sprite>("Sprites/4");
            }
            else if (counterCoins == 5)
            {
                imagenMonedas1.sprite = Resources.Load<Sprite>("Sprites/0");
                imagenMonedas2.sprite = Resources.Load<Sprite>("Sprites/5");

            }
            else if (counterCoins == 6)
            {
                imagenMonedas1.sprite = Resources.Load<Sprite>("Sprites/0");
                imagenMonedas2.sprite = Resources.Load<Sprite>("Sprites/6");
            }
            else if (counterCoins == 7)
            {
                imagenMonedas1.sprite = Resources.Load<Sprite>("Sprites/0");
                imagenMonedas2.sprite = Resources.Load<Sprite>("Sprites/7");
            }
            else if (counterCoins == 8)
            {
                imagenMonedas1.sprite = Resources.Load<Sprite>("Sprites/0");
                imagenMonedas2.sprite = Resources.Load<Sprite>("Sprites/8");
            }
            else if (counterCoins == 9)
            {
                imagenMonedas1.sprite = Resources.Load<Sprite>("Sprites/0");
                imagenMonedas2.sprite = Resources.Load<Sprite>("Sprites/9");
            }
            else if (counterCoins == 10)
            {
                imagenMonedas1.sprite = Resources.Load<Sprite>("Sprites/1");
                imagenMonedas2.sprite = Resources.Load<Sprite>("Sprites/0");
            }
            else if (counterCoins == 11)
            {
                imagenMonedas1.sprite = Resources.Load<Sprite>("Sprites/1");
                imagenMonedas2.sprite = Resources.Load<Sprite>("Sprites/1");
            }
            else if (counterCoins == 12)
            {
                imagenMonedas1.sprite = Resources.Load<Sprite>("Sprites/1");
                imagenMonedas2.sprite = Resources.Load<Sprite>("Sprites/2");
            }
            else if (counterCoins == 13)
            {
                imagenMonedas1.sprite = Resources.Load<Sprite>("Sprites/1");
                imagenMonedas2.sprite = Resources.Load<Sprite>("Sprites/3");
            }
            else if (counterCoins == 14)
            {
                imagenMonedas1.sprite = Resources.Load<Sprite>("Sprites/1");
                imagenMonedas2.sprite = Resources.Load<Sprite>("Sprites/4");
            }
            else if (counterCoins == 15)
            {
                imagenMonedas1.sprite = Resources.Load<Sprite>("Sprites/1");
                imagenMonedas2.sprite = Resources.Load<Sprite>("Sprites/5");
            }
        }
    }

}
