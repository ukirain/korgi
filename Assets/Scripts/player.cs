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


    public GameObject eventMessage;
    public GameObject map;
    public GameObject UICanvas;
    public GameObject battle;
    public GameObject BlizzardMessage;
    
    private Dog dogs;
    public int start_tile_x=0, start_tile_y=0;
    public int cur_tile_x, cur_tile_y;


    private int id;
    private Dog dog;
    private SceneManager sc;

    // Start is called before the first frame update
    void Start()
    {
        id = PlayerPrefs.GetInt("id");
        LoadDogSkins(id);
        
        this.GetComponent<SpriteRenderer>().sprite = dog.face;
        Debug.Log("Assets\\Images\\dog" + id + "\\face.png");

        cur_tile_y = start_tile_y;
        cur_tile_x = start_tile_x;
        this.transform.position = new Vector3(map.GetComponent<map_generator>().tiles[start_tile_x, start_tile_y].transform.position.x,
                                              map.GetComponent<map_generator>().tiles[start_tile_x, start_tile_y].transform.position.y,
                                              (float)(map.GetComponent<map_generator>().tiles[start_tile_x, start_tile_y].transform.position.z + 0.1));

    }

    // Update is called once per frame
    void Update()
    {
        if (eventMessage.active == false && battle.active == false && BlizzardMessage.active == false)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                if (cur_tile_y < 20 && map.GetComponent<map_generator>().map_id[cur_tile_x, cur_tile_y + 1] != 1)
                {
                    this.GetComponent<SpriteRenderer>().sprite = dog.ass;
                    cur_tile_y++;
                }
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                if (cur_tile_x > 0 && map.GetComponent<map_generator>().map_id[cur_tile_x - 1, cur_tile_y] != 1)
                {
                    this.GetComponent<SpriteRenderer>().sprite = dog.leftSide;
                    cur_tile_x--;
                }
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                if (cur_tile_y > 0 && map.GetComponent<map_generator>().map_id[cur_tile_x, cur_tile_y - 1] != 1)
                {
                    this.GetComponent<SpriteRenderer>().sprite = dog.face;
                    cur_tile_y--;
                }
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                if (cur_tile_x < 20 && map.GetComponent<map_generator>().map_id[cur_tile_x + 1, cur_tile_y] != 1)
                {
                    this.GetComponent<SpriteRenderer>().sprite = dog.rightSide;
                    cur_tile_x++;
                }
            }
            
        }
        this.transform.position = new Vector3(map.GetComponent<map_generator>().tiles[cur_tile_x, cur_tile_y].transform.position.x,
                                             map.GetComponent<map_generator>().tiles[cur_tile_x, cur_tile_y].transform.position.y,
                                             (float)(map.GetComponent<map_generator>().tiles[cur_tile_x, cur_tile_y].transform.position.z - 0.1));
       
       
        
       
    }

  

    private void LoadDogSkins(int id)
    {
        dog.face = Resources.Load<Sprite>("Images/dog" + id + "/face");
        dog.ass = Resources.Load<Sprite>("Images/dog" + id + "/ass");
        dog.leftSide = Resources.Load<Sprite>("Images/dog" + id + "/left");
        dog.rightSide = Resources.Load<Sprite>("Images/dog" + id + "/right");
    }
}
