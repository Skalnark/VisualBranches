using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuNavigator : MonoBehaviour {

    //Esse script sai da MainScene para a ListScene
    public void GoToList()
    {
        SceneManager.LoadScene("ListScene");//carrega a cena da lista
    }

    public void GoToQueue()
    {
        SceneManager.LoadScene("QueueScene");//carrega a cena da fila
    }

    public void GoToStack()
    {
        SceneManager.LoadScene("StackScene");//carrega a cena da pilha
    }

    public void GoToMain()
    {
        SceneManager.LoadSceneAsync(0); //vai para a main scene
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
}
