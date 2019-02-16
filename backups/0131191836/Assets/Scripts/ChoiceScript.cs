using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChoiceScript : MonoBehaviour
{
    // Start is called before the first frame update
    AsyncOperation asyncOperation;
    int hp;
    int strength;
    int dexterity;
    int cute;
    public Image selectedTimmy;
    public Image selectedMia;
    public Image selectedJack;
    public Image selectedSandra;
    // Use this for initialization
    public void Start()
    {
        clickTimmy();
        asyncOperation = SceneManager.LoadSceneAsync("Global_Map");
        asyncOperation.allowSceneActivation = false;
        
    }
    public void LaunchGame()
    {
        PlayerPrefs.SetInt("hp", hp);
        PlayerPrefs.SetInt("cute", cute);
        PlayerPrefs.SetInt("strength", strength);
        PlayerPrefs.SetInt("dexterity", dexterity);
        PlayerPrefs.Save();

        asyncOperation.allowSceneActivation = true;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void clickTimmy()
    {
        unselectCharacter();
        selectedTimmy.gameObject.SetActive(true);
        hp = 100;
        cute = 2;
        strength = 2;
        dexterity = 2;
        PlayerPrefs.SetInt("id", 0);
        PlayerPrefs.Save();
    }

    public void clickJack()
    {
        unselectCharacter();
        selectedJack.gameObject.SetActive(true);
        hp = 120;
        cute = 1;
        strength = 4;
        dexterity = 1;
        PlayerPrefs.SetInt("id", 2);
        PlayerPrefs.Save();
    }

    public void clickMia()
    {
        unselectCharacter();
        selectedMia.gameObject.SetActive(true);
        hp = 80;
        cute = 4;
        strength = 1;
        dexterity = 1;
        PlayerPrefs.SetInt("id", 1);
        PlayerPrefs.Save();
    }

    public void clickSandra()
    {
        unselectCharacter();
        selectedSandra.gameObject.SetActive(true);
        hp = 80;
        dexterity = 4;
        strength = 1;
        cute = 1;
        PlayerPrefs.SetInt("id", 3);
        PlayerPrefs.Save();
    }

    public void unselectCharacter()
    {
        selectedTimmy.gameObject.SetActive(false);
        selectedMia.gameObject.SetActive(false);
        selectedJack.gameObject.SetActive(false);
        selectedSandra.gameObject.SetActive(false);

    }
}
