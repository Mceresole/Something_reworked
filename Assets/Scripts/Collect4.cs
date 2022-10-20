using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Collect4 : MonoBehaviour
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
            SceneManager.LoadScene("EspaceBB");
        }
        else if (collision.gameObject.name.StartsWith("pomme"))
        {
            canvas.transform.GetComponent<CollectCanvas4>().nbPommes++;
            nb_pommes.transform.GetComponent<Text>().text = "pommes récoltées : " + canvas.transform.GetComponent<CollectCanvas4>().nbPommes + "/" + canvas.transform.GetComponent<CollectCanvas4>().maxPommes;
            if (canvas.transform.GetComponent<CollectCanvas4>().nbPommes == canvas.transform.GetComponent<CollectCanvas4>().maxPommes)
            {
                victoire.SetActive(true);
                StartCoroutine(wait(2));
                SceneManager.LoadScene("LaboBA");
            }

            GameObject pomme = canvas.transform.GetComponent<CollectCanvas4>().pomme;
            pomme.GetComponent<RectTransform>().anchoredPosition = new Vector2(
                UnityEngine.Random.Range(canvas.transform.GetComponent<CollectCanvas4>().minX, canvas.transform.GetComponent<CollectCanvas4>().maxX),
                UnityEngine.Random.Range(canvas.transform.GetComponent<CollectCanvas4>().minY, canvas.transform.GetComponent<CollectCanvas4>().maxY)
            );
            float x = pomme.GetComponent<RectTransform>().anchoredPosition.x;
            float y = pomme.GetComponent<RectTransform>().anchoredPosition.y;
            while ((x > canvas.transform.GetComponent<CollectCanvas4>().int1minX && x < canvas.transform.GetComponent<CollectCanvas4>().int1maxX
                            && y > canvas.transform.GetComponent<CollectCanvas4>().int1minY && y < canvas.transform.GetComponent<CollectCanvas4>().int1maxY) ||
                    (x > canvas.transform.GetComponent<CollectCanvas4>().int2minX && x < canvas.transform.GetComponent<CollectCanvas4>().int2maxX
                            && y > canvas.transform.GetComponent<CollectCanvas4>().int2minY && y < canvas.transform.GetComponent<CollectCanvas4>().int2maxY) ||
                    (x > canvas.transform.GetComponent<CollectCanvas4>().int3minX && x < canvas.transform.GetComponent<CollectCanvas4>().int3maxX
                            && y > canvas.transform.GetComponent<CollectCanvas4>().int3minY && y < canvas.transform.GetComponent<CollectCanvas4>().int3maxY) ||
                    (x > canvas.transform.GetComponent<CollectCanvas4>().int4minX && x < canvas.transform.GetComponent<CollectCanvas4>().int4maxX
                            && y > canvas.transform.GetComponent<CollectCanvas4>().int4minY && y < canvas.transform.GetComponent<CollectCanvas4>().int4maxY))
            {
                pomme.GetComponent<RectTransform>().anchoredPosition = new Vector2(
                    UnityEngine.Random.Range(canvas.transform.GetComponent<CollectCanvas4>().minX, canvas.transform.GetComponent<CollectCanvas4>().maxX),
                    UnityEngine.Random.Range(canvas.transform.GetComponent<CollectCanvas4>().minY, canvas.transform.GetComponent<CollectCanvas4>().maxY)
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
