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
        Debug.Log(input.text);
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
        Debug.Log(input.text);
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
<<<<<<< HEAD

=======
    }

    public void DebugPushStack()
    {
        try
        {
            inputObject.GetComponent<Stack>().Push(Random.Range(0, 100));
        }
        catch (System.Exception e)
        {

        }
    }
    public void DebugPushQueue()
    {
        try
        {
            inputObject.GetComponent<Queue>().push(Random.Range(0, 100));
        }
        catch (System.Exception e)
        {

        }
>>>>>>> 863b05d8aa3aa7cbaffb38674dbc11bba0fc6bba
    }
}
