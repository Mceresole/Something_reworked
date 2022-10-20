using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Collect2 : MonoBehaviour
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
            SceneManager.LoadScene("SushiAABB");
        }
        else if (collision.gameObject.name.StartsWith("pomme"))
        {
            canvas.transform.GetComponent<CollectCanvas2>().nbPommes++;
            nb_pommes.transform.GetComponent<Text>().text = "pommes récoltées : " + canvas.transform.GetComponent<CollectCanvas2>().nbPommes + "/" + canvas.transform.GetComponent<CollectCanvas2>().maxPommes;
            if (canvas.transform.GetComponent<CollectCanvas2>().nbPommes == canvas.transform.GetComponent<CollectCanvas2>().maxPommes)
            {
                victoire.SetActive(true);
                StartCoroutine(wait(2));
                SceneManager.LoadScene("CuisineAABA");
            }

            GameObject pomme = canvas.transform.GetComponent<CollectCanvas2>().pomme;
            pomme.GetComponent<RectTransform>().anchoredPosition = new Vector2(
                UnityEngine.Random.Range(canvas.transform.GetComponent<CollectCanvas2>().minX, canvas.transform.GetComponent<CollectCanvas2>().maxX),
                UnityEngine.Random.Range(canvas.transform.GetComponent<CollectCanvas2>().minY, canvas.transform.GetComponent<CollectCanvas2>().maxY)
            );
            float x = pomme.GetComponent<RectTransform>().anchoredPosition.x;
            float y = pomme.GetComponent<RectTransform>().anchoredPosition.y;
            while ((x > canvas.transform.GetComponent<CollectCanvas2>().int1minX && x < canvas.transform.GetComponent<CollectCanvas2>().int1maxX
                            && y > canvas.transform.GetComponent<CollectCanvas2>().int1minY && y < canvas.transform.GetComponent<CollectCanvas2>().int1maxY) ||
                    (x > canvas.transform.GetComponent<CollectCanvas2>().int2minX && x < canvas.transform.GetComponent<CollectCanvas2>().int2maxX
                            && y > canvas.transform.GetComponent<CollectCanvas2>().int2minY && y < canvas.transform.GetComponent<CollectCanvas2>().int2maxY) ||
                    (x > canvas.transform.GetComponent<CollectCanvas2>().int3minX && x < canvas.transform.GetComponent<CollectCanvas2>().int3maxX
                            && y > canvas.transform.GetComponent<CollectCanvas2>().int3minY && y < canvas.transform.GetComponent<CollectCanvas2>().int3maxY) ||
                    (x > canvas.transform.GetComponent<CollectCanvas2>().int4minX && x < canvas.transform.GetComponent<CollectCanvas2>().int4maxX
                            && y > canvas.transform.GetComponent<CollectCanvas2>().int4minY && y < canvas.transform.GetComponent<CollectCanvas2>().int4maxY))
            {
                pomme.GetComponent<RectTransform>().anchoredPosition = new Vector2(
                    UnityEngine.Random.Range(canvas.transform.GetComponent<CollectCanvas2>().minX, canvas.transform.GetComponent<CollectCanvas2>().maxX),
                    UnityEngine.Random.Range(canvas.transform.GetComponent<CollectCanvas2>().minY, canvas.transform.GetComponent<CollectCanvas2>().maxY)
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
