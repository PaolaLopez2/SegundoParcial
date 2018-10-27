using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Coin : MonoBehaviour
{
    //public static int collectableQuantity = 0;
    //Text collectableText;
    public int counterCoins;
   // bool specialTlacuaches;

    ParticleSystem collectablePart;
    //AudioSource collectableAudio;
    // Use this for initialization
    void Start()
    {

        counterCoins = 0;
        //specialTlacuaches = false;
        //collectableText = GameObject.Find("Collectable").GetComponent<Text>();
        collectablePart = GameObject.Find("CoinParticle").GetComponent<ParticleSystem>();
        //collectableAudio = GetComponentInParent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            collectablePart.transform.position = transform.position; //darle la posicion del coleccionable actual
            collectablePart.Play();//Salen las particulas
            //collectableAudio.Play(); //Suene el sonido
            gameObject.SetActive(false); //desaparece el item
            //counterCoins += 1;
            //Debug.Log(counterCoins);
            //collectableQuantity++;
            //collectableText.text = collectableQuantity.ToString(); //actualizar el texto
        }


        if (col.gameObject.CompareTag("CheckPointBoss"))
        {
            Debug.Log(col.gameObject.tag);
        }

        if (col.gameObject.CompareTag("pltMov"))
        {
            this.transform.parent = col.transform;

        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }


}
