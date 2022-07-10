using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    public string nextScene;

    public string currentScene;

    public float lastUpdate;

    public static int text_indice = 0;
    public static bool flag = false;

    // Start is called before the first frame update
    void Start()
    {
        if (!flag)
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
            flag = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    public void NextScene()
    {
        SceneManager.LoadScene(nextScene);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {

        currentScene = scene.name;
    }
}