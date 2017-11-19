using UnityEngine;
using UnityEngine.UI;

public class TreeInsert : MonoBehaviour {

    public GameObject inputObject;
    public GameObject textFieldAddObject;
    public InputField valueInput;

    public void BTreeInsert()
    {
        try
        {
            inputObject.GetComponent<BinaryTree>().insert(int.Parse(valueInput.text));
        }
        catch (System.Exception e)
        {
            Debug.Log(e);
        }
        valueInput.text = "";
        textFieldAddObject.SetActive(false);

    }

    public void HideAddInput()
    {
        textFieldAddObject.SetActive(false);
        valueInput.text = "";
    }

    public void ShowAddInput()
    {
        textFieldAddObject.SetActive(true);
    }
}
