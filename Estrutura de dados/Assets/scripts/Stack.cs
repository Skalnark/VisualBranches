using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stack : MonoBehaviour{
    private Node top;
    public int nElements;
    public GameObject objetoBegin;

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
            Debug.Log("Você não pode remover nada da Pilha, pois ela está vazia.");
            return;
        }

        Node p = top;
        int value = p.content;
        
        if(size() == 1)
        {
            top = null;
        }else
        {
            top = p.getNext();
        }

        //DESTROI CUBO DA PILHA
        Destroy(p.getSquare());

        nElements--;

        p = null;
    }

}
