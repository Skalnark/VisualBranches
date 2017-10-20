using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToQueueScene : MonoBehaviour {

	//Esse script sai da MainScene para a QueueScene
	public void OnClick() {
        SceneManager.LoadScene("QueueScene");//carrega a cena da fila
	}
	
}
