using UnityEngine;
using UnityEngine.UI;

public class TreeInsert : MonoBehaviour {

    public GameObject inputObject;
    public GameObject textFieldAddObject;
    public GameObject textFieldSearchObject;
    public InputField valueInput;
    public InputField searchInput;

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

    public void BTreeSearch()
    {
        try
        {
            inputObject.GetComponent<BinaryTree>().searchRoot(int.Parse(searchInput.text));
        }
        catch (System.Exception e)
        {
            Debug.Log(e);
        }
        searchInput.text = "";
        textFieldSearchObject.SetActive(false);

    }

    public void HideSearchInput()
    {
        textFieldSearchObject.SetActive(false);
        searchInput.text = "";
    }

    public void ShowSearchInput()
    {
        textFieldSearchObject.SetActive(true);
    }
}
