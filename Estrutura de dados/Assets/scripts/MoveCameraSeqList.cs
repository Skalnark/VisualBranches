using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCameraSeqList : MonoBehaviour {

    public GameObject eventSystem;
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
    GameObject camera;
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword
    float horizontal;

    // Use this for initialization
    void Start () {
        camera = gameObject;
        camera.GetComponent<Transform>();
        eventSystem.GetComponent<Queue>();
    }
	
	// Update is called once per frame
	void Update () {

        horizontal = Input.GetAxis("Horizontal");


        if (camera.transform.position.x >= 0)
        {
            if (Input.GetAxis("Horizontal") < 0)
                camera.transform.position += new Vector3(horizontal / 2, 0f, 0f);
        }
        if (camera.transform.position.x < eventSystem.GetComponent<SeqList>().maxSize - 13)
        {
            if (Input.GetAxis("Horizontal") > 0)
                camera.transform.position += new Vector3(horizontal / 2, 0f, 0f);
        }

    }
}
