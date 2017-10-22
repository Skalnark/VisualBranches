using UnityEngine;
<<<<<<< HEAD

public class LDE : MonoBehaviour
{
    public GameObject objetoBegin;
    private Node begin;
    private Node end;
    public int nElements;

    public LDE()
    {
        nElements = 0;
    }

=======
using System.Collections;
using System.Collections.Generic;

public class LDE : MonoBehaviour
{


    private Node begin;
    private Node end;
    private int nElements;

    /** Verifica se a Lista está vazia */
>>>>>>> 863b05d8aa3aa7cbaffb38674dbc11bba0fc6bba
    public bool empty()
    {
        if (nElements == 0)
            return true;
        else
            return false;
    }

<<<<<<< HEAD
=======
    /**Obtém o tamanho da Lista*/
>>>>>>> 863b05d8aa3aa7cbaffb38674dbc11bba0fc6bba
    public int size()
    {
        return nElements;
    }

<<<<<<< HEAD
=======
    /** Obtém o i-ésimo elemento de uma lista
	    Retorna o valor encontrado. */
>>>>>>> 863b05d8aa3aa7cbaffb38674dbc11bba0fc6bba
    public int element(int pos)
    {

        Node aux = begin;
        int cont = 1;

        if (empty())
        {
            return -1; // Consulta falhou 
        }

        if ((pos < 1) || (pos > size()))
        {
            return -1; // Posicao invalida 
        }

        // Percorre a lista do 1o elemento até pos 
        while (cont < pos)
        {
            // modifica "aux" para apontar para o proximo elemento da lista 
            aux = aux.getNext();
            cont++;
        }

        //FAZER UMA CAIXA DE MENSAGEM QUE MOSTRE O CONTEÚDO DO CUBINHO
        return aux.content;
    }

<<<<<<< HEAD
=======
    /**Retorna a posição de um elemento pesquisado.
	    Retorna 0 caso não seja encontrado */
>>>>>>> 863b05d8aa3aa7cbaffb38674dbc11bba0fc6bba
    public int whereIsAt(int content)
    {
        /*
         * 
         * FAZER O DEMONIO DO CUBO BRILHAR
        Color clr = new Color(0, 0, 1, 1);
        Renderer renderer = aux.getSquare().GetComponent<Renderer>();
        Material newMaterial = new Material(Shader.Find("Specular"));
        *
        */
        int cont = 1;
        Node aux;

        /* Lista vazia */
        if (empty())
        {
            return -1;
        }

        /* Percorre a lista do inicio ao fim até encontrar o elemento*/
        aux = begin;
        while (aux != null)
        {
            /* Se encontrar o elemento, retorna sua posicao n;*/
            if (aux.content == content)
            {
                return cont;
            }

            /* modifica "aux" para apontar para o proximo elemento da lista */
            aux = aux.getNext();
            cont++;
        }
        /*mudar a cor do cubo
		newMaterial.color = clr;
		renderer.material = newMaterial;*/

        return -1;
    }

    /** Insere nó em lista vazia ou no inicio da lista */
<<<<<<< HEAD
    private void pushFront(int value)
    {
        GameObject cube = Instantiate(objetoBegin);
        Node newNode = new Node();
        newNode.setSquare(cube);
        newNode.content = value;
        cube.GetComponentInChildren<TextMesh>().text = "" + newNode.content;

        if (nElements == 0)
        {
            //NÃO CRIAR LINHA
            end = newNode;
            newNode.getSquare().transform.position = new Vector3(-6.3f, 0, 0);
        }
        else
        {
=======
    private bool pushFront(int value)
    {
        // Aloca memoria para novo no 
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Node newNode = new Node();
        newNode.setSquare(cube);
        newNode.content = value;

        if (empty())
        {
            //NÃO CRIAR LINHA
            end = newNode; // Nova instrucao
            newNode.getSquare().transform.position = new Vector3(-6.3f, 0, 0);

        }
        else
        {

>>>>>>> 863b05d8aa3aa7cbaffb38674dbc11bba0fc6bba
            newNode.setNext(begin);
            begin.setPrevious(newNode); // Nova instrucao	

            //MOVENDO A LISTA
            int number = size();
            Node aux = end;

            while (number > 0)
            {
<<<<<<< HEAD
=======

>>>>>>> 863b05d8aa3aa7cbaffb38674dbc11bba0fc6bba
                Vector3 position = aux.getSquare().transform.position;
                position.x = position.x + 1.5f; // 1 from the cube and 0,5 from the line
                aux.getSquare().transform.position = position;
                //LEMBRAR DE MOVER LINHA (1,5 TB)
                aux = aux.getPrevious();
                number--;
<<<<<<< HEAD
=======

>>>>>>> 863b05d8aa3aa7cbaffb38674dbc11bba0fc6bba
            }
            aux = null;

            //COLOCANDO O CUBO E A LINHA NO LUGAR
            newNode.getSquare().transform.position = new Vector3(-6.3f, 0, 0);
            //CRIAR LINHA - COM A CONDIÇÃO DE QUE TENHA MAIS DE UM OBJETO NA LISTA
        }

        begin = newNode;
        nElements++;
<<<<<<< HEAD
    }

    private void pushMiddle(int pos, int value)
    {
        GameObject cube = Instantiate(objetoBegin);
=======
        return true;
    }

    private bool pushMiddle(int pos, int value)
    {
        int cont = 1;

        // Aloca memoria para novo no
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
>>>>>>> 863b05d8aa3aa7cbaffb38674dbc11bba0fc6bba
        //CRIAR LINHA
        Node newNode = new Node();
        newNode.setSquare(cube);
        newNode.content = value;
<<<<<<< HEAD
        cube.GetComponentInChildren<TextMesh>().text = "" + newNode.content;

        if (pos > size())
        {
            Debug.Log("posição inválida");
            return;
        }

        // Localiza a pos. onde será inserido o novo nó
        Node p = begin;
        int cont = 1;
        while (cont < (pos - 1))
=======

        // Localiza a pos. onde será inserido o novo nó
        Node p = begin;
        while ((cont < pos - 1) && (p != null))
>>>>>>> 863b05d8aa3aa7cbaffb38674dbc11bba0fc6bba
        {
            p = p.getNext();
            cont++;
        }
<<<<<<< HEAD
        
=======

        if (p == null)
        {  // pos. inválida 
            return false;
        }

>>>>>>> 863b05d8aa3aa7cbaffb38674dbc11bba0fc6bba
        int number = size();
        Node aux = end;

        while (number >= pos)
        {
<<<<<<< HEAD
=======

>>>>>>> 863b05d8aa3aa7cbaffb38674dbc11bba0fc6bba
            Vector3 position = aux.getSquare().transform.position;
            position.x = position.x + 1.5f; // 1 from the cube and 0,5 from the line
            aux.getSquare().transform.position = position;
            //LEMBRAR DE MOVER LINHA (1,5 TB)
            aux = aux.getPrevious();
            number--;

        }
        aux = null;

        //COLOCANDO O CUBO E A LINHA NO LUGAR
        newNode.getSquare().transform.position = new Vector3(-6.3f + (1.5f * (pos - 1)), 0, 0);

        // Insere novo elemento apos aux
        newNode.setPrevious(p); // Nova instrucao
        newNode.setNext(p.getNext());

        p.getNext().setPrevious(newNode); // Nova instrucao

        p.setNext(newNode);

        p = null;
        nElements++;
<<<<<<< HEAD
    }

    private void pushBack(int value)
    {
        GameObject cube = Instantiate(objetoBegin);
=======
        return true;
    }

    private bool pushBack(int value)
    {
        // Aloca memoria para novo no
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
>>>>>>> 863b05d8aa3aa7cbaffb38674dbc11bba0fc6bba
        //CRIAR LINHA
        Node newNode = new Node();
        newNode.setSquare(cube);
        newNode.content = value;
<<<<<<< HEAD
        cube.GetComponentInChildren<TextMesh>().text = "" + newNode.content;
=======
>>>>>>> 863b05d8aa3aa7cbaffb38674dbc11bba0fc6bba

        //COLOCANDO O CUBO E A LINHA NO LUGAR
        //CUBO 0,5 UNIDADES DE DISTANCIA DEPOIS DA LINHA
        newNode.getSquare().transform.position = new Vector3(-6.3f + (1.5f * size()), 0, 0);
        // Procura o final da lista 
        Node p = end;

        newNode.setNext(null);
<<<<<<< HEAD
        newNode.setPrevious(end);
        end.setNext(newNode);
        end = newNode;

        this.nElements++;
    }

    public void push(int pos, int value)
    {
        if ((empty()) && (pos != 1))
        {
            Debug.Log("Você não pode adicionar em uma posição não existente");
            return; /* lista vazia mas posicao inv*/
=======
        p.setNext(newNode);

        newNode.setPrevious(end);  // Nova instrucao
        end.setNext(newNode); // Nova instrucao
        end = newNode;       // Nova instrucao

        this.nElements++;
        return true;
    }

    public bool push(int pos, int value)
    {
        if ((empty()) && (pos != 1))
        {
            return false; /* lista vazia mas posicao inv*/
>>>>>>> 863b05d8aa3aa7cbaffb38674dbc11bba0fc6bba
        }

        /* inserção no início da lista (ou lista vazia)*/
        if (pos == 1)
        {
<<<<<<< HEAD
            pushFront(value);
=======
            return pushFront(value);
>>>>>>> 863b05d8aa3aa7cbaffb38674dbc11bba0fc6bba
        }
        /* inserção no fim da lista */
        else if (pos == nElements + 1)
        {
<<<<<<< HEAD
            pushBack(value);
=======
            return pushBack(value);
>>>>>>> 863b05d8aa3aa7cbaffb38674dbc11bba0fc6bba
        }
        /* inserção no meio da lista */
        else
        {
<<<<<<< HEAD
            pushMiddle(pos, value);
=======
            return pushMiddle(pos, value);
>>>>>>> 863b05d8aa3aa7cbaffb38674dbc11bba0fc6bba
        }
    }

    // Remove elemento do início de uma lista unitária
    private int removeFrontUnitList()
    {
        int value = begin.content;
        Destroy(begin.getSquare());
        begin = null;
        end = null;
        nElements--;
        return value;
    }

    /** Remove elemento do início da lista */
    private int removeFrontList()
    {
        Node p = begin;
        int value = p.content;
        // Retira o 1o elemento da lista (p)
        Destroy(begin.getSquare());
        //DESTROY DA LINHA 
        begin = p.getNext();
        p.getNext().setPrevious(null);  // Nova instrucao
        Node aux = begin;
        int number = 0;

        while (number < (size() - 1))
        {
            Vector3 position = aux.getSquare().transform.position;
            position.x = position.x - 1.5f; // 1 from the cube and 0,5 from the line
            //LEMBRAR DE MOVER LINHA (1,5 TB)
            aux.getSquare().transform.position = position;
            aux = aux.getNext();
            number++;
        }
        aux = null;

        nElements--;

        // Sugere ao garbage collector que libere a memoria
        //  da regiao apontada por p
        p = null;

        return value;
    }

    /** Remove elemento no meio da lista */
    private int removeMiddle(int pos)
    {
        Node p = begin;
        int n = 1;

        // Localiza o nó que será removido
        while ((n <= pos - 1) && (p != null))
        {
            p = p.getNext();
            n++;
        }

        if (p == null)
        {
            return -1; // pos. inválida
        }
        int value = p.content;
        Destroy(p.getSquare());

        //DESTROY LINHA DO SQUARE
        p.getPrevious().setNext(p.getNext());
        p.getNext().setPrevious(p.getPrevious());

        Node aux = p.getNext();
        int number = pos;

        while (number < size())
        {
            Vector3 position = aux.getSquare().transform.position;
            position.x = position.x - 1.5f; // 1 from the cube and 0,5 from the line
            //LEMBRAR DE MOVER LINHA (1,5 TB)
            aux.getSquare().transform.position = position;
            aux = aux.getNext();
            number++;
        }
        aux = null;
        nElements--;

        /* sugere ao garbage collector que libere a memoria
        *  da regiao apontada por p*/
        p = null;
        return value;
    }

    /** Remove elemento do final da lista */
    private int removeBack()
    {
        Node p = end;
        int value = p.content;
        Destroy(end.getSquare());
        //DESTROY LINHA
        end.getPrevious().setNext(null);
        end = end.getPrevious();
        nElements--;

        p = null;
        return value;

    }
<<<<<<< HEAD
    
=======

    /**Remove um elemento de uma determinada posição
	    Retorna o valor a ser removido. 
	    -1 se a posição for inválida ou a lista estiver vazia*/
>>>>>>> 863b05d8aa3aa7cbaffb38674dbc11bba0fc6bba
    public int remove(int pos)
    {
        // Lista vazia 
        if (empty())
        {
            return -1;
        }

        // Remoção do elemento da cabeça da lista 
        if ((pos == 1) && (size() == 1))
        {
            return removeFrontUnitList();
        }
        else if (pos == 1)
        {
            return removeFrontList();
        }
        // Remocao no fim da lista
        else if (pos == size())
        {
            return removeBack();
        }
        // Remoção em outro lugar da lista
        else
        {
            return removeMiddle(pos);
        }
    }
}
