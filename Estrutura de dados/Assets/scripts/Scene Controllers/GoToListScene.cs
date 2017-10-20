using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToListScene : MonoBehaviour {

    //Esse script sai da MainScene para a ListScene
    public void OnClick()
    {
        SceneManager.LoadScene("ListScene");//carrega a cena da fila
    }
}
