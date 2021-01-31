using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public string[] sceneNames;

    public static GameManager instance;
    Goal currentGoal;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        if (instance == null)
            instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentGoal.goalHit)
        {

        }
    }

    public void LoadScene(string sceneName)
    {
        RenderSettings.skybox.SetFloat("_Blend", 0);
        SceneManager.LoadScene(sceneName);
    }
}
