using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {

	public int content;
	public GameObject square;
	public Node next;

	public Node getNext(){
		return this.next;
	}

	public void setNext(Node nextCube){
		this.next = nextCube;
	}

	public GameObject getSquare(){
		return this.square;
	}

	public void setSquare(GameObject nextSquare){
		this.square = nextSquare;
	}
}
