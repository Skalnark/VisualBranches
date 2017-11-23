using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCameraLDE : MonoBehaviour {

    public GameObject eventSystem;
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
    GameObject camera;
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword
    float horizontal;
    public float limit;

    // Use this for initialization
    void Start()
    {
        camera = gameObject;
        camera.GetComponent<Transform>();
        eventSystem.GetComponent<Queue>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");


        if (camera.transform.position.x >= 0)
        {
            if (Input.GetAxis("Horizontal") < 0)
                camera.transform.position += new Vector3(horizontal / 3f, 0f, 0f);
        }
        if (camera.transform.position.x < eventSystem.GetComponent<LDE>().size() - 9)
        {
            if (Input.GetAxis("Horizontal") > 0)
                camera.transform.position += new Vector3(horizontal / 3f, 0f, 0f);
        }
        else if(eventSystem.GetComponent<LDE>().size() > 9)
        {
            if(camera.transform.position.x < eventSystem.GetComponent<LDE>().size() - 5)
                if (Input.GetAxis("Horizontal") > 0)
                    camera.transform.position += new Vector3(horizontal / 3f, 0f, 0f);
        }

    }
}
