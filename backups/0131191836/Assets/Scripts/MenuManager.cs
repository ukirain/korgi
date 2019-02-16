using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject gamename;
    public GameObject start;
    public GameObject exit;
    public GameObject creditsbutton;
    public GameObject backCredits;
    public GameObject Credit;
    private SceneManager sc;
    AsyncOperation asyncOperation;
    // Use this for initialization
    public void Start()
    {
        asyncOperation = SceneManager.LoadSceneAsync("ChoiceScene");
        asyncOperation.allowSceneActivation = false;
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Menu"));
        start.GetComponent<Button>().onClick.AddListener(LaunchGame);
        exit.GetComponent<Button>().onClick.AddListener(Quit);
        creditsbutton.GetComponent<Button>().onClick.AddListener(ShowCredits);
        backCredits.GetComponent<Button>().onClick.AddListener(CloseCredits);
    }
    public void ShowCredits()
    {
        gamename.SetActive(false);
        Credit.SetActive(true);
        backCredits.SetActive(true);
        start.SetActive(false);
        exit.SetActive(false);
        creditsbutton.SetActive(false);
    }
    public void CloseCredits()
    {
        gamename.SetActive(true);
        Credit.SetActive(false);
        backCredits.SetActive(false);
        start.SetActive(true);
        exit.SetActive(true);
        creditsbutton.SetActive(true);
    }

    public void Quit()
    {
        //Debug.Log("exit pressed");
        Application.Quit();
    }

    public void LaunchGame()
    {
        SceneManager.LoadScene("ChoiceScene", LoadSceneMode.Single);
    }
    void Update()
    {

    }
}
