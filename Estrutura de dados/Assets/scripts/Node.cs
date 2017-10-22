using UnityEngine;

public class Node : MonoBehaviour {

	public int content;
	public GameObject square;
	private Node next;
    private Node previous;

    public Node()
    {
        next = null;
        previous = null;
    }

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

    public Node getPrevious()
    {
        return this.previous;
    }

    public void setPrevious(Node previousCube)
    {
        this.previous = previousCube;
    }
}
