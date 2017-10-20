using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class showInputField : MonoBehaviour {

	public void OpenField (GameObject input) {

        Instantiate(input, new Vector3(10f, 7f, 0f), Quaternion.identity);
	}

    public void CloseField(GameObject input)
    {
        Destroy(input);
    }
}
