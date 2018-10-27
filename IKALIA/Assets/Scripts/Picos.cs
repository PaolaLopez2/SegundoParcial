using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Picos : MonoBehaviour
{

    float dirX, moveSpeed = 3f;
    bool moveUp = false;
    float initialPosition;


    // Use this for initialization
    void Start()
    {
        initialPosition = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.y > (initialPosition + 0.5f))
        {
            moveUp = false;
        }
        if (transform.position.y < (initialPosition - 5.5f))
        {
            moveUp = true;
        }

        if (moveUp)
        {
            transform.position = new Vector2(transform.position.x , transform.position.y + moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = new Vector2(transform.position.x , transform.position.y - moveSpeed * Time.deltaTime);
        }

    }
}

