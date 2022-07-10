using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ScenarACB : MonoBehaviour
{
    public Button scenarioText;
    public Button panel;
    public Sprite sprite;

    public List<string> scenario = new List<string>();

    public int indice = 0;

    void Start()
    {
        scenario.Add("Le message “GAME OVER” s’affiche devant vos yeux et vous palissez. Vous avez comme un mauvais pressentiment cette fois-ci.");
        scenario.Add("Un quart de seconde plus tard, des lasers sortant des parois autour de la porte, vous découpent en fines lamelles.");
        scenario.Add("Cette porte était piégée, et vous venez de payer les conséquences de votre échec.");
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
        else if (indice == scenario.Count)
        {
            panel.GetComponent<Image>().sprite = sprite;
            scenarioText.transform.Find("Text").gameObject.GetComponent<Text>().text = "Cette mission est un échec sur toute la ligne, mais au moins vous avez bénéficié d’une mort rapide...";
            indice++;
        }
        else
        {
            SceneManager.LoadScene("Intro");
        }
    }
}