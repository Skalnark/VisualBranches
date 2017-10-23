using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinRightRound : MonoBehaviour {

    int side;

    public float speed = 500;

    public void start(int s)
    {
        side = s;
        Update();
    }

    // Update is called once per frame
    void Update () {

        if (side % 2 == 0) {
            transform.Rotate(Vector3.back, speed * Time.deltaTime);
            Wait();
            transform.position += new Vector3(0.1f, 0, 0);
        }
        else {
            transform.Rotate(Vector3.forward, speed * Time.deltaTime);
            Wait();
            transform.position += new Vector3(-0.1f, 0, 0);
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSecondsRealtime(0.5f);
    }
}
