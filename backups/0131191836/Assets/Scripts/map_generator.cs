using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class map_generator : MonoBehaviour
{
    public GameObject free_tile; //0
    public GameObject wall;// 1
    public GameObject human_tile;//2
    public GameObject hedhehog_tile;//3
    public GameObject win_tile;//4
    public GameObject hp_tile;//5
    public GameObject chihuahua_tile;//6
    public Sprite house1;
    public Sprite house2;
    public Sprite budka;
    public Sprite hedgehog;
    public Sprite human;
    public Sprite blizzard;
    public Sprite hp_road;
    public Sprite road_empty;
    public Sprite road_left_right;
    public Sprite road_up_down;
    public Sprite win_home;
    public float X_start = (float)-3.5, Y_start = (float)-3.5;
    private int size = 21;
    public GameObject[,] tiles = new GameObject[21,21]; 
    public int[,] map_id = new int [21,21] { { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 ,1 },
                                             { 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 2, 0, 0, 1, 0, 0, 0, 0, 0, 1 },
                                             { 1, 0, 1, 0, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 5, 1, 1, 1 },
                                             { 1, 0, 1, 0, 1, 0, 1, 0, 0, 5, 1, 5, 0, 0, 0, 0, 1, 0, 0, 0, 1 },
                                             { 1, 5, 1, 0, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 0, 1 },
                                             { 1, 0, 1, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 5, 1, 0, 0, 0, 0, 0, 1 },
                                             { 1, 0, 1, 0, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1 },
                                             { 1, 0, 1, 0, 1, 0, 1, 0, 0, 0, 5, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1 },
                                             { 1, 2, 1, 0, 1, 0, 1, 0, 1, 1, 1, 1, 1, 1, 1, 0, 1, 0, 1, 1, 1 },
                                             { 1, 0, 1, 0, 1, 5, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1 },
                                             { 1, 0, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1 },
                                             { 1, 0, 1, 0, 0, 0, 0, 5, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1 },
                                             { 1, 0, 1, 1, 1, 0, 1, 1, 1, 1, 1, 2, 1, 1, 1, 1, 1, 0, 1, 0, 1 },
                                             { 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 5, 3, 1, 5, 1, 5, 1 },
                                             { 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 1, 0, 1, 5, 1, 1, 1, 0, 1 },
                                             { 1, 0, 0, 0, 0, 5, 1, 0, 1, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 1 },
                                             { 1, 6, 1, 1, 1, 1, 1, 0, 1, 0, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1 },
                                             { 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 5, 1, 0, 1, 0, 0, 0, 0, 0, 1 },
                                             { 1, 1, 1, 0, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 1, 0, 1, 1, 1, 5, 1 },
                                             { 1, 4, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 1, 0, 0, 0, 1 },
                                             { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }}; // <---- сюда
    // Start is called before the first frame update
    void Awake()
    {
        for (int i = 0; i < size; i++)
            for (int j = 0; j < size; j++) {
                if(map_id[i,j] == 0)
                {
                    tiles[i,j] = Instantiate(free_tile,new Vector3((float)(X_start + (0.3 * i)), (float)(Y_start +  (0.3 * j)), 0),Quaternion.identity);

                    tiles[i, j].transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);
                }
                if (map_id[i, j] == 1)
                {
                    tiles[i, j] = Instantiate(wall, new Vector3((float)(X_start + (0.3 * i)), (float)(Y_start + (0.3 * j)), 0), Quaternion.identity);
                    int r = Random.Range(0, 2);
                    if(r == 0)
                       tiles[i, j].GetComponent<SpriteRenderer>().sprite = house1;
                    else
                        tiles[i, j].GetComponent<SpriteRenderer>().sprite = house2;

                    tiles[i, j].transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);
                }
                if (map_id[i, j] == 2)
                {
                    tiles[i, j] = Instantiate(human_tile, new Vector3((float)(X_start + (0.3 * i)), (float)(Y_start + (0.3 * j)), 0), Quaternion.identity);
                    tiles[i, j].GetComponent<SpriteRenderer>().sprite = human;
                    tiles[i, j].GetComponent<SpriteRenderer>().sortingOrder = 1;

                    tiles[i, j].transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                }
                if (map_id[i, j] == 3)
                {
                    tiles[i, j] = Instantiate(hedhehog_tile, new Vector3((float)(X_start + (0.3 * i)), (float)(Y_start + (0.3 * j)), 0), Quaternion.identity);
                    tiles[i, j].GetComponent<SpriteRenderer>().sprite = hedgehog;
                    tiles[i, j].GetComponent<SpriteRenderer>().sortingOrder = 1;

                    tiles[i, j].transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                }
                if (map_id[i, j] == 4)
                {
                    tiles[i, j] = Instantiate(win_tile, new Vector3((float)(X_start + (0.3 * i)), (float)(Y_start + (0.3 * j)), 0), Quaternion.identity);
                    tiles[i, j].GetComponent<SpriteRenderer>().sprite = win_home;

                    tiles[i, j].transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);
                }
                if (map_id[i, j] == 5)
                {
                    tiles[i, j] = Instantiate(hp_tile, new Vector3((float)(X_start + (0.3 * i)), (float)(Y_start + (0.3 * j)), 0), Quaternion.identity);
                    tiles[i, j].GetComponent<SpriteRenderer>().sprite = hp_road;
                    tiles[i, j].transform.localScale = new Vector3(0.075f, 0.1f, 0.1f);
                }
                if (map_id[i, j] == 6)
                {
                    tiles[i, j] = Instantiate(chihuahua_tile, new Vector3((float)(X_start + (0.3 * i)), (float)(Y_start + (0.3 * j)), 0), Quaternion.identity);
                    tiles[i, j].GetComponent<SpriteRenderer>().sprite = budka;

                    tiles[i, j].transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);
                }
                if (i == 0 || j == 0 || i == 20 || j == 20)
                {
                    tiles[i, j].GetComponent<SpriteRenderer>().sprite = blizzard;

                    tiles[i, j].transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);
                }
            }
        for(int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                if (map_id[i, j] == 0)
                {
                    if (i >= 1 && i <= 19 && map_id[i - 1, j] == 0 && map_id[i + 1, j] == 0)
                    {
                        tiles[i, j].GetComponent<SpriteRenderer>().sprite = road_up_down;
                        continue;
                    }
                    else if (j >= 1 && j <= 19 && map_id[i, j + 1] == 0 && map_id[i, j - 1] == 0)
                    {
                        tiles[i, j].GetComponent<SpriteRenderer>().sprite = road_left_right;
                        continue;
                    }
                    tiles[i, j].GetComponent<SpriteRenderer>().sprite = road_empty;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
