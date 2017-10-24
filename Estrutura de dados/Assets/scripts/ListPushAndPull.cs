using UnityEngine;
using UnityEngine.UI;

public class ListPushAndPull : MonoBehaviour
{
    public GameObject inputObject;
    public GameObject textFieldAddObject;
    public GameObject textFieldRemoveObject;
    public InputField valueInput;
    public InputField posAddInput;
    public InputField posRemoveInput;

    public void PushList()
    {
        try
        {
            inputObject.GetComponent<LDE>().push(int.Parse(posAddInput.text), int.Parse(valueInput.text));
        }
        catch (System.Exception e)
        {
            Debug.Log(e);
        }
        valueInput.text = null;
        posAddInput.text = null;
        textFieldAddObject.SetActive(false);

    }

    public void RemoveList()
    {
        try
        {
            inputObject.GetComponent<LDE>().remove(int.Parse(posRemoveInput.text));
        }
        catch (System.Exception e)
        {
            Debug.Log(e);
        }
        posRemoveInput.text = null;
        textFieldRemoveObject.SetActive(false);
    }

    public void HideAddInput()
    {
        textFieldAddObject.SetActive(false);
        valueInput.text = null;
        posAddInput.text = null;
    }

    public void HideRemoveInput()
    {
        textFieldRemoveObject.SetActive(false);
        posRemoveInput.text = null;
    }

    public void ShowAddInput()
    {
        textFieldAddObject.SetActive(true);
    }

    public void ShowRemoveInput()
    {
        textFieldRemoveObject.SetActive(true);
    }

}
