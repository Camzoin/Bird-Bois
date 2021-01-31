using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    public Animator canvasFadeAnim;
    [SerializeField]
    public Goal currentGoal;

    public static GameManager instance;

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
        if (currentGoal != null)
        {
            if (currentGoal.goalHit)
            {
                canvasFadeAnim.SetTrigger("Fail");
            }
        }
    }

    public void LoadScene(string sceneName)
    {
        RenderSettings.skybox.SetFloat("_Blend", 0);
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
