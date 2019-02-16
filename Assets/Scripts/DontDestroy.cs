using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Object.DontDestroyOnLoad example.
//
// This script example manages the playing audio. The GameObject with the
// "music" tag is the BackgroundMusic GameObject. The AudioSource has the
// audio attached to the AudioClip.

public class DontDestroy : MonoBehaviour
{
    static GameObject go;
    private void Start()
    {
        go = this.gameObject;
    }

    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("mainMusic");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    public static void OnDestroy()
    {
        GameObject go = GameObject.Find("mainMenuMusic");
        Destroy(go);
    }
}