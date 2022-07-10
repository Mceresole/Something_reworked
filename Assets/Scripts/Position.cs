using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Position : MonoBehaviour
{
    public Button panel;
    public Button phrase;
    public Text question = null;
    public Button reponse1 = null;
    public Button reponse2 = null;
    public Button reponse3 = null;
    public Canvas canvas;

    // Start is called before the first frame update
    void Start()
    {
        float width = canvas.GetComponent<RectTransform>().sizeDelta.x;
        float height = canvas.GetComponent<RectTransform>().sizeDelta.y;
        panel.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width / (float)1.1);
        panel.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height / (float)3.5);
        panel.transform.localPosition = new Vector3(width / (float)2.0 - width / 2, -height / (float)1.3 + height / 2, 0);

        phrase.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width / (float)1.2);
        phrase.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height / (float)4.6);
        phrase.transform.localPosition = new Vector3(width / (float)2.0 - width / 2, -height / (float)1.3 + height / 2, 0);
        phrase.transform.Find("Text").gameObject.GetComponent<Text>().fontSize = (int) (phrase.transform.GetComponent<RectTransform>().sizeDelta.y / (float)4.6);


        if (question != null)
        {
            question.fontSize = (int)(phrase.transform.GetComponent<RectTransform>().sizeDelta.y / (float)4.6);

            reponse1.transform.Find("Text").gameObject.GetComponent<Text>().fontSize = (int) (reponse1.transform.GetComponent<RectTransform>().sizeDelta.y / (float)1.42);
            reponse2.transform.Find("Text").gameObject.GetComponent<Text>().fontSize = (int) (reponse2.transform.GetComponent<RectTransform>().sizeDelta.y / (float)1.42);

            if (reponse3 != null)
            {
                reponse3.transform.Find("Text").gameObject.GetComponent<Text>().fontSize = (int) (reponse3.transform.GetComponent<RectTransform>().sizeDelta.y / (float)1.42);

                question.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width / (float)1.2);
                question.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height / (float)16.13);
                question.transform.localPosition = new Vector3(width / (float)2.0 - width / 2, -height / (float)1.46 + height / 2, 0);
                
                reponse1.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width / (float)1.2);
                reponse1.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height / (float)18.6);
                reponse1.transform.localPosition = new Vector3(width / (float)1.97 - width / 2, -height / (float)1.31 + height / 2, 0);

                reponse2.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width / (float)1.2);
                reponse2.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height / (float)18.6);
                reponse2.transform.localPosition = new Vector3(width / (float)1.97 - width / 2, -height / (float)1.23 + height / 2, 0);

                reponse3.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width / (float)1.2);
                reponse3.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height / (float)18.6);
                reponse3.transform.localPosition = new Vector3(width / (float)1.97 - width / 2, -height / (float)1.14 + height / 2, 0);
            }
            else
            {
                question.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width / (float)1.2);
                question.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height / (float)11.6);
                question.transform.localPosition = new Vector3(width / (float)2.0 - width / 2, -height / (float)1.39 + height / 2, 0);
                
                reponse1.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width / (float)1.2);
                reponse1.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height / (float)18.6);
                reponse1.transform.localPosition = new Vector3(width / (float)1.97 - width / 2, -height / (float)1.23 + height / 2, 0);

                reponse2.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width / (float)1.2);
                reponse2.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height / (float)18.6);
                reponse2.transform.localPosition = new Vector3(width / (float)1.97 - width / 2, -height / (float)1.14 + height / 2, 0);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
