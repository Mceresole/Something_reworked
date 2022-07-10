using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CollectCanvas2 : MonoBehaviour
{
    private List<string> action = new List<string>();
    private const float SNAKE_SPEED = 0.4f;
    private bool isAvaible = true;

    //public Canvas canvas;
    public Button up;
    public Button down;
    public Button left;
    public Button right;
    public GameObject mur1;
    public GameObject mur2;
    public GameObject mur3;
    public GameObject mur4;
    public GameObject murInt1;
    public GameObject murInt2;
    public Text nb_pommes;
    public GameObject pomme;
    public GameObject snake;
    public GameObject body;
    public GameObject button_start;

    public int maxPommes = 7;
    
    public int nbPommes;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    public float int1minX;
    public float int1maxX;
    public float int1minY;
    public float int1maxY;

    public float int2minX;
    public float int2maxX;
    public float int2minY;
    public float int2maxY;

    private bool start;
    private bool flag = true;
    
    void Start()
    {
        if (flag)
        {
            float width = this.GetComponent<RectTransform>().sizeDelta.x;
            float height = this.GetComponent<RectTransform>().sizeDelta.y;
            up.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width / (float)16.89);
            up.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height / (float)8.91);
            up.transform.localPosition = new Vector3(width / (float)5.03 - width / 2, -height / (float)2.84 + height / 2, 0);

            down.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width / (float)16.89);
            down.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height / (float)8.91);
            down.transform.localPosition = new Vector3(width / (float)5.03 - width / 2, -height / (float)2.01 + height / 2, 0);

            left.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width / (float)16.89);
            left.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height / (float)8.91);
            left.transform.localPosition = new Vector3(width / (float)7.63 - width / 2, -height / (float)2.31 + height / 2, 0);

            right.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width / (float)16.89);
            right.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height / (float)8.91);
            right.transform.localPosition = new Vector3(width / (float)3.75 - width / 2, -height / (float)2.31 + height / 2, 0);

            mur1.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width / (float)3.38);
            mur1.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height / (float)31.2);
            mur1.transform.localPosition = new Vector3(width / (float)1.57 - width / 2, -height / (float)6.30 + height / 2, 0);
            mur1.transform.GetComponent<BoxCollider>().size = new Vector3(mur1.transform.GetComponent<RectTransform>().sizeDelta.x, mur1.transform.GetComponent<RectTransform>().sizeDelta.y, 1);
            minY = mur1.transform.localPosition.y - mur1.transform.GetComponent<RectTransform>().sizeDelta.y / 2.0f;

            mur2.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width / (float)59.1);
            mur2.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height / (float)1.95);
            mur2.transform.localPosition = new Vector3(width / (float)2.00 - width / 2, -height / (float)2.51 + height / 2, 0);
            mur2.transform.GetComponent<BoxCollider>().size = new Vector3(mur2.transform.GetComponent<RectTransform>().sizeDelta.x, mur2.transform.GetComponent<RectTransform>().sizeDelta.y, 1);
            minX = mur2.transform.localPosition.x + mur2.transform.GetComponent<RectTransform>().sizeDelta.x / 2.0f;

            mur3.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width / (float)3.38);
            mur3.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height / (float)31.2);
            mur3.transform.localPosition = new Vector3(width / (float)1.57 - width / 2, -height / (float)1.56 + height / 2, 0);
            mur3.transform.GetComponent<BoxCollider>().size = new Vector3(mur3.transform.GetComponent<RectTransform>().sizeDelta.x, mur3.transform.GetComponent<RectTransform>().sizeDelta.y, 1);
            minY = mur3.transform.localPosition.y + mur3.transform.GetComponent<RectTransform>().sizeDelta.y / 2.0f;

            mur4.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width / (float)59.1);
            mur4.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height / (float)1.95);
            mur4.transform.localPosition = new Vector3(width / (float)1.28 - width / 2, -height / (float)2.51 + height / 2, 0);
            mur4.transform.GetComponent<BoxCollider>().size = new Vector3(mur4.transform.GetComponent<RectTransform>().sizeDelta.x, mur4.transform.GetComponent<RectTransform>().sizeDelta.y, 1);
            maxX = mur4.transform.localPosition.x - mur4.transform.GetComponent<RectTransform>().sizeDelta.x / 2.0f;

            murInt1.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width / (float)59.1);
            murInt1.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height / (float)8.91);
            murInt1.transform.localPosition = new Vector3(width / (float)1.52 - width / 2, -height / (float)3.59 + height / 2, 0);
            murInt1.transform.GetComponent<BoxCollider>().size = new Vector3(murInt1.transform.GetComponent<RectTransform>().sizeDelta.x, murInt1.transform.GetComponent<RectTransform>().sizeDelta.y, 1);
            int1minX = murInt1.transform.localPosition.x - murInt1.transform.GetComponent<RectTransform>().sizeDelta.x / 2.0f;
            int1maxX = murInt1.transform.localPosition.x + murInt1.transform.GetComponent<RectTransform>().sizeDelta.x / 2.0f;
            int1maxY = murInt1.transform.localPosition.y + murInt1.transform.GetComponent<RectTransform>().sizeDelta.y / 2.0f;
            int1minY = murInt1.transform.localPosition.y - murInt1.transform.GetComponent<RectTransform>().sizeDelta.y / 2.0f;

            murInt2.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width / (float)5.63);
            murInt2.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height / (float)31.2);
            murInt2.transform.localPosition = new Vector3(width / (float)1.54 - width / 2, -height / (float)1.84 + height / 2, 0);
            murInt2.transform.GetComponent<BoxCollider>().size = new Vector3(murInt2.transform.GetComponent<RectTransform>().sizeDelta.x, murInt2.transform.GetComponent<RectTransform>().sizeDelta.y, 1);
            int2minX = murInt2.transform.localPosition.x - murInt2.transform.GetComponent<RectTransform>().sizeDelta.x / 2.0f;
            int2maxX = murInt2.transform.localPosition.x + murInt2.transform.GetComponent<RectTransform>().sizeDelta.x / 2.0f;
            int2maxY = murInt2.transform.localPosition.y + murInt2.transform.GetComponent<RectTransform>().sizeDelta.y / 2.0f;
            int2minY = murInt2.transform.localPosition.y - murInt2.transform.GetComponent<RectTransform>().sizeDelta.y / 2.0f;

            pomme.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width / (float)59.1);
            pomme.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, width / (float)59.1);
            pomme.transform.localPosition = new Vector3(width / (float)1.56 - width / 2, -height / (float)2.13 + height / 2, 0);
            pomme.transform.GetComponent<SphereCollider>().radius = pomme.transform.GetComponent<RectTransform>().sizeDelta.x/2.0f;

            snake.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width / (float)59.1);
            snake.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height / (float)62.4);
            snake.transform.localPosition = new Vector3(width / (float)1.38 - width / 2, -height / (float)2.13 + height / 2, 0);
            snake.transform.GetComponent<CapsuleCollider>().radius = snake.transform.GetComponent<RectTransform>().sizeDelta.y / 2.0f;
            snake.transform.GetComponent<CapsuleCollider>().height = snake.transform.GetComponent<RectTransform>().sizeDelta.x;
            snake.transform.GetComponent<CapsuleCollider>().direction = 0;

            nb_pommes.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width / (float)3.36);
            nb_pommes.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height / (float)17.33);
            nb_pommes.transform.localPosition = new Vector3(width / (float)4.13 - width / 2, -height / (float)1.20 + height / 2, 0);
            nb_pommes.transform.GetComponent<Text>().fontSize = (int)(height / 20.8);
            action.Add("left");
        }
    }

    private void Move()
    {
        bool fini = false;
        int i = action.Count - 1;
        string value;
        bool need_to_add = false;
        string action_to_add = "";
        GameObject s = snake;
        while (!fini && i >= 0)
        {
            value = action[i];
            switch (value)
            {
                case "90":
                    need_to_add = true;
                    action_to_add = action[i - 1];
                    s.transform.Rotate(0 ,0 ,90.0f);
                    i--;
                    break;
                case "-90":
                    need_to_add = true;
                    action_to_add = action[i - 1];
                    s.transform.Rotate(0, 0, -90.0f);
                    i--;
                    break;
                case "180":
                    need_to_add = true;
                    action_to_add = action[i - 1];
                    s.transform.Rotate(0, 0, 180.0f);
                    i--;
                    break;
                case "up":
                    s.transform.localPosition = new Vector3(s.transform.localPosition.x, s.transform.localPosition.y + 10, 0);
                    //i--;
                    fini = true;
                    break;
                case "down":
                    s.transform.localPosition = new Vector3(s.transform.localPosition.x, s.transform.localPosition.y - 10, 0);
                    //i--;
                    fini = true;
                    break;
                case "left":
                    s.transform.localPosition = new Vector3(s.transform.localPosition.x - 10, s.transform.localPosition.y, 0);
                    //i--;
                    fini = true;
                    break;
                case "right":
                    s.transform.localPosition = new Vector3(s.transform.localPosition.x + 10, s.transform.localPosition.y, 0);
                    //i--;
                    fini = true;
                    break;
                default:
                    fini = true;
                    break;
            }
        }
        if (need_to_add)
        {
            action.Add(action_to_add);
        }
    }

    void Update()
    {
        if (start)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                //StartCoroutine(clicUp());
                clicUp();
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                //StartCoroutine(clicDown());
                clicDown();
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                //StartCoroutine(clicLeft());
                clicLeft();
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                //StartCoroutine(clicRight());
                clicRight();
            }
            StartCoroutine(play());
        }
    }

    public void onClicUp()
    {
        if (start)
        {
            //StartCoroutine(clicUp());
            clicUp();
        }
    }

    public void onClicDown()
    {
        if (start)
        {
            //StartCoroutine(clicDown());
            clicDown();
        }
    }

    public void onClicLeft()
    {
        if (start)
        {
            //StartCoroutine(clicLeft());
            clicLeft();
        }
    }

    public void onClicRight()
    {
        if (start)
        {
            //StartCoroutine(clicRight());
            clicRight();
        }
    }

    public void startGame()
    {
        button_start.SetActive(false);
        start = true;
    }

    private IEnumerator play()
    {
        while (!isAvaible) yield return null;
        isAvaible = false;
        yield return new WaitForSeconds(0.3f);
        Move();
        isAvaible = true;
    }

    public /*IEnumerator*/ void clicRight()
    {
        //while (!isAvaible) yield return null;
        //isAvaible = false;
        action.Add("right");
        if (action[action.Count - 2] != "right")
        {
            switch (action[action.Count - 2])
            {
                case "left":
                    action.Add("180");
                    break;
                case "up":
                    action.Add("-90");
                    break;
                case "down":
                    action.Add("90");
                    break;
                default:
                    break;
            }
        }
        Move();
        //isAvaible = true;
    }

    public /*IEnumerator*/ void clicLeft()
    {
        //while (!isAvaible) yield return null;
        //isAvaible = false;
        action.Add("left");
        if (action[action.Count - 2] != "left")
        {
            switch (action[action.Count - 2])
            {
                case "up":
                    action.Add("90");
                    break;
                case "right":
                    action.Add("180");
                    break;
                case "down":
                    action.Add("-90");
                    break;
                default:
                    break;
            }
        }
        Move();
        //isAvaible = true;
    }

    public /*IEnumerator*/ void clicDown()
    {
        //while (!isAvaible) yield return null;
        //isAvaible = false;
        action.Add("down");
        if (action[action.Count - 2] != "down")
        {
            switch (action[action.Count - 2])
            {
                case "left":
                    action.Add("90");
                    break;
                case "right":
                    action.Add("-90");
                    break;
                case "up":
                    action.Add("180");
                    break;
                default:
                    break;
            }
        }
        Move();
        //isAvaible = true;
    }

    public /*IEnumerator*/ void clicUp()
    {
        //while (!isAvaible) yield return null;
        //isAvaible = false;
        action.Add("up");
        if (action[action.Count - 2] != "up")
        {
            switch (action[action.Count - 2])
            {
                case "left":
                    action.Add("-90");
                    break;
                case "right":
                    action.Add("90");
                    break;
                case "down":
                    action.Add("180");
                    break;
                default:
                    break;
            }
        }
        Move();
        //isAvaible = true;
    }
}
