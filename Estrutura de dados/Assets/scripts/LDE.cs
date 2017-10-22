using UnityEngine;

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
        newNode.setNext(null);
        newNode.setPrevious(null);

        if (nElements == 0)
        {
            //NÃO CRIAR LINHA
            end = newNode;
            //Debug.Log("o end no Front eh: " + end.content);
            newNode.getSquare().transform.position = new Vector3(-6.3f, 0, 0);
        }
        else
        {
            newNode.setNext(begin);
            // Debug.Log("o proximo do newNode eh : " + newNode.getNext().content);
            //Debug.Log("o anterior do newNode eh : " + newNode.getPrevious().content);
            begin.setPrevious(newNode); // Nova instrucao	
            //Debug.Log("o proximo do begin eh : " + begin.getNext().content);
            //Debug.Log("o anterior do begin eh : " + begin.getPrevious().content);

            //MOVENDO A LISTA
            int number = size();
            Node aux = end;

            while (number > 0)
            {
                Vector3 position = aux.getSquare().transform.position;
                position.x = position.x + 1.5f; // 1 from the cube and 0,5 from the line
                aux.getSquare().transform.position = position;
                //LEMBRAR DE MOVER LINHA (1,5 TB)
                Debug.Log("o aux eh o:" + aux.content);
                //Debug.Log("e o anterior do aux eh o:" + aux.getPrevious().content);
                aux = aux.getPrevious();
                //Debug.Log("o aux AGR eh o:" + aux.content);
                //Debug.Log("e o anterior do aux AGR eh o:" + aux.getPrevious().content);
                number--;
            }
            aux = null;

            //COLOCANDO O CUBO E A LINHA NO LUGAR
            newNode.getSquare().transform.position = new Vector3(-6.3f, 0, 0);
            //CRIAR LINHA - COM A CONDIÇÃO DE QUE TENHA MAIS DE UM OBJETO NA LISTA
        }

        begin = newNode;
        //Debug.Log("o begin eh no Front: " + begin.content);
        nElements++;
    }

    private void pushMiddle(int pos, int value)
    {
        GameObject cube = Instantiate(objetoBegin);
        //CRIAR LINHA
        Node newNode = new Node();
        newNode.setSquare(cube);
        newNode.content = value;
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
            //LEMBRAR DE MOVER LINHA (1,5 TB)
            aux = aux.getPrevious();
            number--;

        }
        aux = null;

        //COLOCANDO O CUBO E A LINHA NO LUGAR
        newNode.getSquare().transform.position = new Vector3(-6.3f + (1.5f * (pos - 1)), 0, 0);

        // Insere novo elemento apos aux
        newNode.setPrevious(p); // Nova instrucao
        //Debug.Log("o anterior do newNode no Middle eh: " + newNode.getPrevious().content);
        newNode.setNext(p.getNext());
        //Debug.Log("o proximo do newNode no Middle eh: " + newNode.getNext().content);

        p.getNext().setPrevious(newNode); // Nova instrucao
        //Debug.Log("o anterior do proximo do newNode no Middle eh: " + p.getNext().getPrevious().content);

        p.setNext(newNode);
        //Debug.Log("o anterior do newNode no Middle aponta para o: " + p.getNext().content);

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
        
        // Procura o final da lista 
        newNode.setNext(null);
        newNode.setPrevious(end);
        //Debug.Log("o anterior do newNode no Back eh: " + newNode.getPrevious().content);
        end.setNext(newNode);
       // Debug.Log("o proximo do anterior do newNode no Back eh: " + end.getNext().content);
        end = newNode;
        //Debug.Log("o end no Back eh: " + end.content);


        this.nElements++;
    }

    public void push(int pos, int value)
    {
        if ((empty()) && (pos != 1))
        {
            Debug.Log("Você não pode adicionar em uma posição não existente");
            return; /* lista vazia mas posicao inv*/
        }

        /* inserção no início da lista (ou lista vazia)*/
        if (pos == 1)
        {
            pushFront(value);
        }
        /* inserção no fim da lista */
        else if (pos == nElements + 1)
        {
            pushBack(value);
        }
        /* inserção no meio da lista */
        else
        {
            pushMiddle(pos, value);
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
