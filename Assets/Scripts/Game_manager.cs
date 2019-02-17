using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game_manager : MonoBehaviour
{
    public int hp;
    public int hp_turn_count = 0;
    public int strength;
    public int dexterity;
    public int cute;

    private bool flag_show_event = false;
    private bool flag_hp_once = false;

    public Battle battle_tile;
    public GameObject map;
    public GameObject player;
    public GameObject eventMessage;

    public GameObject battle;
    public GameObject BlizzardMessage;
    public GameObject UISettings;

    public AudioSource aSource;
    public AudioClip LukeAC;

    public Sprite chihuahua;
    public Sprite hedhehog;
    public Sprite human;

    public Slider sldr;

    public Text tStrength;
    public Text tDexterity;
    public Text tCute;

    AsyncOperation asyncOperation;
    // Start is called before the first frame update
    void Start()
    {
        hp = PlayerPrefs.GetInt("hp");
        strength = PlayerPrefs.GetInt("strength");
        dexterity = PlayerPrefs.GetInt("dexterity");
        cute = PlayerPrefs.GetInt("cute");
        asyncOperation = SceneManager.LoadSceneAsync("EndSceneBad");
        asyncOperation.allowSceneActivation = false;
        sldr.maxValue = PlayerPrefs.GetInt("hp");
    }

    // Update is called once per frame
    void Update()
    {
        UIHandler();
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        {
            hp_turn_count--;
            flag_show_event = false;
            flag_hp_once = false;
        }
        if (map.GetComponent<map_generator>().map_id[player.GetComponent<player>().cur_tile_x, player.GetComponent<player>().cur_tile_y] == 4)//win
        {
            PlayerPrefs.SetInt("finalHP", hp);
            SceneManager.LoadScene("EndSceneGood", LoadSceneMode.Additive);
        }
        if (flag_hp_once == false && map.GetComponent<map_generator>().map_id[player.GetComponent<player>().cur_tile_x, player.GetComponent<player>().cur_tile_y] == 5)//hp
        {
            flag_hp_once = true;
            if (hp_turn_count <= 0)
            {
                hp_turn_count = 7;
                hp += 30;
                aSource.PlayOneShot(LukeAC);
            }
            if (hp > sldr.maxValue)
            {
                hp = (int)sldr.maxValue;
            }


        }
        if (hp <= 0)
        {
            PlayerPrefs.SetInt("finalHP", hp);
            asyncOperation.allowSceneActivation = true;
        }
        if (flag_show_event == false && (map.GetComponent<map_generator>().map_id[player.GetComponent<player>().cur_tile_x, player.GetComponent<player>().cur_tile_y] == 2)) // human
                                                                                                                                                                             //blizzard & battle event
        {
            flag_show_event = true;
            eventMessage.SetActive(true);
            eventMessage.GetComponentInChildren<Image>().sprite = human;
            eventMessage.GetComponentInChildren<Text>().text = "You see a strange man at the blizzard.";
            battle_tile.selectOpponent(0);
        }
        if (flag_show_event == false && (map.GetComponent<map_generator>().map_id[player.GetComponent<player>().cur_tile_x, player.GetComponent<player>().cur_tile_y] == 3)) // hedhgehog
        {
            flag_show_event = true;
            eventMessage.SetActive(true);
            eventMessage.GetComponentInChildren<Image>().sprite = hedhehog;
            eventMessage.GetComponentInChildren<Text>().text = "It's quite fast hedgehog. It can be dangerous.";
            battle_tile.selectOpponent(1);
        }
        if (flag_show_event == false && (map.GetComponent<map_generator>().map_id[player.GetComponent<player>().cur_tile_x, player.GetComponent<player>().cur_tile_y] == 6)) // chihuahua
        {
            flag_show_event = true;
            eventMessage.SetActive(true);
            eventMessage.GetComponentInChildren<Image>().sprite = chihuahua;
            eventMessage.GetComponentInChildren<Text>().text = "The cave appeared on your way.";
            battle_tile.selectOpponent(2);
        }
    }

    public void buttonEMNoClick()
    {
        float r = Random.Range(0.0f, 1.0f);
        Debug.Log(r);
        Debug.Log(dexterity);
        eventMessage.SetActive(false);
        if (!(r < (float)dexterity / ((float)dexterity + 5.0f)))
        {
            battle.SetActive(true);
        }
    }

    public void buttonEMYesClick()
    {
        eventMessage.SetActive(false);
        if (map.GetComponent<map_generator>().map_id[player.GetComponent<player>().cur_tile_x, player.GetComponent<player>().cur_tile_y] == 2
            || map.GetComponent<map_generator>().map_id[player.GetComponent<player>().cur_tile_x, player.GetComponent<player>().cur_tile_y] == 3
            || map.GetComponent<map_generator>().map_id[player.GetComponent<player>().cur_tile_x, player.GetComponent<player>().cur_tile_y] == 6)
        {
            battle.SetActive(true);
        }

    }
    public void buttonUISettings()
    {
        UISettings.SetActive(true);
    }

    public void buttonResumeUISettings()
    {
        UISettings.SetActive(false);
    }

    public void buttonBlizzMessageOk()
    {
        BlizzardMessage.SetActive(false);
    }

    public void UIHandler()
    {
        sldr.value = hp;
        tStrength.text = strength.ToString();
        tDexterity.text = dexterity.ToString();
        tCute.text = cute.ToString();
    }
}