using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour {
    public Transform objetivo;
    float suavizado = 5f;
    Vector3 desface;
	// Use this for initialization
	void Start () {
        desface = transform.position - objetivo.position;
	}

    // Update is called once per frame
    private void FixedUpdate()
    {
        Vector3 posicionObjetivo = objetivo.position + desface;
        transform.position = Vector3.Lerp(transform.position, posicionObjetivo, suavizado*Time.deltaTime); //interpolar vectores
    }
}
