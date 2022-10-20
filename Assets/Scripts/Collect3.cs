using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Collect3 : MonoBehaviour
{
    public GameObject gameOver;
    public GameObject victoire;
    public Canvas canvas;
    public Text nb_pommes;


    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name.StartsWith("mur"))
        {
            gameOver.SetActive(true);
            StartCoroutine(wait(2));
            SceneManager.LoadScene("RamboACAABB");
        }
        else if (collision.gameObject.name.StartsWith("pomme"))
        {
            canvas.transform.GetComponent<CollectCanvas3>().nbPommes++;
            nb_pommes.transform.GetComponent<Text>().text = "pommes récoltées : " + canvas.transform.GetComponent<CollectCanvas3>().nbPommes + "/" + canvas.transform.GetComponent<CollectCanvas3>().maxPommes;
            if (canvas.transform.GetComponent<CollectCanvas3>().nbPommes == canvas.transform.GetComponent<CollectCanvas3>().maxPommes)
            {
                victoire.SetActive(true);
                StartCoroutine(wait(2));
                SceneManager.LoadScene("PilotageACAABA");
            }

            GameObject pomme = canvas.transform.GetComponent<CollectCanvas3>().pomme;
            pomme.GetComponent<RectTransform>().anchoredPosition = new Vector2(
                UnityEngine.Random.Range(canvas.transform.GetComponent<CollectCanvas3>().minX, canvas.transform.GetComponent<CollectCanvas3>().maxX),
                UnityEngine.Random.Range(canvas.transform.GetComponent<CollectCanvas3>().minY, canvas.transform.GetComponent<CollectCanvas3>().maxY)
            );
            float x = pomme.GetComponent<RectTransform>().anchoredPosition.x;
            float y = pomme.GetComponent<RectTransform>().anchoredPosition.y;
            while ((x > canvas.transform.GetComponent<CollectCanvas3>().intminX && x < canvas.transform.GetComponent<CollectCanvas3>().intmaxX
                            && y > canvas.transform.GetComponent<CollectCanvas3>().intminY && y < canvas.transform.GetComponent<CollectCanvas3>().intmaxY))
            {
                pomme.GetComponent<RectTransform>().anchoredPosition = new Vector2(
                    UnityEngine.Random.Range(canvas.transform.GetComponent<CollectCanvas3>().minX, canvas.transform.GetComponent<CollectCanvas3>().maxX),
                    UnityEngine.Random.Range(canvas.transform.GetComponent<CollectCanvas3>().minY, canvas.transform.GetComponent<CollectCanvas3>().maxY)
                );
                x = pomme.GetComponent<RectTransform>().anchoredPosition.x;
                y = pomme.GetComponent<RectTransform>().anchoredPosition.y;
            }
        }
    }

    IEnumerator wait(int secondes)
    {
        yield return new WaitForSeconds(secondes);
    }
}
