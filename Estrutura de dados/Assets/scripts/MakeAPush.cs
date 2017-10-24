using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MakeAPush : MonoBehaviour {

    public GameObject inputObject;
    public GameObject textFieldObject;
    public InputField input;

	public void PushQueue()
    {
        try
        {
            inputObject.GetComponent<Queue>().push(int.Parse(input.text));
        } catch(System.Exception e)
        {
            Debug.Log(e);
        }
        input.text = null;
        textFieldObject.SetActive(false);

    }

    public void HideInput()
    {
        textFieldObject.SetActive(false);
    }
    
    public void ShowInput()
    {
        textFieldObject.SetActive(true);
        input.text = null;
    }

    public void PushStack()
    {
        try
        {
            inputObject.GetComponent<Stack>().Push(int.Parse(input.text));
        }
        catch (System.Exception e)
        {
            Debug.Log(e);
        }
        input.text = null;
        textFieldObject.SetActive(false);

    }
}
