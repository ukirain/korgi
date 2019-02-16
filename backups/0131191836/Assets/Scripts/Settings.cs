using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
    AsyncOperation asyncOperation;
    // Start is called before the first frame update
    void Awake()
    {
        asyncOperation = SceneManager.LoadSceneAsync("Menu");
        asyncOperation.allowSceneActivation = false;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void ExitGame()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Additive);
    }
}
