using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stack : MonoBehaviour{
    private Node top;
    public int nElements;
    public GameObject objetoBegin;
    public bool showPopUp = false;

    public Stack()
    {
        top = null;
        nElements = 0;
    }

    public bool empty()
    {
        if (nElements == 0)
            return true;
        else
            return false;
    }

    public int size()
    {
        return nElements;
    }

    public void Push(int value)
    {
        GameObject stack = Instantiate(objetoBegin);
        Node newNode = new Node();
        newNode.setSquare(stack);
        newNode.content = value;
        stack.GetComponentInChildren<TextMesh>().text = "" + newNode.content;

        if (empty())
        {
            //ESSES VALORES ESTÃO ASSIM POR CAUSA DA ROTAÇÃO DA CAMERA
            newNode.getSquare().transform.position = new Vector3(-0.5f, -4.9f, 0);
        }
        else
        {
            newNode.setNext(top);
            newNode.getSquare().transform.position = new Vector3(-0.5f, -4.9f + ((float)size()/2), 0);
        }
        
        top = newNode;

        nElements++;
    }

    /** Retira o elemento do topo da pilha.
	    Retorna -1 se a pilha estiver vazia.
	    Caso contrário retorna o valor removido */
    public void Pop()
    {
        if (empty())
        {
            showPopUp = true;
            return;
        }

        Node p = top;
        
        if(size() == 1)
        {
            top = null;
        }else
        {
            top = p.getNext();
        }

        //DESTROI CUBO DA PILHA
        StartCoroutine(WaitNDestroy(2, p.getSquare()));

        nElements--;

        p = null;
    }

    IEnumerator WaitNDestroy(float time, GameObject objeto)
    {
        if (nElements % 2 == 0)
            objeto.transform.position += new Vector3(2, 1, -2);
        else
            objeto.transform.position += new Vector3(-2, 1, -2);
        objeto.AddComponent<SpinRightRound>().start(nElements);
        yield return new WaitForSecondsRealtime(time);
        Destroy(objeto);
    }

    public void OnGUI()
    {
        if (showPopUp)
        {
            GUI.Window(0, new Rect((Screen.width / 2) - 150, (Screen.height / 2) - 75
                , 300, 250), ShowGUI, "ERROR MESSAGE");
            StartCoroutine(Wait());
        }
    }

    public void ShowGUI(int windowID)
    {
        GUIStyle myStyle2 = new GUIStyle();
        myStyle2.fontSize = 30;

        myStyle2.normal.textColor = Color.white;
        myStyle2.hover.textColor = Color.white;

        GUI.Label(new Rect(70, 90, 200, 100), "     Error! " + "\n" +
                                            " Pilha vazia", myStyle2);
    }

    public IEnumerator Wait()
    {
        yield return new WaitForSecondsRealtime(1);
        showPopUp = false;
    }
}