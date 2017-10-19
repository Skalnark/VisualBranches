
public class Queue {
	private Node begin;
	private Node end;
	private int nElements;
	
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

		return begin.getContent();
	}

	public void push (int value) {
		GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
		Node newNode = new Node();
		newNode.setSquare(cube);
		newNode.setContent(value);

	   if (empty()){   
			begin = newNode;
			newNode.getSquare().transform.position = new Vector3(-6.3f, 0,0);
	   }
	   else {
			end.setNext(newNode);
			int pos = tamanho();
			newNode.getSquare().transform.position = new Vector3(-6.3f +(float) pos, 0, 0); 
		}
		
		end = newNode;
		nElements++;
	}

	public void pull() {
		if (empty()) {
			//printar q n tem nada na fila	        
			return; 
	    }
		
		Node p = begin;
		if (begin == end){
			Destroy(begin.getSquare());
			end = null;
			begin = null;
	 	}
	 	else{
			Destroy(begin.getSquare());	
			begin = p.getNext();
			Node aux = begin;
			int number = 0;

			while(number < (size()-1)){
				Vector3 position = this.transform.position;
				position.x--;
				aux.getSquare().transform.position = position;
				aux = aux.getNext();
				number++;
			}
	 	}	

	    p= null;
	    nElements--;
	}	
}
