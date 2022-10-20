using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Collect : MonoBehaviour
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
            StartCoroutine(wait(1));
            SceneManager.LoadScene("ExplosionAAAAAB");
        }
        else if (collision.gameObject.name.StartsWith("pomme"))
        {
            canvas.transform.GetComponent<CollectCanvas>().nbPommes++;
            nb_pommes.transform.GetComponent<Text>().text = "pommes récoltées : " + canvas.transform.GetComponent<CollectCanvas>().nbPommes + "/" + canvas.transform.GetComponent<CollectCanvas>().maxPommes;
            if (canvas.transform.GetComponent<CollectCanvas>().nbPommes == canvas.transform.GetComponent<CollectCanvas>().maxPommes)
            {
                victoire.SetActive(true);
                StartCoroutine(wait(1));
                SceneManager.LoadScene("ArchiveAAAAAA");
            }

            GameObject pomme = canvas.transform.GetComponent<CollectCanvas>().pomme;
            float size = canvas.transform.GetComponent<CollectCanvas>().size;
            pomme.GetComponent<RectTransform>().anchoredPosition = new Vector2(
                UnityEngine.Random.Range(canvas.transform.GetComponent<CollectCanvas>().minX + size, canvas.transform.GetComponent<CollectCanvas>().maxX - size),
                UnityEngine.Random.Range(canvas.transform.GetComponent<CollectCanvas>().minY + size, canvas.transform.GetComponent<CollectCanvas>().maxY - size)
            );
            float x = pomme.GetComponent<RectTransform>().anchoredPosition.x;
            float y = pomme.GetComponent<RectTransform>().anchoredPosition.y;
        }
    }

    IEnumerator wait(int secondes)
    {
        yield return new WaitForSeconds(secondes);
    }
}
