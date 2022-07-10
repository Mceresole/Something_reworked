using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ScenarACAB : MonoBehaviour
{
    public Button scenarioText;
    public Button panel;
    public Sprite sprite;

    public List<string> scenario = new List<string>();

    public int indice = 0;

    void Start()
    {
        scenario.Add("Avec horreur vous réalisez que vous avez mis trop de temps. Vous n’avez pas le temps de comprendre ce qu’il se passe que vous êtes dispersé en fines particules avec le vaisseau.");
        scenarioText.transform.Find("Text").gameObject.GetComponent<Text>().text = scenario[0];
        indice++;
    }

    void Update()
    {

    }

    public void updateScenar()
    {
        if (indice < scenario.Count)
        {
            scenarioText.transform.Find("Text").gameObject.GetComponent<Text>().text = scenario[indice];
            indice++;
        }
        else if (indice == scenario.Count) {
            panel.GetComponent<Image>().sprite = sprite;
            scenarioText.transform.Find("Text").gameObject.GetComponent<Text>().text = "Vous avez fait BOUM. C’était une salle d’armes, vous auriez pu vous douter que ce serait dangereux de laisser un singe et un pilote, un peu crétin par moment, entrer dans la pièce.";
            indice++;
        }
        else
        {
            SceneManager.LoadScene("Intro");
        }
    }
}