using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour {

    public GameObject eventSystem;
    GameObject camera;
    float horizontal;

	void Start () {
        camera = gameObject;
        camera.GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update () {

        horizontal = Input.GetAxis("Horizontal");

        //Debug.Log((int)Mathf.Sqrt(Mathf.Pow((eventSystem.GetComponent<Queue>().size() - 10), 2)));

        if (camera.transform.position.x >= 0)
        {
            if(Input.GetAxis("Horizontal") < 0)
                camera.transform.position += new Vector3(horizontal / 2, 0f, 0f);
        }
        if(camera.transform.position.x < eventSystem.GetComponent<Queue>().size()-13)
        {
            if(Input.GetAxis("Horizontal") > 0)
                camera.transform.position += new Vector3(horizontal / 2, 0f, 0f);
        }
	}
}
