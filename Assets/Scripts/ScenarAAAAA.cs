using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ScenarAAAAA : MonoBehaviour
{
    public Button scenarioText;

    private List<string> scenario = new List<string>();

    private int indice = 0;

    void Start()
    {
        scenario.Add("La porte s’ouvre enfin. Alors, avec le capitaine, vous ne vous attardez pas dans ce vaisseau de mort et choisissez de rejoindre la sortie. Tant pis pour Sekip et Loulou, de toute façon, ils n’ont aucune chance, et si vous tentez de les aidez, vous non plus.");
        scenario.Add("Par chance, un plan se trouve non loin et vous permet de vous localiser.");
        scenario.Add("Vous avancez donc précautionneusement dans les couloirs, vous arrêtant au moindre bruit et prêt à vous cacher à tout moment, et arrivez par miracle, en vie, à la porte qui vous a permis de rentrer dans ce piège.");
        scenario.Add("Vous vous apprêtez donc à refaire le memory quand vous réalisez que le jeu à changer ! Vous êtes désormais devant une espèce de snake revisitée !");
        scenario.Add("Vous vous lancez donc en jurant que plus jamais vous ne ferez de mini-jeux de votre vie ensuite.");
        scenarioText.transform.Find("Text").gameObject.GetComponent<Text>().text = scenario[0];
        indice++;
    }


    public void updateScenar()
    {
        if (indice != scenario.Count)
        {
            scenarioText.transform.Find("Text").gameObject.GetComponent<Text>().text = scenario[indice];
            indice++;
        }
        else
            SceneManager.LoadScene("Collect");
    }
}
