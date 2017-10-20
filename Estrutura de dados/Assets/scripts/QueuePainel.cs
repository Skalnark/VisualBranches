using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QueuePainel : MonoBehaviour {

    //abre o painel com os numeros a serem adicionados a fila
    
    public void OpenPanel()
    {
            if(!SceneManager.GetSceneByName("numericPanel").isLoaded)
                SceneManager.LoadSceneAsync("numericPanel", LoadSceneMode.Additive);
    }

    public void ClosePanel()
    {
        SceneManager.UnloadSceneAsync("numericPanel");
    }
}
