using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ScenarACAABB : MonoBehaviour
{
    public Button scenarioText;
    public Button panel;
    public Sprite sprite;

    private List<string> scenario = new List<string>();

    private int indice = 0;

    void Start()
    {
        scenario.Add("Le message “porte verrouillée” s’affiche devant vos yeux et vous paniquez. Vous commencez à être surpassé par le nombre, et des renforts armés arrivent !");
        scenario.Add("Vous regardez donc autour de vous désespérés et quelque chose saute dans votre cerveau. Vous dégainez alors votre sabre et vous prenez pour une espèce de grosse brute, héros d’un film d’action, avant de vous jeter dans le tas en criant.");
        scenario.Add("Une seconde plus tard, un rayon plasmique vous fait exploser !");
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
            scenarioText.transform.Find("Text").gameObject.GetComponent<Text>().text = "Je crois que vous avez regardez trop de films d’action… Vous pensiez sérieusement pouvoir devenir Rambo ?";
            indice++;
        }
        else
        {
            SceneManager.LoadScene("Intro");
        }
    }
}
