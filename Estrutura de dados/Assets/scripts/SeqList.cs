using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeqList : MonoBehaviour
{
    // ------------------ VARIAVEIS ---------------------
    public GameObject objetoBegin;
    private int nElements;
    public Material shinyTexture;
    public Material normalTexture;
    private Node[] data;
    public int maxSize;

    //Abrir a tela do PopUp
    private bool showPopUp = false;
    //Colocar o label de lista vazia
    private bool emptyPopUp = false;
    //Colocar o label de posição invalida
    private bool wrongPositionPopUp = false;
    //Colocar o label de elemento invalido
    private bool wrongElementPopUp = false;

    public SeqList()
    {
        nElements = 0;
    }

    public void insertSize(int size)
    {
        maxSize = size;
        data = new Node[maxSize];
        for (int i = 0; i < maxSize; i++)
        {
            GameObject cube = Instantiate(objetoBegin);
            Node newNode = new Node();
            newNode.setSquare(cube);
            newNode.getSquare().transform.position = new Vector3(-6.3f + (float)i, 0, 0);
            data[i] = newNode;
        }
    }

    public bool empty()
    {
        if (nElements == 0)
            return true;
        else
            return false;
    }

    public bool full()
    {
        if (nElements == maxSize)
            return true;
        else
            return false;
    }

    public int size()
    {
        return nElements;
    }

    //Função para localizar o cubo pela posição
    public void SeqElement(int pos)
    {
        if ((pos > nElements) || (pos <= 0))
        {
            showPopUp = true;
            wrongPositionPopUp = true;
            return;
        }
        else if (empty())
        {
            showPopUp = true;
            emptyPopUp = true;
            return;
        }
        else
        {
            //Função para fazer o cubo mudar de cor por 5 segundos
            StartCoroutine(Wait(data[pos-1].getSquare()));
            return;
        }
    }

    //Função para localizar o cubo pelo valor
    public void SeqPosition(int value)
    {
        if (empty())
        {
            showPopUp = true;
            emptyPopUp = true;
            return;
        }
        else
        {
            for (int i = 0; i < nElements; i++)
            {
                if (data[i].content == value)
                {
                    StartCoroutine(Wait(data[i].getSquare()));
                    return;
                }
            }

            showPopUp = true;
            wrongElementPopUp = true;
            return;
        }
    }

    public void insert(int pos, int value)
    {
        if (full() || pos > nElements+1 ||(pos <= 0))
        {
            showPopUp = true;
            wrongPositionPopUp = true;
            return;
        }

        //move os valores para o lado
        for (int i = nElements; i >= pos; i--)
        {
            data[i].getSquare().GetComponentInChildren<TextMesh>().text = "" + data[i - 1].content;
            data[i].content = data[i - 1].content;
        }

        /* Insere o dado na posicao correta */
        data[pos - 1].getSquare().GetComponentInChildren<TextMesh>().text = "" + value;
        data[pos - 1].content = value;

        /* Incrementa o numero de elementos na lista */
        nElements++;
        return;
    }

    public void remove(int pos)
    {
        /* Verifica se a posicao eh valida */
        if ((pos > nElements) || (pos < 1))
        {
            showPopUp = true;
            wrongPositionPopUp = true;
            return;
        }
        if (empty())
        {
            showPopUp = true;
            emptyPopUp = true;
            return;
        }
        if(pos == nElements)
        {
            data[pos - 1].getSquare().GetComponentInChildren<TextMesh>().text = "";
            data[pos - 1].content = 0;
        }
        else
        {
            //move os valores para o lado
            for (int i = pos - 1; i < nElements - 1; i++)
            {
                data[i].getSquare().GetComponentInChildren<TextMesh>().text = "" + data[i + 1].content;
                data[i].content = data[i + 1].content;
            }

            data[nElements-1].getSquare().GetComponentInChildren<TextMesh>().text = "";
            data[nElements-1].content = 0;
        }

        /* Decrementa o numero de elementos na lista */
        nElements--;
        return;
    }

    //-------------------- EXTRA METHODS ----------------------
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
