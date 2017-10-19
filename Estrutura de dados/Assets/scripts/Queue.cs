using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queue : MonoBehaviour {
	private Node begin;
	private Node end;
	private int nElements = 0;

	public bool empty(){
		if(nElements == 0)
			return true;
		else return false;
	}

	public int size(){
		return nElements;
	}

	public int first(){
		if(empty()){
			return -1;
		}
		return begin.content;
	}

	public void push(int value){
		Node newNode = new Node();
		newNode.content = value;

		if(empty()){
			begin = newNode;
		}
		else{
			end.setNext(newNode);
		}

		end = newNode;

		nElements++;
	}

	public void pull(){
		if(empty()){
			return;
		}
		int value = first();
		Node p = begin;

		if(begin == end){
			end = null;
			begin = null;
		}
		else{
			begin = p.getNext();
		}

		p = null;
		nElements--;
	}

}
