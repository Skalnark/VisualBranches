using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Queue : MonoBehaviour
{
    public GameObject objetoBegin;
    private Node begin;
    private Node end;
    public int nElements;
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
    public GameObject camera;
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword

    public Queue()
    {
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

    public void push(int value)
    {
        GameObject cube = Instantiate(objetoBegin);
        Node newNode = new Node();
        newNode.setSquare(cube);
        newNode.content = value;
        cube.GetComponentInChildren<TextMesh>().text = "" + newNode.content;

        if (empty())
        {
            begin = newNode;
            end = newNode;
            newNode.getSquare().transform.position = new Vector3(-6, 0, 0);
        }
        else
        {
<<<<<<< HEAD
            newNode.getSquare().transform.position = new Vector3(-6, 1, 0);
            end.setNext(newNode);
            end = newNode;
            int pos = size();
            float target = -6 + pos;

            StartCoroutine(MoveObject(newNode.getSquare().transform, target));
=======
            newNode.getSquare().transform.position = new Vector3(-6, 2, 0);
            end.setNext(newNode);
            end = newNode;
            float target = -6 + size();

            StartCoroutine(MoveObjectWhenPush(newNode.getSquare().transform, target));
>>>>>>> 863b05d8aa3aa7cbaffb38674dbc11bba0fc6bba
            if (size() > 12)
            {
                StartCoroutine(MoveCameraWhenPush(camera.transform, camera.transform.position.x + 1));
            }
        }

        nElements++;
    }

    public void pull()
    {
<<<<<<< HEAD
=======
        //se clicar em remover aqui com ele null, ele lança exceção, mas foda-se
        GameObject objeto = begin.getSquare();
        
>>>>>>> 863b05d8aa3aa7cbaffb38674dbc11bba0fc6bba
        if (empty())
        {
            Debug.Log("Você não pode remover nada da fila, pois ela está vazia.");
            return;
        }

        Node p = begin;
<<<<<<< HEAD

        if (nElements == 1)
        {
=======
        
        if (nElements == 1)
        {
            objeto.AddComponent<Rigidbody>();
            StartCoroutine(WaitNDestroy(objeto, 2));
>>>>>>> 863b05d8aa3aa7cbaffb38674dbc11bba0fc6bba
            end = null;
            begin = null;
        }
        else
        {
            begin = begin.getNext();

            Node aux = begin;
            int number = 0;

<<<<<<< HEAD
=======
            objeto.AddComponent<Rigidbody>();

>>>>>>> 863b05d8aa3aa7cbaffb38674dbc11bba0fc6bba
            while (number < (nElements - 1))
            {
                Vector3 position = aux.getSquare().transform.position;
                position.x--;
                aux.getSquare().transform.position = position;
                aux = aux.getNext();
                number++;
            }
        }

<<<<<<< HEAD
        Destroy(p.getSquare());

        p = null;
        nElements--;
    }

    //função que não tem nada a ver com a fila
    public IEnumerator MoveObject(Transform block, float target)
=======
        if (nElements > 1)
            StartCoroutine(WaitNDestroy(p.getSquare(), 3));

        p = null;
        nElements--;
         if (size() > 12 && camera.transform.position.x > 0)
            camera.transform.position += new Vector3(-1, 0, 0);
    }

    //função que não tem nada a ver com a fila
    public IEnumerator MoveObjectWhenPush(Transform block, float target)
>>>>>>> 863b05d8aa3aa7cbaffb38674dbc11bba0fc6bba
    {
        while (block.position.x != target)
        {
            if (block.position.x < target)
            {
                yield return new WaitForSecondsRealtime(0.0001f);
<<<<<<< HEAD
                block.position += new Vector3(Time.deltaTime * size(), 0, 0);
=======
                block.position += new Vector3(Time.deltaTime * size()*2, 0, 0);
>>>>>>> 863b05d8aa3aa7cbaffb38674dbc11bba0fc6bba
            }
            else
            {
                block.position = new Vector3(target, 1, 0);
            }
        }
        block.position += new Vector3(0, -1, 0);

    }

<<<<<<< HEAD
=======
    public IEnumerator WaitNDestroy(GameObject objeto, float time)
    {
        yield return new WaitForSecondsRealtime(time);
        Destroy(objeto);
    }

>>>>>>> 863b05d8aa3aa7cbaffb38674dbc11bba0fc6bba
    public IEnumerator MoveCameraWhenPush(Transform camera, float target)
    {
        while (camera.position.x != target)
        {
            if (camera.position.x < target)
            {
                yield return new WaitForSeconds(0);
<<<<<<< HEAD
                camera.position += new Vector3(Time.deltaTime, 0, 0);
=======
                camera.position += new Vector3(Time.deltaTime*size(), 0, 0);
>>>>>>> 863b05d8aa3aa7cbaffb38674dbc11bba0fc6bba
            }
            else
            {
                camera.position = new Vector3(target, 1, -2);
            }
        }
    }

}
