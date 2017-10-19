using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockCreator : MonoBehaviour {

	GameObject cube;
	
	void Start () {
		cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
		cube.transform.position = new Vector3 (0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		cube.transform.position += Vector3.right *0.1f;
	}
}
