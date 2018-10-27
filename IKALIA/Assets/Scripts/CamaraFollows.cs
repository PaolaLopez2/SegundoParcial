using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraFollows : MonoBehaviour {

    [SerializeField]
    private float xMax;

    [SerializeField]
    private float yMax;

    [SerializeField]
    private float xMin;

    [SerializeField]
    private float yMin;

    private float zVal;


    private Transform target;

    // Use this for initialization
    void Start () {


        target = GameObject.Find("Flavio").transform;
		
	}
	
	// Update is called once per frame
	void LateUpdate () {

        transform.position = new Vector3(Mathf.Clamp(target.position.x, xMin, xMax), Mathf.Clamp(target.position.y, yMin, yMax), transform.position.z);

		
	}
}
