using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ScenarBB : MonoBehaviour
{
    public Button scenarioText;
    public Button panel;
    public Sprite sprite;


    private List<string> scenario = new List<string>();

    private int indice = 0;

    void Start()
    {
        scenario.Add("Vous avez encore échoué… Alors que vos coéquipiers vous enguirlandent et que Loulou se moque de vous, une secousse sous vos pieds vous déséquilibre. Alors, vous avez un mauvais pressentiment.");
        scenario.Add("Vous vous précipitez vers le côté gauche de la pièce pour tenter de rejoindre le sas de pression pour sortir, mais ce que vous craignez se produit avant que vous puissiez l’atteindre.");
        scenario.Add("Devant vos yeux ébahis, la grande porte extérieure du hangar s'ouvre. L’instant d’après vous vous sentez aspiré vers l’extérieur.");
        scenario.Add("Vous observez bientôt l’espace autour de vous, et vous savez que c’est la fin. Votre première mission vous aura été fatale, et c’est entièrement votre faute.");
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
            scenarioText.transform.Find("Text").gameObject.GetComponent<Text>().text = "Savez-vous que d'après la NASA, la durée de vie moyenne d’un astronaute dans l’espace, sans combinaison, est d’environ 90s ?";
            indice++;
        }
        else
        {
            SceneManager.LoadScene("Intro");
        }
    }
}