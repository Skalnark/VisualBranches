using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stack : MonoBehaviour{
    private Node top;
    public int nElements;
    public GameObject objetoBegin;
    public GameObject camera;
    public float speed;

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
            newNode.getSquare().transform.position = new Vector3(0, -3, 0);
        }
        else
        {
            newNode.setNext(top);
            newNode.getSquare().transform.position = new Vector3(0, 6 + (float)size(), 0);
            float target = -7 + (size()/ 2);
            StartCoroutine(ConsertarPosicao(newNode.getSquare().transform, target));
        }

        if (size() > 17)
        {
            Debug.Log("leu aqui"); 
            StartCoroutine(MoveCameraWhenPush(camera.transform, camera.transform.position.y + 1.2f));
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

        Destroy(p.getSquare());

        nElements--;

        p = null;

        if (size() > 18 && camera.transform.position.y > 0)
            camera.transform.position += new Vector3(0, -1, 0);
}


    IEnumerator ConsertarPosicao(Transform objeto, float target)
    {
        while(objeto.transform.position.y != target)
        {
            yield return new WaitForSecondsRealtime(3);
            if (objeto.transform.position.y < target)
            {
                objeto.transform.position = new Vector3(0, target, 0);
            }
        }
        yield return new WaitForSecondsRealtime(1);
    }

    IEnumerator MoveCameraWhenPush(Transform camera, float target)
    {
        while (camera.position.y != target)
        {
            if (camera.position.y > target)
            {
                yield return new WaitForSeconds(0);
                camera.position += new Vector3(0, Time.deltaTime * size(), 0);
            }
            else
            {
                camera.position = new Vector3(0, target, -10);
            }
        }
    }
}
