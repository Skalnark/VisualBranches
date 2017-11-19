using System.Collections;
using UnityEngine;
using System;

public class BinaryTree : MonoBehaviour{

    public GameObject objetoBegin;
    private Node root;
    private Color foward;
    public Material normalMaterial;
    private int depth;
    private float distance;
    public Material redMaterial;
    public Material greenMaterial;

    //Abrir a tela do PopUp
    private bool showPopUp = false;
    //Colocar o label de lista vazia
    private bool emptyPopUp = false;
    //Colocar o label de elemento invalido
    private bool wrongElementPopUp = false;
    

    public BinaryTree()
    {
        depth = 0;
    }

    public bool empty()
    {
        if (ReferenceEquals(null, root))
        {
            return true;
        }
        else
        {
            return false;
        }
            
    }

    public void insert (int value)
    {
        GameObject leaf= Instantiate(objetoBegin);
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

        Node aux = new Node();
        aux = root;
        Node p = new Node();
        depth = 0;
        distance  = 3f;

        while (!(ReferenceEquals(null, aux)))
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
            position.y -= 2f;

            if (depth == 1)
                position.x -= 3.5f;
            else
                position.x -= (float)(Math.Pow(distance,2) / Math.Pow(depth , 3)); // Calculo da distancia entre os nós da esquerda
            
            newNode.getSquare().transform.position = position;
            newNode.getSquare().transform.localScale = AdjustScale(newNode.getSquare(), depth);
            
            DrawLine(
                p.getSquare().transform.position, 
                newNode.getSquare().transform.position, 
                new GameObject(),
                new Color(255, 0, 0),
                new Color(255, 255, 0));

        }
        else
        {
            p.setNext(newNode); //Coloca o nó na direita do pai
            Vector3 position = p.getSquare().transform.position;
            position.y -= 2f;

            if (depth == 1)
                position.x += 3.5f;
            else
                position.x += 0.2f+ (float)(Math.Pow(distance, 2) / Math.Pow(depth, 3)); // Calculo da distancia entre os nós da direita
            
            newNode.getSquare().transform.position = position;
            newNode.getSquare().transform.localScale = AdjustScale(newNode.getSquare(), depth);
            
            DrawLine(
                p.getSquare().transform.position,
                newNode.getSquare().transform.position,
                new GameObject(),
                new Color(0, 0, 255),
                new Color(0, 255, 255));
        }
        return;
    }

    public Node search(Node T, int value)
    {
        Node aux;
        StartCoroutine(TrazOObjetoQuePiscaVermelho(T.getSquare()));
        //stop conditions
        if (ReferenceEquals(null, T))
        {
            return null;
        }

        if (T.content == value)
        {
            return T;
        }

        //Recursive case
        if (value < T.content)
        {
            aux = search(T.getPrevious(), value);//Esquerda
        }
        else
        {
            aux = search(T.getNext(), value); //Direita
        }

        return aux;
    }

    public void searchRoot(int value)
    {
        if (empty())
        {
            showPopUp = true;
            emptyPopUp = true;
            return;
        }

        Node searchNode = new Node();
        searchNode = search(root, value);

        if(ReferenceEquals(null, searchNode))
        {
            showPopUp = true;
            wrongElementPopUp = true;
            return;
        }

        //Função para mostrar q achou o nó
        StartCoroutine(TrazOObjetoQuePiscaVerde(searchNode.getSquare()));
    }

    //Função para brilhar nó em nó até o chegar no certo
    public IEnumerator TrazOObjetoQuePiscaVermelho(GameObject square)
    {
        // FAZER O DEMONIO DO CUBO BRILHAR
        MeshRenderer renderer = square.GetComponent<MeshRenderer>();
        renderer.material = redMaterial;


        yield return new WaitForSecondsRealtime(2);

        // FAZER O DEMONIO DO CUBO 
        renderer.material = normalMaterial;
    }
    public IEnumerator TrazOObjetoQuePiscaVerde(GameObject square)
    {
        // FAZER O DEMONIO DO CUBO BRILHAR
        MeshRenderer renderer = square.GetComponent<MeshRenderer>();
        renderer.material = greenMaterial;


        yield return new WaitForSecondsRealtime(5);

        // FAZER O DEMONIO DO CUBO 
        renderer.material = normalMaterial;
    }

    //Função para os PopUp
    public void OnGUI()
    {
        if (showPopUp)
        {
            if (emptyPopUp)
            {
                GUI.Window(0, new Rect((Screen.width / 2) - 150, (Screen.height / 2) - 75
                            , 300, 250), ShowEmptyGUI, "ERROR MESSAGE");
            }

            if (wrongElementPopUp)
            {
                GUI.Window(0, new Rect((Screen.width / 2) - 150, (Screen.height / 2) - 75
                            , 300, 250), ShowElementGUI, "ERROR MESSAGE");
            }
            StartCoroutine(PopUp());
        }
    }

    //Função para árvore vazia no PopUp
    public void ShowEmptyGUI(int windowID)
    {
        GUIStyle myStyle2 = new GUIStyle();
        myStyle2.fontSize = 30;

        myStyle2.normal.textColor = Color.white;
        myStyle2.hover.textColor = Color.white;
        GUI.Label(new Rect(70, 90, 200, 100), "    Error! " + "\n" +
                                            " Árvore vazia", myStyle2);
    }

    //Função para elemento inválido no PopUp
    public void ShowElementGUI(int windowID)
    {
        GUIStyle myStyle2 = new GUIStyle();
        myStyle2.fontSize = 20;

        myStyle2.normal.textColor = Color.white;
        myStyle2.hover.textColor = Color.white;
        GUI.Label(new Rect(70, 90, 200, 100), "         Error! " + "\n" +
           "Valor não encontrado", myStyle2);
    }

    //Função para os PopUp
    public IEnumerator PopUp()
    {
        yield return new WaitForSecondsRealtime(1);
        wrongElementPopUp = false;
        emptyPopUp = false;
        showPopUp = false;
    }

    private Vector3 AdjustScale(GameObject gameObject, float depth)
    {
        float x = gameObject.transform.lossyScale.x;
        float y = gameObject.transform.lossyScale.y;
        float z = gameObject.transform.lossyScale.z;
        depth = (1.61803398875f * 1.61803398875f * 1.61803398875f) * depth / 5;
        return new Vector3(x - (depth / 10), y - (depth / 10), z - (depth / 10));

    }

    public void DrawLine(Vector3 start, Vector3 end, GameObject myLine, Color startColor, Color endColor)
    {
        myLine.transform.position = start;
        myLine.AddComponent<LineRenderer>();
        LineRenderer lr = myLine.GetComponent<LineRenderer>();
        lr.material = new Material(Shader.Find("Particles/Alpha Blended Premultiply"));
        lr.startColor = startColor;
        lr.endColor = endColor;
        lr.startWidth = 0.1f;
        lr.endWidth = 0.1f;
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);
    }
}