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
    public float speed;
    public GameObject camera;

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
        float step = speed * Time.deltaTime;
        GameObject cube = Instantiate(objeto);
        objeto.transform.position = new Vector3(0, 0, 0);
		Node newNode = new Node();
		newNode.setSquare(cube);
		newNode.content =  value;
        cube.GetComponentInChildren<TextMesh>().text = ""+ newNode.content;

	   if (empty()){   
			begin = newNode;
            end = newNode;
            newNode.getSquare().transform.position = new Vector3(-6, 0,0);
	   }else
        {
            newNode.getSquare().transform.position = new Vector3(-6, 1, 0);
			end.setNext(newNode);
            end = newNode;
			int pos = size();
            float target = -6 + pos;

            StartCoroutine(MoveObject(newNode.getSquare().transform, target));
            if (size() > 12)
            {
                StartCoroutine(MoveCameraWhenPush(camera.transform, camera.transform.position.x + 1));
            }
		}

        Debug.Log("end é igual a:" + end.content);
	
		nElements++;
	}

	public void pull() {

        GameObject objeto = begin.getSquare();
		if (empty()) {
			//printar q n tem nada na fila	        
			return; 
	    }
		
		Node p = begin;
		if (begin == end)
        {
			end = null;
			begin = null;
            Destroy(objeto);
        }
	 	else
        {
            begin = p.getNext();
            Destroy(p.getSquare());

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
        Debug.Log("begin é igual a:" + begin.content);


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

}
