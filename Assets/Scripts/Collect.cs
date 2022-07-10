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
            pomme.transform.localPosition = new Vector3(
                UnityEngine.Random.Range(canvas.transform.GetComponent<CollectCanvas>().minX + size, canvas.transform.GetComponent<CollectCanvas>().maxX - size),
                UnityEngine.Random.Range(canvas.transform.GetComponent<CollectCanvas>().minY + size, canvas.transform.GetComponent<CollectCanvas>().maxY - size),
                0
            );
            float x = pomme.transform.localPosition.x;
            float y = pomme.transform.localPosition.y;
        }
    }

    IEnumerator wait(int secondes)
    {
        yield return new WaitForSeconds(secondes);
    }
}
