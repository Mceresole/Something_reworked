using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ScenarAAAAAB : MonoBehaviour
{
    public Button scenarioText;
    public Button panel;
    public Sprite sprite;

    private List<string> scenario = new List<string>();

    private int indice = 0;

    void Start()
    {
        scenario.Add("Une seule erreur et le piège vient de se refermer sur vous. Des pas se font entendre dans le couloir et vous savez que vous êtes perdu. Vous décidez alors que vous préférez choisir votre mort.");
        scenario.Add("Vous frappez sur une des barres du mur jusqu’à ce qu’elle se casse, en espérant en faire une arme pour vous défendre. ");
        scenario.Add("Mais la chance n’est pas avec vous aujourd’hui, et ce que vous aviez pris pour une barre en métal était en fait une conduite de gaz hautement inflammable. Quand elle se casse, une étincelle se produit et vous êtes pulvérisés par l’explosion.");
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
            scenarioText.transform.Find("Text").gameObject.GetComponent<Text>().text = "Quand le destin vous en veut, vous ne pouvez rien faire pour y échapper. Ce n’était décidément pas votre jour. La mort vous attendait.";
            indice++;
        }
        else
        {
            SceneManager.LoadScene("Intro");
        }
    }
}

