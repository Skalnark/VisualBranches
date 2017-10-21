using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Queue : MonoBehaviour{
	private Node begin;
	private Node end;
	public int nElements;
    public GameObject objeto;

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
        GameObject cube = Instantiate(objeto);
		Node newNode = new Node();
		newNode.setSquare(cube);
		newNode.content =  value;
        cube.GetComponentInChildren<TextMesh>().text = ""+ newNode.content;

	   if (empty()){   
			begin = newNode;
            end = newNode;
            newNode.getSquare().transform.position = new Vector3(-6.3f, 0,0);
	   }else
        {
			end.setNext(newNode);
            end = newNode;
			int pos = size();
			newNode.getSquare().transform.position = new Vector3(-6.3f + pos, 0, 0); 
		}

        Debug.Log("end é igual a:" + end.content);
	
		nElements++;
	}

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
        }
	 	else
        {
            begin = begin.getNext();

            Node aux = begin;
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
}
