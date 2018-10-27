using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMoves : MonoBehaviour {

    float dirX, moveSpeed = 3f;
    bool moveRight = true;
    float initialPosition;
    

	// Use this for initialization
	void Start () {
        initialPosition = transform.position.x; 
	}
	
	// Update is called once per frame
	void Update () {

        if (transform.position.x > (initialPosition + 4f))
        {
            moveRight = false;
        }if (transform.position.x < (initialPosition - 4f))
        {
            moveRight = true;
        }

        if (moveRight)
        {
            transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
        }
		
	}
}
