using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara_System : MonoBehaviour
{

    public  GameObject player;
    public Vector2 minCamPos, maxCamPos;
    public float smoothTime;


    private Vector2 velocity;


    // Use this for initialization
    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player");


    }

    // Update is called once per frame

    void FixedUpdate()
    {

        float posX = Mathf.SmoothDamp(transform.position.x,
            player.transform.position.x, ref velocity.x, smoothTime);

        float posY = Mathf.SmoothDamp(transform.position.y,
           player.transform.position.y, ref velocity.y, smoothTime);

        transform.position = new Vector3(
            Mathf.Clamp(posX, minCamPos.x, maxCamPos.x),
            Mathf.Clamp(posY, minCamPos.y, maxCamPos.y),
            transform.position.z);

    }



}
