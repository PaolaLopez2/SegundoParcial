using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour {
    public float Speed;
    public float stoppingDistance;
    public float startingDistance;

    ParticleSystem particulas;

    private Transform target; //player
                              // Use this for initialization
    void Start () {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        particulas = GameObject.Find("ColmilloParticle").GetComponent<ParticleSystem>();


    }

    // Update is called once per frame
    void Update () {
        //gameObject.transform.Translate(new Vector3(-1 * Speed,0,0));

        if (Vector2.Distance(transform.position, target.position) > stoppingDistance && Vector2.Distance(transform.position, target.position) < startingDistance)
        {
            //(from, to)
            transform.position = Vector2.MoveTowards(transform.position, target.position, Speed * Time.deltaTime);
          
        }
        

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            particulas.transform.position = transform.position; 
            particulas.Play();
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Rollo")){

            Destroy(gameObject);

        }
    }
}
