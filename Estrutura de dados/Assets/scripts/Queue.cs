using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Queue : MonoBehaviour{
    public GameObject objetoBegin;
	private Node begin;
    private Node end;
	public int nElements;
<<<<<<< HEAD
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
    public GameObject camera;
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword
=======
    public GameObject objeto;
>>>>>>> 5e861ce03920d25ca913cab3b4426580b87534bd

    public Queue() {
        nElements = 0;
	}

	public bool empty () {
		if (nElements == 0)
			return true;
		else
			return false;
	}

	public int size () {
		return nElements;
	}

	public int first () {
		if (empty())
			return -1;

		return begin.content;
	}

	public void push (int value) {
<<<<<<< HEAD
        GameObject cube = Instantiate(objetoBegin);
        Node newNode = new Node();
=======
        GameObject cube = Instantiate(objeto);
		Node newNode = new Node();
>>>>>>> 5e861ce03920d25ca913cab3b4426580b87534bd
		newNode.setSquare(cube);
		newNode.content =  value;
        cube.GetComponentInChildren<TextMesh>().text = ""+ newNode.content;

	   if (empty()){   
			begin = newNode;
            end = newNode;
            newNode.getSquare().transform.position = new Vector3(-6.3f, 0,0);
	   }else
        {
<<<<<<< HEAD
            newNode.getSquare().transform.position = new Vector3(-6, 1, 0);
            end.setNext(newNode);
=======
			end.setNext(newNode);
>>>>>>> 5e861ce03920d25ca913cab3b4426580b87534bd
            end = newNode;
			int pos = size();
			newNode.getSquare().transform.position = new Vector3(-6.3f + pos, 0, 0); 
		}

		nElements++;
	}

<<<<<<< HEAD
	public void pull() {

            GameObject objeto = begin.getSquare();

		if (empty()) {
            Debug.Log("Você não pode remover nada da fila, pois ela está vazia.");
            return; 
	    }
		
		Node p = begin;

        if (nElements == 1)
        {
            end = null;
            begin = null;
=======
	public void pull()
    {
        if (empty())
        {
            Debug.Log("Você não pode remover nada da fila, pois ela está vazia.");	        
			return; 
	    }
		
		Node p = begin;

        if (nElements == 1)
        {
			end = null;
			begin = null;
>>>>>>> 5e861ce03920d25ca913cab3b4426580b87534bd
        }
        else
        {
            begin = begin.getNext();

            Node aux = begin;
<<<<<<< HEAD
            int number = 0;

            while (number < (nElements - 1))
            {
                Vector3 position = aux.getSquare().transform.position;
                position.x--;
                aux.getSquare().transform.position = position;
                aux = aux.getNext();
                number++;
            }
        }

        Destroy(p.getSquare());

        p = null;
        nElements--;
    }	

    //função que não tem nada a ver com a fila
    public IEnumerator MoveObject(Transform block, float target)
    {
        while (block.position.x != target)
        {
            if (block.position.x < target)
            {
                yield return new WaitForSecondsRealtime(0.0001f);
                block.position += new Vector3(Time.deltaTime*size(), 0, 0);
            }
            else
            {
                block.position = new Vector3(target, 1, 0);
            }
        }
        block.position += new Vector3(0, -1, 0);

    }

    public IEnumerator MoveCameraWhenPush(Transform camera, float target)
    {
        while(camera.position.x != target)
        {
            if(camera.position.x < target)
            {
                yield return new WaitForSeconds(0);
                camera.position += new Vector3(Time.deltaTime, 0, 0);
            }
            else
            {
                camera.position = new Vector3(target, 1, -2);
            }
        }
    }

=======
			int number = 0;
            while (number < (nElements - 1)){
				Vector3 position = aux.getSquare().transform.position;
				position.x--;
				aux.getSquare().transform.position = position;
				aux = aux.getNext();
				number++;
			}
	 	}

        Destroy(p.getSquare());

        p = null;
	    nElements--;
    }
>>>>>>> 5e861ce03920d25ca913cab3b4426580b87534bd
}
