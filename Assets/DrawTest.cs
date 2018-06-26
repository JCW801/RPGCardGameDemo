using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawTest : MonoBehaviour {

    // Use this for initialization
    public GameObject cube;
    public GameObject target;
	void Start () {
        Vector3[] vector3s = { cube.transform.position, target.transform.position };
        transform.GetComponent<LineRenderer>().SetPositions(vector3s);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
