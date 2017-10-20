using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToStackScene : MonoBehaviour {

    //Esse script sai da MainScene para a StackScene
    public void OnClick()
    {
        SceneManager.LoadScene("StackScene");//carrega a cena da fila
    }
}
