using UnityEngine;
using System.Collections;

public class LDE : MonoBehaviour
{
    public GameObject objetoBegin;
    private Node begin;
    private Node end;
    public int nElements;
    private Color foward;
    private Color backward;
    public Material shinyTexture;
    public Material normalTexture;

    //Abrir a tela do PopUp
    private bool showPopUp = false;
    //Colocar o label de lista vazia
    private bool emptyPopUp = false;
    //Colocar o label de posição invalida
    private bool wrongPositionPopUp = false;
    //Colocar o label de elemento invalido
    private bool wrongElementPopUp = false;

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

    public void element(int pos)
    {
        if (empty())
        {
            showPopUp = true;
            emptyPopUp = true;
            return; // Consulta falhou 
        }

        if ((pos < 1) || (pos > size()))
        {
            showPopUp = true;
            wrongPositionPopUp = true;
            return; // Posição inválida 
        }

        Node aux = begin;
        int cont = 1;

        // Percorre a lista do 1o elemento até pos 
        while (cont < pos)
        {
            // modifica "aux" para apontar para o proximo elemento da lista 
            aux = aux.getNext();
            cont++;
        }

        //Função para fazer o cubo mudar de cor por 5 segundos
        StartCoroutine(Wait(aux.getSquare()));

        return;
    }

    public void whereIsAt(int content)
    {
        if (empty())
        {
            showPopUp = true;
            emptyPopUp = true;
            return;//lista vazia
        }

        int cont = 1;
        Node aux;

        /* Percorre a lista do inicio ao fim até encontrar o elemento*/
        aux = begin;
        while (cont <= size())
        {
            /* Se encontrar o elemento, retorna sua posicao n;*/
            if (aux.content == content)
            {
                //Função para fazer o cubo mudar de cor por 5 segundos
                StartCoroutine(Wait(aux.getSquare()));
                return;
            }

            /* modifica "aux" para apontar para o proximo elemento da lista */
            aux = aux.getNext();
            cont++;
        }

        if(cont == size() + 1)
        {
            showPopUp = true;
            wrongElementPopUp = true;
            return;
        }
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
                    //LINHA FOWARD (VERDE)-------------------------------------------------------------------
                    Vector3 positionBeginFowardLine = aux.getPrevious().getFowardLine().transform.position;
                    Vector3 positionEndFowardLine = positionBeginFowardLine;
                    positionBeginFowardLine.x = positionBeginFowardLine.x + 1.5f;
                    positionEndFowardLine.x += 2.0f;

                    LineRenderer fowardLR = aux.getPrevious().getFowardLine().GetComponent<LineRenderer>();
                    fowardLR.SetPosition(0, positionBeginFowardLine);
                    fowardLR.SetPosition(1, positionEndFowardLine);
                    aux.getPrevious().getFowardLine().transform.position = positionBeginFowardLine;

                    //LINHA BACKWARD (VERMELHA)-------------------------------------------------------------------
                    Vector3 positionBeginBackwardLine = aux.getPrevious().getBackwardLine().transform.position;
                    Vector3 positionEndBackwardLine = positionBeginBackwardLine;
                    positionBeginBackwardLine.x = positionBeginBackwardLine.x + 1.5f;
                    positionEndBackwardLine.x += 2.0f;

                    LineRenderer backwardLR = aux.getPrevious().getBackwardLine().GetComponent<LineRenderer>();
                    backwardLR.SetPosition(0, positionBeginBackwardLine);
                    backwardLR.SetPosition(1, positionEndBackwardLine);
                    aux.getPrevious().getBackwardLine().transform.position = positionBeginBackwardLine;
                }

                //Indo para proximo nó --------------------------------------
                aux = aux.getPrevious();
                number--;
            }
            aux = null;

            //COLOCANDO O CUBO E A LINHA NO LUGAR
            newNode.getSquare().transform.position = new Vector3(-6.3f, 0, 0);

            //Criando Foward Line
            GameObject myFowardLine = new GameObject();
            Vector3 startFLine = new Vector3(-5.8f, 0.25f, 0);
            Vector3 endFLine = new Vector3(-5.3f, 0.25f, 0);
            DrawLine(startFLine, endFLine, foward, myFowardLine);
            newNode.setFowardLine(myFowardLine);

            //Criando Backward Line
            GameObject myBackwardLine = new GameObject();
            Vector3 startBLine = new Vector3(-5.8f, -0.25f, 0);
            Vector3 endBLine = new Vector3(-5.3f, -0.25f, 0);
            DrawLine(startBLine, endBLine, backward, myBackwardLine);
            newNode.setBackwardLine(myBackwardLine); 

        }

        begin = newNode;
        nElements++;
    }

    /** Insere nó no meio da lista*/
    private void pushMiddle(int pos, int value)
    {
        if (pos > size())
        {
            showPopUp = true;
            wrongPositionPopUp = true;
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
                //LINHA FOWARD (VERDE)-------------------------------------------------------------------
                Vector3 positionBeginFowardLine = aux.getPrevious().getFowardLine().transform.position;
                Vector3 positionEndFowardLine = positionBeginFowardLine;
                positionBeginFowardLine.x = positionBeginFowardLine.x + 1.5f;
                positionEndFowardLine.x += 2.0f;

                LineRenderer fowardLR = aux.getPrevious().getFowardLine().GetComponent<LineRenderer>();
                fowardLR.SetPosition(0, positionBeginFowardLine);
                fowardLR.SetPosition(1, positionEndFowardLine);
                aux.getPrevious().getFowardLine().transform.position = positionBeginFowardLine;

                //LINHA BACKWARD (VERMELHA)-------------------------------------------------------------------
                Vector3 positionBeginBackwardLine = aux.getPrevious().getBackwardLine().transform.position;
                Vector3 positionEndBackwardLine = positionBeginBackwardLine;
                positionBeginBackwardLine.x = positionBeginBackwardLine.x + 1.5f;
                positionEndBackwardLine.x += 2.0f;

                LineRenderer backwardLR = aux.getPrevious().getBackwardLine().GetComponent<LineRenderer>();
                backwardLR.SetPosition(0, positionBeginBackwardLine);
                backwardLR.SetPosition(1, positionEndBackwardLine);
                aux.getPrevious().getBackwardLine().transform.position = positionBeginBackwardLine;
            }
            aux = aux.getPrevious();
            number--;

        }
        aux = null;

        //COLOCANDO O CUBO E A LINHA NO LUGAR
        newNode.getSquare().transform.position = new Vector3(-6.3f + (1.5f * (pos - 1)), 0, 0);

        //Criando Foward Line
        GameObject myFowardLine = new GameObject();
        Vector3 startFLine = new Vector3(-5.8f + 1.5f * (pos - 1), 0.25f, 0);
        Vector3 endFLine = new Vector3(-5.3f + 1.5f * (pos - 1), 0.25f, 0);
        DrawLine(startFLine, endFLine, foward, myFowardLine);
        newNode.setFowardLine(myFowardLine);

        //Criando Backward Line
        GameObject myBackwardLine = new GameObject();
        Vector3 startBLine = new Vector3(-5.8f + 1.5f * (pos - 1), -0.25f, 0);
        Vector3 endBLine = new Vector3(-5.3f + 1.5f * (pos - 1), -0.25f, 0);
        DrawLine(startBLine, endBLine, backward, myBackwardLine);
        newNode.setBackwardLine(myBackwardLine);

        // Insere novo elemento apos aux
        newNode.setPrevious(p);
        newNode.setNext(p.getNext());
        p.getNext().setPrevious(newNode);
        p.setNext(newNode);

        p = null;
        nElements++;
    }

    /** Insere nó no fim da lista*/
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

        //Criando Foward Line
        GameObject myFowardLine = new GameObject();
        Vector3 startFLine = new Vector3(-5.8f + 1.5f * (size() - 1), 0.25f, 0);
        Vector3 endFLine = new Vector3(-5.3f + 1.5f * (size() - 1), 0.25f, 0);
        DrawLine(startFLine, endFLine, foward, myFowardLine);
        end.setFowardLine(myFowardLine);

        //Criando Backward Line
        GameObject myBackwardLine = new GameObject();
        Vector3 startBLine = new Vector3(-5.8f + 1.5f * (size() - 1), -0.25f, 0);
        Vector3 endBLine = new Vector3(-5.3f + 1.5f * (size() - 1), -0.25f, 0);
        DrawLine(startBLine, endBLine, backward, myBackwardLine);
        end.setBackwardLine(myBackwardLine);

        // Procura o final da lista
        newNode.setPrevious(end);
        end.setNext(newNode);
        end = newNode;
        
        nElements++;
    }

    public void push(int pos, int value)
    {
        if ((nElements == 0) && (pos != 1))
        {
            showPopUp = true;
            wrongPositionPopUp = true;
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
        
        begin = p.getNext();
        begin.setPrevious(null);  // Nova instrucao

        Node aux = begin;
        int number = 0;

        while (number < (size() - 1))
        {
            //Movendo cubos -------------------------------------------
            Vector3 positionSquare = aux.getSquare().transform.position;
            positionSquare.x = positionSquare.x - 1.5f; // 1 from the cube and 0,5 from the line
            aux.getSquare().transform.position = positionSquare;

            //Movendo linha --------------------------------------------
            if (number < (size() - 2))
            {
                //LINHA FOWARD (VERDE)-------------------------------------------------------------------
                Vector3 positionBeginFowardLine = aux.getFowardLine().transform.position;
                Vector3 positionEndFowardLine = positionBeginFowardLine;
                positionBeginFowardLine.x = positionBeginFowardLine.x - 1.5f;
                positionEndFowardLine.x -= 1.0f;

                LineRenderer fowardLR = aux.getFowardLine().GetComponent<LineRenderer>();
                fowardLR.SetPosition(0, positionBeginFowardLine);
                fowardLR.SetPosition(1, positionEndFowardLine);
                aux.getFowardLine().transform.position = positionBeginFowardLine;

                //LINHA BACKWARD (VERMELHA)-------------------------------------------------------------------
                Vector3 positionBeginBackwardLine = aux.getBackwardLine().transform.position;
                Vector3 positionEndBackwardLine = positionBeginBackwardLine;
                positionBeginBackwardLine.x = positionBeginBackwardLine.x - 1.5f;
                positionEndBackwardLine.x -= 1.0f;

                LineRenderer backwardLR = aux.getBackwardLine().GetComponent<LineRenderer>();
                backwardLR.SetPosition(0, positionBeginBackwardLine);
                backwardLR.SetPosition(1, positionEndBackwardLine);
                aux.getBackwardLine().transform.position = positionBeginBackwardLine;
            }

            aux = aux.getNext();
            number++;
        }
        aux = null;

        Destroy(p.getSquare());
        Destroy(p.getFowardLine());
        Destroy(p.getBackwardLine());

        nElements--;
        p = null;
    }

    /** Remove elemento no meio da lista */
    private void removeMiddle(int pos)
    {
        if (pos > size())
        {
            showPopUp = true;
            wrongPositionPopUp = true;
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
            //Movendo cubos -------------------------------------------
            Vector3 positionSquare = aux.getSquare().transform.position;
            positionSquare.x = positionSquare.x - 1.5f; // 1.0 from the cube and 0.5 from the line
            aux.getSquare().transform.position = positionSquare;

            //Movendo linha --------------------------------------------
            if (number < (size() - 1))
            {
                //LINHA FOWARD (VERDE)-------------------------------------------------------------------
                Vector3 positionBeginFowardLine = aux.getFowardLine().transform.position;
                Vector3 positionEndFowardLine = positionBeginFowardLine;
                positionBeginFowardLine.x = positionBeginFowardLine.x - 1.5f;
                positionEndFowardLine.x -= 1.0f;

                LineRenderer fowardLR = aux.getFowardLine().GetComponent<LineRenderer>();
                fowardLR.SetPosition(0, positionBeginFowardLine);
                fowardLR.SetPosition(1, positionEndFowardLine);
                aux.getFowardLine().transform.position = positionBeginFowardLine;

                //LINHA BACKWARD (VERMELHA)-------------------------------------------------------------------
                Vector3 positionBeginBackwardLine = aux.getBackwardLine().transform.position;
                Vector3 positionEndBackwardLine = positionBeginBackwardLine;
                positionBeginBackwardLine.x = positionBeginBackwardLine.x - 1.5f;
                positionEndBackwardLine.x -= 1.0f;

                LineRenderer backwardLR = aux.getBackwardLine().GetComponent<LineRenderer>();
                backwardLR.SetPosition(0, positionBeginBackwardLine);
                backwardLR.SetPosition(1, positionEndBackwardLine);
                aux.getBackwardLine().transform.position = positionBeginBackwardLine;
            }
            aux = aux.getNext();
            number++;
        }
        aux = null;

        Destroy(p.getSquare());
        Destroy(p.getFowardLine());
        Destroy(p.getBackwardLine());

        nElements--;
        p = null;
    }

    /** Remove elemento do final da lista */
    private void removeBack()
    {
        Node p = end;
        Node aux = end.getPrevious();
        end = p.getPrevious();
        end.setNext(null);

        Destroy(p.getSquare());
        Destroy(aux.getFowardLine());
        Destroy(aux.getBackwardLine());

        nElements--;
        p = null;
    }
    
    public void remove(int pos)
    {
        // Lista vazia 
        if (empty())
        {
            showPopUp = true;
            emptyPopUp = true;
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
        lr.startColor = color;
        lr.endColor = color;
        lr.startWidth = 0.1f;
        lr.endWidth = 0.1f;
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);
    }

    public IEnumerator Wait(GameObject square)
    {
        // FAZER O DEMONIO DO CUBO BRILHAR
        MeshRenderer renderer = square.GetComponent<MeshRenderer>();
        Material newMaterial = shinyTexture;
        renderer.material = newMaterial;

        yield return new WaitForSecondsRealtime(5);

        //FAZER O DEMONIO DO CUBO VOLTAR AO NORMAL
        Material newMaterial2 = normalTexture;
        renderer.material = newMaterial2;
    }

    public void OnGUI()
    {
        if (showPopUp)
        {
            if (emptyPopUp)
            {
                GUI.Window(0, new Rect((Screen.width / 2) - 150, (Screen.height / 2) - 75
                            , 300, 250), ShowEmptyGUI, "ERROR MESSAGE");
            }

            if (wrongPositionPopUp)
            {
                GUI.Window(0, new Rect((Screen.width / 2) - 150, (Screen.height / 2) - 75
                            , 300, 250), ShowPositionGUI, "ERROR MESSAGE");
            }

            if (wrongElementPopUp)
            {
                GUI.Window(0, new Rect((Screen.width / 2) - 150, (Screen.height / 2) - 75
                            , 300, 250), ShowElementGUI, "ERROR MESSAGE");
            }
            StartCoroutine(Wait());
        }
    }

    public void ShowEmptyGUI(int windowID)
    {
        GUIStyle myStyle2 = new GUIStyle();
        myStyle2.fontSize = 30;

        myStyle2.normal.textColor = Color.white;
        myStyle2.hover.textColor = Color.white;
        GUI.Label(new Rect(70, 90, 200, 100), "    Error! " + "\n" +
                                            "  Lista vazia", myStyle2);
    }

    public void ShowPositionGUI(int windowID)
    {
        GUIStyle myStyle2 = new GUIStyle();
        myStyle2.fontSize = 22;

        myStyle2.normal.textColor = Color.white;
        myStyle2.hover.textColor = Color.white;
        GUI.Label(new Rect(70, 90, 200, 100), "        Error! " + "\n" +
           "Posição inválida", myStyle2);
    }

    public void ShowElementGUI(int windowID)
    {
        GUIStyle myStyle2 = new GUIStyle();
        myStyle2.fontSize = 20;

        myStyle2.normal.textColor = Color.white;
        myStyle2.hover.textColor = Color.white;
        GUI.Label(new Rect(70, 90, 200, 100), "         Error! " + "\n" +
           "Valor não detectado", myStyle2);
    }

    public IEnumerator Wait()
    {
        yield return new WaitForSecondsRealtime(1);
        wrongPositionPopUp = false;
        wrongElementPopUp = false;
        emptyPopUp = false;
        showPopUp = false;
    }
}