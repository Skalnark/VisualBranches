using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToMainScene : MonoBehaviour {

	//Script para voltar ao menu principal

    public void OnClick()
    {
        SceneManager.LoadSceneAsync(0); //vai para a main scene
    }
}
