using UnityEngine;
using UnityEngine.UI;

public class ListPushAndPull : MonoBehaviour
{
    public GameObject inputObject;
    public GameObject textFieldAddObject;
    public GameObject textFieldRemoveObject;
    public GameObject textFieldRSizeObject;
    public GameObject SizeButton;
    public GameObject AddButton;
    public GameObject RemoveButton;
    public GameObject SearchButton;
    public InputField valueInput;
    public InputField posAddInput;
    public InputField posRemoveInput;
    public InputField sizeAddInput;

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
        valueInput.text = "";
        posAddInput.text = "";
        textFieldAddObject.SetActive(false);

    }

    public void PushSeqList()
    {
        try
        {
            inputObject.GetComponent<SeqList>().insert(int.Parse(posAddInput.text), int.Parse(valueInput.text));
        }
        catch (System.Exception e)
        {
            Debug.Log(e);
        }
        valueInput.text = "";
        posAddInput.text = "";
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
        posRemoveInput.text = "";
        textFieldRemoveObject.SetActive(false);
    }

    public void RemoveSeqList()
    {
        try
        {
            inputObject.GetComponent<SeqList>().remove(int.Parse(posRemoveInput.text));
        }
        catch (System.Exception e)
        {
            Debug.Log(e);
        }
        posRemoveInput.text = "";
        textFieldRemoveObject.SetActive(false);
    }

    public void SizeList()
    {
        try
        {
            inputObject.GetComponent<SeqList>().insertSize(int.Parse(sizeAddInput.text));
        }
        catch (System.Exception e)
        {
            Debug.Log(e);
        }
        sizeAddInput.text = "";
        textFieldRSizeObject.SetActive(false);
        AddButton.SetActive(true);
        RemoveButton.SetActive(true);
        SearchButton.SetActive(true);
        SizeButton.SetActive(false);
    }

    public void HideAddInput()
    {
        textFieldAddObject.SetActive(false);
        valueInput.text = "";
        posAddInput.text = "";
    }

    public void HideRemoveInput()
    {
        textFieldRemoveObject.SetActive(false);
        posRemoveInput.text = "";
    }

    public void HideSizeInput()
    {
        textFieldRSizeObject.SetActive(false);
        sizeAddInput.text = "";
    }

    public void ShowAddInput()
    {
        textFieldAddObject.SetActive(true);
    }

    public void ShowRemoveInput()
    {
        textFieldRemoveObject.SetActive(true);
    }

    public void ShowSizeInput()
    {
        textFieldRSizeObject.SetActive(true);
    }

}
