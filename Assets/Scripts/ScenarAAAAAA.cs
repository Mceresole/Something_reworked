using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ScenarAAAAAA : MonoBehaviour
{
    public Button scenarioText;
    public Button panel;
    public Sprite sprite;



    public List<string> scenario = new List<string>();

    public int indice = 0;

    void Start()
    {
        scenario.Add("La sortie, ENFIN ! Vous vous précipitez dans votre vaisseau et appuyez pour refermer la porte alors que déjà des bruits se font entendre dans le couloir.");
        scenario.Add("Vous observez la fente se refermer lentement quand Loulou surgit de nulle part et bondit dans l’espace restant, juste avant que la porte ne soit fermée.");
        scenario.Add("Il saute sur les épaules du capitaine et se réfugie contre lui, probablement terrifié. Vous vous souvenez alors qu’une partie de cette histoire est sa faute, mais vous décidez de laisser votre rancune pour plus tard. Pour l’instant, vous avez plus important à faire.");
        scenario.Add("Vous courez dans le vaisseau, laissez les commandes au capitaine qui, lui, sait piloter, même si ça fait un moment depuis la dernière fois, et vous vous empressez de vous désamarrer de l’autre vaisseau.");
        scenario.Add("Vous fuyez ensuite le plus loin possible décidant que rentrer chez vous était une bonne idée. Cette histoire vous marquera à vie, et plus jamais, au grand jamais, vous ne remonterez à bord d’un vaisseau !");
        scenarioText.transform.Find("Text").gameObject.GetComponent<Text>().text = scenario[indice];
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
            scenarioText.transform.Find("Text").gameObject.GetComponent<Text>().text = "Bravo, vous avez survécu à un piège mortel ! Vous êtes traumatisé à vie et vous ne repartirez jamais en mission, mais vous êtes vivant ! A votre retour de mission, vous avez demandé une mutation aux archives du bureau des naissances, juste pour être sûr.";
            indice++;
        }
        else
        {
            SceneManager.LoadScene("Intro");
        }


    }
}

