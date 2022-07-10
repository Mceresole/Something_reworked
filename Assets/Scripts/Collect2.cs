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
            SceneManager.LoadScene("ExplosionAAAAAB");
        }
        else if (collision.gameObject.name.StartsWith("pomme"))
        {
            canvas.transform.GetComponent<CollectCanvas2>().nbPommes++;
            nb_pommes.transform.GetComponent<Text>().text = "pommes récoltées : " + canvas.transform.GetComponent<CollectCanvas2>().nbPommes + "/" + canvas.transform.GetComponent<CollectCanvas2>().maxPommes;
            if (canvas.transform.GetComponent<CollectCanvas2>().nbPommes == canvas.transform.GetComponent<CollectCanvas2>().maxPommes)
            {
                victoire.SetActive(true);
                StartCoroutine(wait(2));
                SceneManager.LoadScene("ArchiveAAAAAA");
            }

            GameObject pomme = canvas.transform.GetComponent<CollectCanvas2>().pomme;
            pomme.transform.localPosition = new Vector3(
                UnityEngine.Random.Range(canvas.transform.GetComponent<CollectCanvas2>().minX, canvas.transform.GetComponent<CollectCanvas2>().maxX),
                UnityEngine.Random.Range(canvas.transform.GetComponent<CollectCanvas2>().minY, canvas.transform.GetComponent<CollectCanvas2>().maxY),
                0
            );
            float x = pomme.transform.localPosition.x;
            float y = pomme.transform.localPosition.y;
            while ((x > canvas.transform.GetComponent<CollectCanvas2>().int1minX && x < canvas.transform.GetComponent<CollectCanvas2>().int1maxX
                            && y > canvas.transform.GetComponent<CollectCanvas2>().int1minY && y < canvas.transform.GetComponent<CollectCanvas2>().int1maxY) ||
                    (x > canvas.transform.GetComponent<CollectCanvas2>().int2minX && x < canvas.transform.GetComponent<CollectCanvas2>().int2maxX
                            && y > canvas.transform.GetComponent<CollectCanvas2>().int2minY && y < canvas.transform.GetComponent<CollectCanvas2>().int2maxY))
            {
                pomme.transform.localPosition = new Vector3(
                    UnityEngine.Random.Range(canvas.transform.GetComponent<CollectCanvas2>().minX, canvas.transform.GetComponent<CollectCanvas2>().maxX),
                    UnityEngine.Random.Range(canvas.transform.GetComponent<CollectCanvas2>().minY, canvas.transform.GetComponent<CollectCanvas2>().maxY),
                    0
                );
                x = pomme.transform.localPosition.x;
                y = pomme.transform.localPosition.y;
            }
        }
    }

    IEnumerator wait(int secondes)
    {
        yield return new WaitForSeconds(secondes);
    }
}
