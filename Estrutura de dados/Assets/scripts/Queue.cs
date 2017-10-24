using UnityEngine;
using System.Collections;

public class Queue : MonoBehaviour
{
    public GameObject objetoBegin;
    private Node begin;
    private Node end;
    public int nElements;
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
    public GameObject camera;
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword
    public bool showPopUp = false;

    public Queue()
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

    public void push(int value)
    {
        GameObject cube = Instantiate(objetoBegin);
        Node newNode = new Node();
        newNode.setSquare(cube);
        newNode.content = value;
        cube.GetComponentInChildren<TextMesh>().text = "" + newNode.content;

        if (empty())
        {
            begin = newNode;
            end = newNode;
            newNode.getSquare().transform.position = new Vector3(-6, 0, 0);
        }
        else
        {
            newNode.getSquare().transform.position = new Vector3(-6, 2, 0);
            end.setNext(newNode);
            end = newNode;
            float target = -6 + size();

            StartCoroutine(MoveObjectWhenPush(newNode.getSquare().transform, target));
            if (size() > 12)
            {
                StartCoroutine(MoveCameraWhenPush(camera.transform, camera.transform.position.x + 1));
            }
        }

        nElements++;
    }

    public void pull()
    {

        if (empty())
        {
            showPopUp = true;
            return;
        }
        GameObject objeto = begin.getSquare();

        Node p = begin;

        if (nElements == 1)
        {
            objeto.AddComponent<Rigidbody>();
            StartCoroutine(WaitNDestroy(objeto, 2));
            end = null;
            begin = null;
        }
        else
        {
            begin = begin.getNext();

            Node aux = begin;
            int number = 0;

            objeto.AddComponent<Rigidbody>();

            while (number < (nElements - 1))
            {
                Vector3 position = aux.getSquare().transform.position;
                position.x--;
                aux.getSquare().transform.position = position;
                aux = aux.getNext();
                number++;
            }
        }

        if (nElements > 1)
            StartCoroutine(WaitNDestroy(p.getSquare(), 3));

        p = null;
        nElements--;
        if (size() > 12 && camera.transform.position.x > 0)
            camera.transform.position += new Vector3(-1, 0, 0);
    }

    //função que não tem nada a ver com a fila
    public IEnumerator MoveObjectWhenPush(Transform block, float target)
    {
        while (block.position.x != target)
        {
            if (block.position.x < target)
            {
                yield return new WaitForSecondsRealtime(0.0001f);
                block.position += new Vector3(Time.deltaTime * size() * 2, 0, 0);
            }
            else
            {
                block.position = new Vector3(target, 1, 0);
            }
        }
        block.position += new Vector3(0, -1, 0);

    }

    public IEnumerator WaitNDestroy(GameObject objeto, float time)
    {
        yield return new WaitForSecondsRealtime(time);
        Destroy(objeto);
    }

    public IEnumerator MoveCameraWhenPush(Transform camera, float target)
    {
        while (camera.position.x != target)
        {
            if (camera.position.x < target)
            {
                yield return new WaitForSeconds(0);
                camera.position += new Vector3(Time.deltaTime * size(), 0, 0);
            }
            else
            {
                camera.position = new Vector3(target, 1, -2);
            }
        }
    }

    public void OnGUI()
    {
        if (showPopUp)
        {
            GUI.Window(0, new Rect((Screen.width / 2) - 150, (Screen.height / 2) - 75
                , 300, 250), ShowGUI, "ERROR MESSAGE");
            StartCoroutine(Wait());
        }
    }

    public void ShowGUI(int windowID)
    {
        GUIStyle myStyle2 = new GUIStyle();
        myStyle2.fontSize = 30;

        myStyle2.normal.textColor = Color.white;
        myStyle2.hover.textColor = Color.white;

        GUI.Label(new Rect(70, 90, 200, 100), "     Error! " + "\n" +
                                            "  Fila vazia", myStyle2);
    }

    public IEnumerator Wait()
    {
        yield return new WaitForSecondsRealtime(1);
        showPopUp = false;
    }
}