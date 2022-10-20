using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CollectCanvas : MonoBehaviour
{
    private List<string> action = new List<string>();
    private const float SNAKE_SPEED = 5f;
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
    public float size;

    private bool start;
    private bool flag = true;
    
    void Start()
    {
        if (flag)
        {
            float width = this.GetComponent<RectTransform>().sizeDelta.x;
            float height = this.GetComponent<RectTransform>().sizeDelta.y;
            float divWidth = width / (float)1025.2;
            float divHeight = height / (float)444.4;
            up.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 70 * divWidth);
            up.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 70 * divHeight);
            up.GetComponent<RectTransform>().anchoredPosition = new Vector2(235 * divWidth, -220 * divHeight);

            down.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 70 * divWidth);
            down.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 70 * divHeight);
            down.GetComponent<RectTransform>().anchoredPosition = new Vector2(235 * divWidth, -310 * divHeight);

            left.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 70 * divWidth);
            left.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 70 * divHeight);
            left.GetComponent<RectTransform>().anchoredPosition = new Vector2(155 * divWidth, -270 * divHeight);

            right.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 70 * divWidth);
            right.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 70 * divHeight);
            right.GetComponent<RectTransform>().anchoredPosition = new Vector2(315 * divWidth, -270 * divHeight);

            mur1.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 350 * divWidth);
            mur1.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 20 * divHeight);
            mur1.GetComponent<RectTransform>().anchoredPosition = new Vector2(755 * divWidth, -99 * divHeight);
            mur1.transform.GetComponent<BoxCollider>().size = new Vector3(mur1.transform.GetComponent<RectTransform>().sizeDelta.x, mur1.transform.GetComponent<RectTransform>().sizeDelta.y, 1);
            maxY = mur1.GetComponent<RectTransform>().anchoredPosition.y - mur1.transform.GetComponent<RectTransform>().sizeDelta.y / 2.0f;

            mur2.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 20 * divWidth);
            mur2.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 320 * divHeight);
            mur2.GetComponent<RectTransform>().anchoredPosition = new Vector2(590 * divWidth, -249 * divHeight);
            mur2.transform.GetComponent<BoxCollider>().size = new Vector3(mur2.transform.GetComponent<RectTransform>().sizeDelta.x, mur2.transform.GetComponent<RectTransform>().sizeDelta.y, 1);
            minX = mur2.GetComponent<RectTransform>().anchoredPosition.x + mur2.transform.GetComponent<RectTransform>().sizeDelta.x / 2.0f;

            mur3.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 350 * divWidth);
            mur3.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 20 * divHeight);
            mur3.GetComponent<RectTransform>().anchoredPosition = new Vector2(755 * divWidth, -399 * divHeight);
            mur3.transform.GetComponent<BoxCollider>().size = new Vector3(mur3.transform.GetComponent<RectTransform>().sizeDelta.x, mur3.transform.GetComponent<RectTransform>().sizeDelta.y, 1);
            minY = mur3.GetComponent<RectTransform>().anchoredPosition.y + mur3.transform.GetComponent<RectTransform>().sizeDelta.y / 2.0f;

            mur4.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 20 * divWidth);
            mur4.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 320 * divHeight);
            mur4.GetComponent<RectTransform>().anchoredPosition = new Vector2(920 * divWidth, -249 * divHeight);
            mur4.transform.GetComponent<BoxCollider>().size = new Vector3(mur4.transform.GetComponent<RectTransform>().sizeDelta.x, mur4.transform.GetComponent<RectTransform>().sizeDelta.y, 1);
            maxX = mur4.GetComponent<RectTransform>().anchoredPosition.x - mur4.transform.GetComponent<RectTransform>().sizeDelta.x / 2.0f;

            pomme.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 20 * divWidth);
            pomme.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 20 * divWidth);
            pomme.GetComponent<RectTransform>().anchoredPosition = new Vector2(760 * divWidth, -293 * divHeight);
            pomme.transform.GetComponent<SphereCollider>().radius = pomme.transform.GetComponent<RectTransform>().sizeDelta.x / 2.0f;

            snake.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 20 * divWidth);
            snake.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 10 * divHeight);
            snake.GetComponent<RectTransform>().anchoredPosition = new Vector2(855 * divWidth, -293 * divHeight);
            snake.transform.GetComponent<CapsuleCollider>().radius = snake.transform.GetComponent<RectTransform>().sizeDelta.y / 2.0f;
            snake.transform.GetComponent<CapsuleCollider>().height = snake.transform.GetComponent<RectTransform>().sizeDelta.x;
            snake.transform.GetComponent<CapsuleCollider>().direction = 0;
            size = snake.transform.GetComponent<RectTransform>().sizeDelta.x / 2.0f;

            nb_pommes.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 352 * divWidth);
            nb_pommes.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 36 * divHeight);
            nb_pommes.GetComponent<RectTransform>().anchoredPosition = new Vector2(286 * divWidth, -418 * divHeight);
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
                    fini = true;
                    break;
                case "-90":
                    need_to_add = true;
                    action_to_add = action[i - 1];
                    s.transform.Rotate(0, 0, -90.0f);
                    i--;
                    fini = true;
                    break;
                case "180":
                    need_to_add = true;
                    action_to_add = action[i - 1];
                    s.transform.Rotate(0, 0, 180.0f);
                    i--;
                    fini = true;
                    break;
                case "up":
                    s.GetComponent<RectTransform>().anchoredPosition = new Vector2(s.GetComponent<RectTransform>().anchoredPosition.x, s.GetComponent<RectTransform>().anchoredPosition.y + 10 * SNAKE_SPEED * Time.deltaTime) ;
                    fini = true;
                    break;
                case "down":
                    s.GetComponent<RectTransform>().anchoredPosition = new Vector2(s.GetComponent<RectTransform>().anchoredPosition.x, s.GetComponent<RectTransform>().anchoredPosition.y - 10 * SNAKE_SPEED * Time.deltaTime);
                    fini = true;
                    break;
                case "left":
                    s.GetComponent<RectTransform>().anchoredPosition = new Vector2(s.GetComponent<RectTransform>().anchoredPosition.x - 10 * SNAKE_SPEED * Time.deltaTime, s.GetComponent<RectTransform>().anchoredPosition.y);
                    fini = true;
                    break;
                case "right":
                    s.GetComponent<RectTransform>().anchoredPosition = new Vector2(s.GetComponent<RectTransform>().anchoredPosition.x + 10 * SNAKE_SPEED * Time.deltaTime, s.GetComponent<RectTransform>().anchoredPosition.y);
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
                clicUp();
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                clicDown();
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                clicLeft();
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                clicRight();
            }
            StartCoroutine(play());
        }
    }

    public void onClicUp()
    {
        if (start)
        {
            clicUp();
        }
    }

    public void onClicDown()
    {
        if (start)
        {
            clicDown();
        }
    }

    public void onClicLeft()
    {
        if (start)
        {
            clicLeft();
        }
    }

    public void onClicRight()
    {
        if (start)
        {
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
        Move();
        isAvaible = true;
    }

    public void clicRight()
    {
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
    }

    public void clicLeft()
    {
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
    }

    public void clicDown()
    {
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
    }

    public void clicUp()
    {
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
    }
}
