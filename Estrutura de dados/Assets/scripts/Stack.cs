using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stack : MonoBehaviour{
    Node top;
    int nElements;

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

    public int getTop()
    {
        if (empty())
        {
            return -1; 
        }

        return top.content;
    }

    public bool push(int value)
    {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Node newNode = new Node();
        newNode.setSquare(cube);
        newNode.content = value;

        if (empty())
        {
            //top = newNode;
            //ESSES VALORES ESTÃO ASSIM POR CAUSA DA ROTAÇÃO DA CAMERA
            newNode.getSquare().transform.position = new Vector3(-0.5f, -4.9f, 0);
        }
        else
        {
            newNode.setNext(top);
            newNode.getSquare().transform.position = new Vector3(-0.5f, -4.9f + (float) size(), 0);
        }
        
        top = newNode;

        nElements++;
        return true;
    }

    /** Retira o elemento do topo da pilha.
	    Retorna -1 se a pilha estiver vazia.
	    Caso contrário retorna o valor removido */
    public int pop()
    {
        if (empty())
        {
            return -1;
        }

        Node p = top;
        int value = p.content;
        
        //DESTROI CUBO DA PILHA
        Destroy(p.getSquare());
        if(size() == 1)
        {
            top = null;
        }else
        {
            top = p.getNext();
        }
        
        nElements--;

        p = null;

        return value;
    }

}
