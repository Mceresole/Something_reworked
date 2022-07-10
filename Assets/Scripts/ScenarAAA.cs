using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScenarAAA : MonoBehaviour
{

    public Button scenarioText;
    public Text questionText;
    public Button reponse1Text;
    public Button reponse2Text;
    public Button panel;
    public Sprite sprite;

    private List<string> scenario = new List<string>();
    private List<string> scenario1 = new List<string>();
    private List<string> scenario2 = new List<string>();
    private string question;
    private int i = 0;
    private int branche = 0;

    private void Start()
    {
        scenario.Add("La porte s’ouvre devant vous sur une salle de repos.");
        scenario.Add("Au centre de la salle, sur une table à manger, se trouve Innoth en train de se faire dévorer par un alien gigantesque, vert avec des yeux de mouche, des antennes et quatre bras, tous enfoncés dans le corps de votre amie.");
        scenario.Add("Vous reculez en essayant de rester discret et appuyez frénétiquement sur le bouton de la porte pour la refermer. Mais vous savez... vous savez qu’il vous a vu ! Vous avez croisé son regard.");
        scenario.Add("Vous ne vous attardez pas et partez en courant dans le sens inverse. Cinq secondes plus tard, la porte se rouvre sur le monstre. Vous savez que le timing est serré et que vous devez vous échapper, malheureusement, le capitaine glisse sur le sang et tombe.");
        scenario.Add("Vous pouvez alors choisir de l’aider ou de l’abandonner à son sort :");
        scenarioText.transform.Find("Text").gameObject.GetComponent<Text>().text = scenario[i];
        i++;

        scenario1.Add("Vous ne pouvez pas vous résoudre à abandonner votre ami, alors vous faites demi-tour pour l’aider. Comme vous vous en doutiez malheureusement, ce temps perdu a suffi pour que l’alien vous rattrape.");
        scenario1.Add("Vous recevez un coup sur la tête, voyez mille chandelles puis le noir complet.");
        scenario1.Add("Quand vous rouvrez les yeux, vous êtes dans ce qui semble être le garde-manger du vaisseau. Il semblerait qu’Innoth ait suffi pour le rassasier et qu’il vous garde pour plus tard. ");
        scenario1.Add("Le capitaine est à côté de vous, inconscient. Vous le secouez donc pour le réveillez.");
        scenario1.Add("“Où sommes-nous ?”");
        scenario1.Add("“Dans le garde-manger je dirais. Nous devons trouver un moyen de sortir ou nous finirons en casse-croûte.”");
        scenario1.Add("Vous cherchez autour de vous la porte et finissait par la trouver. Malheureusement, elle ne s’ouvre pas de l’intérieur. Toutefois, un boitier éléctrique s'y trouve. Vous l’ouvrez et commencer à comprendre comment il fonctionne avant de réaliser :");
        scenario1.Add("“Mais il s’agit de tours de Hanoï ! Décidément, la conception de ce vaisseau m’étonnera toujours !”");
        scenario1.Add("“Vous pouvez ouvrir la porte ?”");
        scenario1.Add("“Oui, si j’arrive à placer ces trois anneaux à gauche sur la barre de droite, comme pour des tours de Hanoï classique, je devrais pouvoir court-circuiter les commandes et ouvrir la porte !”");
        scenario1.Add("“Dans ce cas, dépêchez-vous, je ne veux pas être ici quand il reviendra !”");

        scenario2.Add("Vous suivez votre instinct de survie et partez en courant en laissant le capitaine derrière vous. Vous slalomez dans les couloirs sans savoir où vous allez, cherchant juste à vous éloigner le plus loin possible, en espérant secrètement et honteusement que dévorer le capitaine le retiendra un peu.");
        scenario2.Add("Vous percutez alors quelque chose et tombez douloureusement par terre.");
        scenario2.Add("Vous relevez la tête, ne comprenant pas ce qu’il vient de se passer et vous voyez le groupe d’aliens que vous venez de percuter... Oups !");
        scenario2.Add("Vous n’avez aucune chance. Avant que vous ayez pu faire le moindre geste, ils se sont jetés sur vous, et ils sont maintenant en train de vous dévorer vivant.");


        questionText.text = "";
    }

    void Update()
    {

    }

    public void updateScenar()
    {
        if (i == scenario.Count - 1 && branche == 0)
        {
            scenarioText.gameObject.SetActive(false);
            questionText.text = scenario[i];

            reponse1Text.gameObject.SetActive(true);
            reponse2Text.gameObject.SetActive(true);
        }
        else
        {
            if (i != scenario.Count)
            {
                scenarioText.transform.Find("Text").gameObject.GetComponent<Text>().text = scenario[i];
                i++;
            }
            else
            {
                if (branche == 1)
                {
                    SceneManager.LoadScene("Hanoi");
                }
                else if (i == scenario.Count)
                {
                    panel.GetComponent<Image>().sprite = sprite;
                    scenarioText.transform.Find("Text").gameObject.GetComponent<Text>().text = "Abandonner votre ami était un choix lâche qui vient de se retourner contre vous. Vous devriez peut-être en tirer une leçon.";
                    i++;
                }
                else
                {
                    SceneManager.LoadScene("Intro");
                }
            }
        }
    }

    public void clicRep1()
    {
        scenario = scenario1;
        branche = 1;
        questionText.text = "";
        reponse1Text.gameObject.SetActive(false);
        reponse2Text.gameObject.SetActive(false);
        i = 0;
        scenarioText.gameObject.SetActive(true);
        scenarioText.transform.Find("Text").gameObject.GetComponent<Text>().text = scenario[i];
        i++;
    }

    public void clicRep2()
    {
        scenario = scenario2;
        branche = 2;
        questionText.text = "";
        reponse1Text.gameObject.SetActive(false);
        reponse2Text.gameObject.SetActive(false);
        i = 0;
        scenarioText.gameObject.SetActive(true);
        scenarioText.transform.Find("Text").gameObject.GetComponent<Text>().text = scenario[i];
        i++;
    }
}
