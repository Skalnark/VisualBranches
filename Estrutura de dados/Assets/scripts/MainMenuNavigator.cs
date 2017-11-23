using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuNavigator : MonoBehaviour {

    public void GoToChooseList()
    {
        SceneManager.LoadScene("ChooseListScene"); //carrega cena de escolher qual o tipo de lista
    }

    public void GoToChainedList()
    {
        SceneManager.LoadScene("ChainedListScene"); //carrega cena de lista encadeada
    }

    public void GoToSeqList()
    {
        SceneManager.LoadScene("SeqListScene"); //carrega cena de lista encadeada
    }

    public void GoToQueue()
    {
        SceneManager.LoadScene("QueueScene");//carrega a cena da fila
    }

    public void GoToStack()
    {
        SceneManager.LoadScene("StackScene");//carrega a cena da pilha
    }

    public void GoToTree()
    {
        SceneManager.LoadScene("TreeScene");//carrega a cena da arvore
    }

    public void GoToAbout()
    {
        SceneManager.LoadSceneAsync("AboutScene"); //carrega a cena do sobre
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
