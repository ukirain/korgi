using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Battle : MonoBehaviour
{
    public GameObject battle;
    public GameObject win;
    public Button pushButton;
    public Button biteButton;
    public Button barkButton;
    public Button runButton;
    public Slider sldrOur;
    public Slider sldrOpp;
    public Text log;
    public Text battleEnd;
    public player pl;
    private Random rnd;
    public Sprite human;
    public Sprite chihuahua;
    public Sprite hedgehog;
    public GameObject opponent_image;
    public AudioClip BiteAC;
    public AudioClip BarkAC;
    public AudioClip PushAC;
    public AudioClip RunAwayAC;
    public AudioSource AudioEffects;
    string buff = "";
    int bleed = 0;
    string oppbuff = "";
    int oppbleed = 0;
    int plsleep = 0;
    bool lose = false;
    int pushCount = 0;
    int biteCount = 0;
    int barkCount = 0;
    struct opponent
    {
        public int hp;
        public int strength;
        public int dexterity;
        public int cute;
        public int sleep;
    }
    opponent opp;
    // Start is called before the first frame update
    void Start()
    {
        opp.hp = 100;
        sldrOpp.value = opp.hp;
    }

    // Update is called once per frame
    void Update()
    {
        sldrOur.value = pl.hp;
        if(opp.hp <= 0)
        {
            Debug.Log("You win!");
            battle.SetActive(false);
            win.SetActive(true);
            battleEnd.text = "You win!";
            opp.hp = 1;
        } else if(pl.hp <= 0)
        {
            Debug.Log("You lose!");
            battle.SetActive(false);
            win.SetActive(true);
            battleEnd.text = "You lose!";
            pl.hp = 1;
            lose = true;
        }
        sldrOpp.value = Mathf.MoveTowards(opp.hp, sldrOpp.value, 1.0f * Time.deltaTime);
    }

    public void clickPushButton()
    {
        float r = Random.Range(0.0f, 1.0f);
        Debug.Log(r);
        Debug.Log(pl.dexterity);
        if (r < (float)pl.dexterity / ((float)pl.dexterity + (float)opp.dexterity))
        {
            opp.hp -= pl.strength * 10;
            log.text = "You punched the opponent! -" + pl.strength * 10 + " He has " + opp.hp + " hp." + "\n" + buff;
            float temp = 0.0f;
            AudioEffects.PlayOneShot(PushAC);
        }
        else
        {
            log.text = "Miss!"; 
        }
        pushCount++;
        Round();
    }
    public void clickBiteButton()
    {
        float r = Random.Range(0.0f, 1.0f);
        Debug.Log(r);
        Debug.Log(pl.dexterity);
        if (r < (float)pl.dexterity / ((float)pl.dexterity + (float)opp.dexterity))
        {
            bleed += pl.dexterity * 5;
            log.text = "You bited the opponent! He's bleeding." + "\n" + buff;
            float temp = 0.0f;
            AudioEffects.PlayOneShot(BiteAC);
        }
        else
        {
            log.text = "Miss!";
        }
        biteCount++;
        Round();
    }
    public void clickBarkButton()
    {
        float r = Random.Range(0.0f, 1.0f);
        Debug.Log(r);
        Debug.Log(pl.dexterity);
        if (r < (float)pl.cute / ((float)pl.cute + (float)opp.cute))
        {
            opp.sleep = 2;
            AudioEffects.PlayOneShot(BarkAC);
        }
        else
        {
            log.text = "Miss!";
        }
        barkCount++;
        Round();
    }
    public void clickRunButton()
    {
        float r = Random.Range(0.0f, 1.0f);
        Debug.Log(r);
        Debug.Log(pl.dexterity);
        if (r < (float)pl.dexterity / ((float)pl.dexterity + (float)opp.dexterity))
        {
            battle.SetActive(false);
            win.SetActive(true);
            battleEnd.text = "You ran away!";
            opp.hp = 1;
            AudioEffects.PlayOneShot(RunAwayAC);
        }
        else
        {
            log.text = "You didn't run away!";
        }
        Round();
    }

    public void oppPushButton()
    {
        float r = Random.Range(0.0f, 1.0f);
        Debug.Log(r);
        Debug.Log(opp.dexterity);
        if (r < (float)opp.dexterity / ((float)opp.dexterity + (float)pl.dexterity) + opp.sleep + 2)
        {
            pl.hp -= opp.strength * 10;
            log.text += "\nThe opponent punch you! -" + opp.strength * 10 + " You have " + pl.hp + " hp." + "\n" + buff;
            float temp = 0.0f;

        }
        else
        {
            log.text += "\nThe opponent miss!";
        }
    }
    public void oppBiteButton()
    {
        float r = Random.Range(0.0f, 1.0f);
        Debug.Log(r);
        Debug.Log(opp.dexterity);
        if (r < (float)opp.dexterity / ((float)opp.dexterity + (float)pl.dexterity))
        {
            oppbleed += opp.dexterity * 5;
            log.text += "\nThe opponent bited you! You're bleeding." + "\n" + oppbuff;
            float temp = 0.0f;

        }
        else
        {
            log.text += "\nThe opponent miss!";
        }
    }
    public void oppBarkButton()
    {
        float r = Random.Range(0.0f, 1.0f);
        Debug.Log(r);
        Debug.Log(opp.dexterity);
        if (r < (float)opp.cute / ((float)opp.cute + (float)pl.cute))
        {
            plsleep = 2;
        }
        else
        {
            log.text += "\nThe opponent miss!";
        }
    }
   

    void Round()
    {
        if (opp.sleep > 0) {
            opp.sleep--;
            log.text += "\nYour opponent is stunned";
        }
        else
        {
            turnOpp();
        }
        opp.hp -= bleed;
        if(bleed > 0)
        {
            bleed -= pl.dexterity;
            buff = "Your opponent took " + bleed + " damage from bleeding";
        } else
        {
            buff = "";
        }

        pl.hp -= oppbleed;
        if (oppbleed > 0)
        {
            oppbleed -= opp.dexterity;
            oppbuff = "You took " + oppbleed + " damage from bleeding";
        }
        else
        {
            buff = "";
        }
    }

    void turnOpp()
    {
        oppPushButton();
    }

    public void selectOpponent(int type)
    {
        switch (type)
        {
            case 0: //human
                opp.hp = 120;
                opp.strength = 7;
                opp.dexterity = 1;
                opp.cute = 0;
                opponent_image.GetComponent<Image>().sprite = human;
                break;
            case 1: //hedgehog
                opp.hp = 100;
                opp.strength = 1;
                opp.dexterity = 7;
                opp.cute = 2;
                opponent_image.GetComponent<Image>().sprite = hedgehog;
                break;
            case 2: //dog
                opp.hp = 80;
                opp.strength = 6;
                opp.dexterity = 5;
                opp.cute = 10;
                 opponent_image.GetComponent<Image>().sprite = chihuahua;
                break;
            default:
                break;
        }
    }

    public void clickOkWin()
    {
        win.SetActive(false);
        if (pl.hp == 1)
        {
            Debug.Log("End");
            SceneManager.LoadScene("EndSceneBad", LoadSceneMode.Additive);
        } else
        {
            int max = Mathf.Max(pushCount, biteCount, barkCount);
            if(max == pushCount)
            {
                pl.strength++;
            } else if(max == biteCount)
            {
                pl.dexterity++;
            } else if(max == barkCount)
            {
                pl.cute++;
            }
        }
    }
}


