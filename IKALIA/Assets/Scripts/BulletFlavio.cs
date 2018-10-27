using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFlavio : MonoBehaviour {

    public float velX = 5f;
    float velY = 0f;
    Rigidbody2D rb;
    ParticleSystem particulas;


    // Use this for initialization
    void Start () {

        rb = GetComponent<Rigidbody2D>();
        particulas = GameObject.Find("BulletParticle").GetComponent<ParticleSystem>();

    }
	
	// Update is called once per frame
	void Update () {

        rb.velocity = new Vector2(velX, velY);
        Destroy(gameObject, 3f);
		
	}

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Colmillo") || 
            collision.gameObject.CompareTag("Enemy") || 
            collision.gameObject.CompareTag("OlmecaRoja"))
        {

            particulas.transform.position = transform.position;
            particulas.Play();
            Destroy(gameObject);

        }
    }
}
