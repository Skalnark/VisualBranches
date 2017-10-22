using UnityEngine;

public class LDE : MonoBehaviour
{
    public GameObject objetoBegin;
    private Node begin;
    private Node end;
    public int nElements;
    public Color foward;
    public Color backward;

    public LDE()
    {
        nElements = 0;
        foward = new Color(0, 1, 0);
        backward = new Color(1, 0, 0);

    }

    public bool empty()
    {
        if (nElements == 0)
            return true;
        else
            return false;
    }

    public int size()
    {
        return nElements;
    }

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
            newNode.setNext(begin);
            begin.setPrevious(newNode);
            
            //MOVENDO A LISTA
            int number = size();
            Node aux = end;

            while (number > 0)
            {
                //Movendo cubos -------------------------------------------
                Vector3 positionSquare = aux.getSquare().transform.position;
                positionSquare.x = positionSquare.x + 1.5f; // 1 from the cube and 0,5 from the line
                aux.getSquare().transform.position = positionSquare;

                //Movendo linha --------------------------------------------
                if (number > 1) {
                    Vector3 positionLine = aux.getPrevious().getLine().transform.position;
                    Vector3 positionEndLine = positionLine;
                    positionLine.x = positionLine.x + 1.5f;
                    positionEndLine.x += 2.0f;

                    LineRenderer lr = aux.getPrevious().getLine().GetComponent<LineRenderer>();
                    lr.SetPosition(0, positionLine);
                    lr.SetPosition(1, positionEndLine);
                    aux.getPrevious().getLine().transform.position = positionLine;
                }

                //Indo para proximo nó --------------------------------------
                aux = aux.getPrevious();
                number--;
            }
            aux = null;

            //COLOCANDO O CUBO E A LINHA NO LUGAR
            newNode.getSquare().transform.position = new Vector3(-6.3f, 0, 0);
            GameObject myLine = new GameObject();
            Vector3 startLine = new Vector3(-5.8f, 0.25f, 0);
            Vector3 endLine = new Vector3(-5.3f, 0.25f, 0);
            DrawLine(startLine, endLine, foward, myLine);
            newNode.setLine(myLine);

        }

        begin = newNode;
        nElements++;
    }
    /*
     * Vector3 startLine = new Vector3(-5.8f + 1.5f * (size() - 1), 0.25f, 0);
     * Vector3 endLine = new Vector3(-5.3f + 1.5f * (size() - 1), 0.25f, 0);
     */
    private void pushMiddle(int pos, int value)
    {
        if (pos > size())
        {
            Debug.Log("posição inválida");
            return;
        }

        GameObject cube = Instantiate(objetoBegin);
        //CRIAR LINHA
        Node newNode = new Node();
        newNode.setSquare(cube);
        newNode.content = value;
        cube.GetComponentInChildren<TextMesh>().text = "" + newNode.content;

        // Localiza a pos. onde será inserido o novo nó
        Node p = begin;
        int cont = 1;
        while (cont < (pos - 1))
        {
            p = p.getNext();
            cont++;
        }
        
        int number = size();
        Node aux = end;

        while (number >= pos)
        {
            Vector3 position = aux.getSquare().transform.position;
            position.x = position.x + 1.5f; // 1 from the cube and 0,5 from the line
            aux.getSquare().transform.position = position;

            if (number > pos)
            {
                Vector3 positionLine = aux.getPrevious().getLine().transform.position;
                Vector3 positionEndLine = positionLine;
                positionLine.x = positionLine.x + 1.5f;
                positionEndLine.x += 2.0f;

                LineRenderer lr = aux.getPrevious().getLine().GetComponent<LineRenderer>();
                lr.SetPosition(0, positionLine);
                lr.SetPosition(1, positionEndLine);
                aux.getPrevious().getLine().transform.position = positionLine;
            }
            aux = aux.getPrevious();
            number--;

        }
        aux = null;

        //COLOCANDO O CUBO E A LINHA NO LUGAR
        newNode.getSquare().transform.position = new Vector3(-6.3f + (1.5f * (pos - 1)), 0, 0);
        GameObject myLine = new GameObject();
        Vector3 startLine = new Vector3(-5.8f + 1.5f * (pos - 1), 0.25f, 0);
        Vector3 endLine = new Vector3(-5.3f + 1.5f * (pos - 1), 0.25f, 0);
        DrawLine(startLine, endLine, foward, myLine);
        newNode.setLine(myLine);

        // Insere novo elemento apos aux
        newNode.setPrevious(p);
        newNode.setNext(p.getNext());
        p.getNext().setPrevious(newNode);
        p.setNext(newNode);

        p = null;
        nElements++;
    }

    private void pushBack(int value)
    {
        GameObject cube = Instantiate(objetoBegin);
        //CRIAR LINHA
        Node newNode = new Node();
        newNode.setSquare(cube);
        newNode.content = value;
        cube.GetComponentInChildren<TextMesh>().text = "" + newNode.content;

        //COLOCANDO O CUBO E A LINHA NO LUGAR
        //CUBO 0,5 UNIDADES DE DISTANCIA DEPOIS DA LINHA
        newNode.getSquare().transform.position = new Vector3(-6.3f + (1.5f * size()), 0, 0);
        GameObject myLine = new GameObject();
        Vector3 startLine = new Vector3(-5.8f + 1.5f * (size() - 1), 0.25f, 0);
        Vector3 endLine = new Vector3(-5.3f + 1.5f * (size() - 1), 0.25f, 0);
        DrawLine(startLine, endLine, foward, myLine);
        end.setLine(myLine);

        // Procura o final da lista
        newNode.setPrevious(end);
        end.setNext(newNode);
        end = newNode;
        
        nElements++;
    }

    public void push(int pos, int value)
    {
        if ((empty()) && (pos != 1))
        {
            Debug.Log("Você não pode adicionar em uma posição não existente");
            return; /* lista vazia, mas posicao invalida*/
        }

        /* inserção no início da lista (ou lista vazia)*/
        if (pos == 1)
        {
            pushFront(value);
            return;
        }
        /* inserção no fim da lista */
        else if (pos == nElements + 1)
        {
            pushBack(value);
            return;
        }
        /* inserção no meio da lista */
        else
        {
            pushMiddle(pos, value);
            return;
            
        }
    }

    // Remove elemento do início de uma lista unitária
    private void removeFrontUnitList()
    {
        Node p = begin;
        begin = null;
        end = null;

        Destroy(p.getSquare());
        nElements--;
    }

    /** Remove elemento do início da lista */
    private void removeFrontList()
    {
        Node p = begin;
        // Retira o 1o elemento da lista (p)
        
        begin = p.getNext();
        begin.setPrevious(null);  // Nova instrucao

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

        Destroy(p.getSquare());
        //DESTROY DA LINHA 

        nElements--;
        p = null;
    }

    /** Remove elemento no meio da lista */
    private void removeMiddle(int pos)
    {
        if (pos > size())
        {
            Debug.Log("posição inválida");
            return;
        }

        // Localiza a pos. onde será inserido o novo nó
        Node p = begin;
        int cont = 1;

        while (cont <= (pos - 1))
        {
            p = p.getNext();
            cont++;
        }

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

        Destroy(p.getSquare());
        //DESTROY LINHA DO SQUARE

        nElements--;
        p = null;
    }

    /** Remove elemento do final da lista */
    private void removeBack()
    {
        Node p = end;
        end = p.getPrevious();
        end.setNext(null);

        Destroy(p.getSquare());
        //DESTROY LINHA

        nElements--;
        p = null;
    }
    
    public void remove(int pos)
    {
        // Lista vazia 
        if (empty())
        {
            Debug.Log("Você não pode remover nada de uma Lista vazia.");
            return;
        }

        // Remoção do elemento da cabeça da lista 
        if ((pos == 1) && (size() == 1))
        {
            removeFrontUnitList();
            return;
        }
        else if (pos == 1)
        {
            removeFrontList();
            return;
        }
        // Remocao no fim da lista
        else if (pos == size())
        {
            removeBack();
            return;
        }
        // Remoção em outro lugar da lista
        else
        {
            removeMiddle(pos);
            return;
        }
    }

    public void DrawLine(Vector3 start, Vector3 end, Color color, GameObject myLine)
    {
        myLine.transform.position = start;
        myLine.AddComponent<LineRenderer>();
        LineRenderer lr = myLine.GetComponent<LineRenderer>();
        lr.material = new Material(Shader.Find("Particles/Alpha Blended Premultiply"));
        lr.SetColors(color, color);
        lr.SetWidth(start: 0.1f, end: 0.1f);
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);
    }
}