using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

    public static SceneController sc;
    public static AudioSource audioSource;
    public static int f;

    private void Awake()
    {
        if (sc != null)
        {
            Destroy(sc);
        }
        else {
            sc = this;
        }
        DontDestroyOnLoad(this);
    }

    void Start () {

        audioSource = GameObject.Find("EffectAudio").GetComponent<AudioSource>();
        //PlayExplosionAudio();
    }


    public static void ChangeScene(string sceneName) {

        SceneManager.LoadScene(sceneName);
    }

    public static void PlayExplosionAudio()
    {
        audioSource.Play();
    }
}
