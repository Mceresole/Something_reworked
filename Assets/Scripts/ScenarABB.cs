using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ScenarABB : MonoBehaviour
{
    public Button scenarioText;
    public Button panel;
    public Sprite sprite;

    private List<string> scenario = new List<string>();

    private int indice = 0;

    void Start()
    {
        scenario.Add("Vous échouez au mini-jeu et un bip sonore retentit.");
        scenario.Add("L’instant d’après, vous vous faites écraser par la porte qui vous tombe dessus sans prévenir.");
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
            scenarioText.transform.Find("Text").gameObject.GetComponent<Text>().text = "N’avez-vous pas l’impression d’être devenu Scrat ?";
            indice++;
        }
        else
        {
            SceneManager.LoadScene("Intro");
        }
    }
}



