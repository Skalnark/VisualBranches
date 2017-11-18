using System.Collections;
using UnityEngine;

public class BinaryTree : MonoBehaviour {

    public GameObject objetoBegin;
    private Node root;
    private Color foward;
    public Material shinyTexture;
    public Material normalTexture;
    private int depth;

    //Abrir a tela do PopUp
    private bool showPopUp = false;
    //Colocar o label de lista vazia
    private bool emptyPopUp = false;
    //Colocar o label de posição invalida
    private bool wrongPositionPopUp = false;
    //Colocar o label de elemento invalido
    private bool wrongElementPopUp = false;


    public BinaryTree()
    {
        depth = 0;
        root  = null;
        //foward = new Color(0, 1, 0);
    }

    public bool empty()
    {
        if (root == null)
             return true;
        else
            return false;
    }

    public void insert (int value)
    {
        GameObject leaf = Instantiate(objetoBegin);
        Node newNode = new Node();
        newNode.content = value;
        newNode.setSquare(leaf);
        leaf.GetComponentInChildren<TextMesh>().text = "" + newNode.content;

        if (empty())
        {
            root = newNode;
            newNode.getSquare().transform.position = new Vector3(-0.5f, 4.5f, 0);
            return;
        }

        Node aux = root;
        Node p = null;
        depth = 0;
        while (aux != null)
        {
            depth++;
            p = aux;
            if (value < aux.content)
                aux = aux.getPrevious(); //Esquerda
            else
                aux = aux.getNext(); //Direita
        }

        if (value < p.content)
        {
            p.setPrevious(newNode); //Coloca o nó na esquerda do pai
            Vector3 position = p.getSquare().transform.position;
            position.y -= 1.5f;
            position.x -= (3.0f / depth);
            newNode.getSquare().transform.position = position;

        }
        else
        {
            p.setNext(newNode); //Coloca o nó na direita do pai
            Vector3 position = p.getSquare().transform.position;
            position.y -= 1.5f;
            position.x += (3.0f / depth);
            newNode.getSquare().transform.position = position;
        }
        return;
    }

    public Node search(Node T, int value)
    {
        Node aux;

        //stop conditions
        if (T == null)
        {
            return null;
        }

        if (T.content == value)
        {
            return T;
        }

        //Recursive case
        aux = search(T.getPrevious(), value); //Esquerda
        if (aux == null)
        {
            aux = search(T.getNext(), value); //Direita
        }
        return aux;
    }
}