<<<<<<< HEAD
﻿using UnityEngine;
=======
﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
>>>>>>> 863b05d8aa3aa7cbaffb38674dbc11bba0fc6bba

public class Node : MonoBehaviour {

	public int content;
	public GameObject square;
<<<<<<< HEAD
	private Node next;
    private Node previous;

    public Node()
    {
        next = null;
        previous = null;
    }
=======
	public Node next;
>>>>>>> 863b05d8aa3aa7cbaffb38674dbc11bba0fc6bba

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

<<<<<<< HEAD
    public Node getPrevious()
    {
        return this.next;
    }

    public void setPrevious(Node previousCube)
    {
        this.next = previousCube;
=======
    internal void setPrevious(Node newNode)
    {
        throw new NotImplementedException();
    }

    internal Node getPrevious()
    {
        throw new NotImplementedException();
>>>>>>> 863b05d8aa3aa7cbaffb38674dbc11bba0fc6bba
    }
}
