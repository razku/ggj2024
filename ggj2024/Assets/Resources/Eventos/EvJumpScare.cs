using System;
using UnityEngine;
using UnityEngine.UI;
public class EvJumpScare : MonoBehaviour, IEvBase
{
    public float _timer = 3.5f;
    public float timer {
        get => _timer;
        set => _timer = value;
    }
    public string id => "Surprise!!!";
    public float time;
    public float ticker = 0.0f;
    public GameObject canvasref;
    GameObject canvas;
    public AudioClip[] audioFiles;
    public Texture2D[] allImages;
    bool shown = false;
    public void ev_end()
    {
        Destroy(canvas);
    }
    public static T pick<T>(T[] list)
    {
        if (list == null || list.Length == 0)
        {
            throw new ArgumentException("The list is empty or null.");
        }

        int randomIndex = UnityEngine.Random.Range(0,list.Length);
        return list[randomIndex];
    }
    public bool ev_loop()
    {
        ticker += Time.deltaTime;
        if (ticker >= time && !shown) {
            ShowImage(pick<Texture2D>(allImages),pick<AudioClip>(audioFiles));
            shown = true;
        }
        return false;
    }

    public void ev_start()
    {
        ticker = 0.0f;
        shown = false;
        if (!canvas) {
            canvas = Instantiate(canvasref);
        }

    }

    void Start()
    {
        audioFiles = Resources.LoadAll<AudioClip>("audioxd");
        foreach (AudioClip audioClip in audioFiles)
        {
            Debug.Log("Loaded audio file: " + audioClip.name);
        }
        allImages = Resources.LoadAll<Texture2D>("Cursed");

        foreach (Texture2D image in allImages)
        {
            Debug.Log("Loaded image: " + image.name);
        }
    }

    void ShowImage(Texture2D e, AudioClip a){
        JumpScareLogic x = canvas.GetComponentInChildren<JumpScareLogic>();
        x.load(e, a);
    }

}
