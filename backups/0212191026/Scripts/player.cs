using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//using UnityEngine.Experimental.UIElements;

public class player : MonoBehaviour
{
    struct Dog
    {
        public Sprite ass;
        public Sprite face;
        public Sprite leftSide;
        public Sprite rightSide;
    }

    public GameObject map;
    public GameObject eventMessage;
    public GameObject battle;
    public GameObject UICanvas;
    public GameObject UISettings;
    public GameObject BlizzardMessage;

    public Button buttonEMYes;
    public Button buttonEMNo;
    private Dog dogs;
    private int countSkins = 4;
    /*public Sprite ass;
    public Sprite litso;
    public Sprite pravo;
    public Sprite levo;
    public Sprite ass1;
    public Sprite litso1;
    public Sprite pravo1;
    public Sprite levo1;
    public Sprite ass2;
    public Sprite litso2;
    public Sprite pravo2;
    public Sprite levo2;
    public Sprite ass3;
    public Sprite litso3;
    public Sprite pravo3;
    public Sprite levo3;*/
    public AudioClip LukeAC;
    public Slider sldr;

    public Text tStrength;
    public Text tDexterity;
    public Text tCute;
    public Battle battle_tile;
    public int start_tile_x=0, start_tile_y=0;
    public int cur_tile_x, cur_tile_y;
    private bool flag_show_event = false;
    private bool flag_hp_once = false;
    public int hp;
    public int hp_turn_count = 0;
    public int strength;
    public int dexterity;
    public int cute;
    public Sprite chihuahua;
    public Sprite hedhehog;
    public Sprite human;
    public AudioSource aSource;
    private int id;
    private Dog dog;
    private SceneManager sc;
    AsyncOperation asyncOperation;

    // Start is called before the first frame update
    void Start()
    {
        asyncOperation = SceneManager.LoadSceneAsync("EndSceneBad");
        asyncOperation.allowSceneActivation = false;
        id = PlayerPrefs.GetInt("id");

        dog.face = Resources.Load<Sprite>("Images/dog" + id + "/face");
        dog.ass = Resources.Load<Sprite>("Images/dog" + id + "/ass");
        dog.leftSide = Resources.Load<Sprite>("Images/dog" + id + "/left");
        dog.rightSide = Resources.Load<Sprite>("Images/dog" + id + "/right");
        this.GetComponent<SpriteRenderer>().sprite = dog.face;
        Debug.Log("Assets\\Images\\dog" + id + "\\face.png");

        cur_tile_y = start_tile_y;
        this.transform.position = new Vector3(map.GetComponent<map_generator>().tiles[start_tile_x, start_tile_y].transform.position.x,
                                              map.GetComponent<map_generator>().tiles[start_tile_x, start_tile_y].transform.position.y,
                                              (float)(map.GetComponent<map_generator>().tiles[start_tile_x, start_tile_y].transform.position.z + 0.1));
        sldr.maxValue = PlayerPrefs.GetInt("hp");
        hp = PlayerPrefs.GetInt("hp");
        strength = PlayerPrefs.GetInt("strength");
        dexterity = PlayerPrefs.GetInt("dexterity");
        cute = PlayerPrefs.GetInt("cute");
    }

    // Update is called once per frame
    void Update()
    {
        UIHandler();
        if (eventMessage.active == false && battle.active == false && BlizzardMessage.active == false)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                if (cur_tile_y < 20 && map.GetComponent<map_generator>().map_id[cur_tile_x, cur_tile_y + 1] != 1)
                {
                    this.GetComponent<SpriteRenderer>().sprite = dog.ass;
                    cur_tile_y++;
                    flag_show_event = false;
                    flag_hp_once = false;
                    hp_turn_count--;
                }
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                if (cur_tile_x > 0 && map.GetComponent<map_generator>().map_id[cur_tile_x - 1, cur_tile_y] != 1)
                {
                    this.GetComponent<SpriteRenderer>().sprite = dog.leftSide;
                    cur_tile_x--;
                    flag_show_event = false;
                    flag_hp_once = false;
                    hp_turn_count--;
                }
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                if (cur_tile_y > 0 && map.GetComponent<map_generator>().map_id[cur_tile_x, cur_tile_y - 1] != 1)
                {
                    this.GetComponent<SpriteRenderer>().sprite = dog.face;
                    cur_tile_y--;
                    flag_show_event = false;
                    flag_hp_once = false;
                    hp_turn_count--;
                }
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                if (cur_tile_x < 20 && map.GetComponent<map_generator>().map_id[cur_tile_x + 1, cur_tile_y] != 1)
                {
                    this.GetComponent<SpriteRenderer>().sprite = dog.rightSide;
                    cur_tile_x++;
                    flag_show_event = false;
                    flag_hp_once = false;
                    hp_turn_count--;
                }
            }
            
        }
        this.transform.position = new Vector3(map.GetComponent<map_generator>().tiles[cur_tile_x, cur_tile_y].transform.position.x,
                                             map.GetComponent<map_generator>().tiles[cur_tile_x, cur_tile_y].transform.position.y,
                                             (float)(map.GetComponent<map_generator>().tiles[cur_tile_x, cur_tile_y].transform.position.z - 0.1));
        if (flag_show_event == false && (map.GetComponent<map_generator>().map_id[cur_tile_x, cur_tile_y] == 2)) // human
            //blizzard & battle event
        {
            flag_show_event = true;
            eventMessage.SetActive(true);
            eventMessage.GetComponentInChildren<Image>().sprite = human;
            eventMessage.GetComponentInChildren<Text>().text = "You see a strange man at the blizzard.";
            battle_tile.selectOpponent(0);
        }
        if (flag_show_event == false && (map.GetComponent<map_generator>().map_id[cur_tile_x, cur_tile_y] == 3)) // hedhgehog
        {
            flag_show_event = true;
            eventMessage.SetActive(true);
            eventMessage.GetComponentInChildren<Image>().sprite = hedhehog;
            eventMessage.GetComponentInChildren<Text>().text = "It's quite fast hedgehog. It can be dangerous.";
            battle_tile.selectOpponent(1);
        }
        if (flag_show_event == false && (map.GetComponent<map_generator>().map_id[cur_tile_x, cur_tile_y] == 6)) // chihuahua
        {
            flag_show_event = true;
            eventMessage.SetActive(true);
            eventMessage.GetComponentInChildren<Image>().sprite = chihuahua;
            eventMessage.GetComponentInChildren<Text>().text = "The cave appeared on your way.";
            battle_tile.selectOpponent(2);
        }
        if (map.GetComponent<map_generator>().map_id[cur_tile_x, cur_tile_y] == 4)//win
        {
            PlayerPrefs.SetInt("finalHP", hp);
            SceneManager.LoadScene("EndSceneGood", LoadSceneMode.Additive);
        }
        if(flag_hp_once == false && map.GetComponent<map_generator>().map_id[cur_tile_x, cur_tile_y] == 0)//free
        {
            flag_hp_once = true;
            //hp -= 5;
            float r = Random.Range(0, 100);
            if (r < 7)
            {
                flag_show_event = true;
                BlizzardMessage.SetActive(true);
                hp -= 20; //GUI
            }
        }
        if (flag_hp_once == false && map.GetComponent<map_generator>().map_id[cur_tile_x, cur_tile_y] == 5)//hp
        {
            flag_hp_once = true;
            if(hp_turn_count <= 0)
            {
                hp_turn_count = 7;
                hp += 30;
                aSource.PlayOneShot(LukeAC);
            }
            if(hp > sldr.maxValue)
            {
                hp = (int)sldr.maxValue;
            }
            
            
        }
        if(hp <= 0)
        {
            PlayerPrefs.SetInt("finalHP", hp);
            asyncOperation.allowSceneActivation = true;
        }
    }

    public void buttonEMNoClick()
    {
        float r = Random.Range(0.0f, 1.0f);
        Debug.Log(r);
        Debug.Log(dexterity);
        eventMessage.SetActive(false);
        if (!(r < (float)dexterity / ((float)dexterity + 5.0f))) { 
           battle.SetActive(true);
        }
    }
    public void buttonEMYesClick()
    {
        eventMessage.SetActive(false);
        if (map.GetComponent<map_generator>().map_id[cur_tile_x, cur_tile_y] == 2|| map.GetComponent<map_generator>().map_id[cur_tile_x, cur_tile_y] == 3 || map.GetComponent<map_generator>().map_id[cur_tile_x, cur_tile_y] == 6)
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
