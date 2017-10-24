using UnityEngine;
using UnityEngine.UI;

public class SearchList : MonoBehaviour {

    public GameObject inputObject;
    public GameObject positionButtonObject;
    public GameObject elementButtonObject;
    public GameObject textFieldElementObject;
    public GameObject textFieldPositionObject;
    public InputField valueElementInput;
    public InputField valuePositionInput;

    public void WhereIsAt()
    {
        try
        {
            inputObject.GetComponent<LDE>().whereIsAt(int.Parse(valueElementInput.text));
        }
        catch (System.Exception e)
        {
            Debug.Log(e);
        }
        valueElementInput.text = "";
        textFieldElementObject.SetActive(false);
    }

    public void Element()
    {
        try
        {
            inputObject.GetComponent<LDE>().element(int.Parse(valuePositionInput.text));
        }
        catch (System.Exception e)
        {
            Debug.Log(e);
        }
        valuePositionInput.text = "";
        textFieldPositionObject.SetActive(false);
    }


    public void ShowSearchButtons()
    {
        bool clicked = false;
        if (clicked)
        {
            positionButtonObject.SetActive(false);
            elementButtonObject.SetActive(false);
        }
        else
        {
            positionButtonObject.SetActive(true);
            elementButtonObject.SetActive(true);
            clicked = true;
        }
    }

    public void ShowElementInput()
    {
        positionButtonObject.SetActive(false);
        elementButtonObject.SetActive(false);
        textFieldElementObject.SetActive(true);
    }

    public void HideElementInput()
    {
        valuePositionInput.text = "";
        textFieldElementObject.SetActive(false);
    }

    public void ShowPositionInput()
    {
        positionButtonObject.SetActive(false);
        elementButtonObject.SetActive(false);
        textFieldPositionObject.SetActive(true);
    }

    public void HidePositionInput()
    {
        valuePositionInput.text = "";
        textFieldPositionObject.SetActive(false);
    }

}
