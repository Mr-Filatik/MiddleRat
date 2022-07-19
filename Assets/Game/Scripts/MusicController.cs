using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicController : MonoBehaviour
{
    public Sprite onMusic;
    public Sprite offMusic;

    public Image MusicButton;
    public bool isOn;
    public AudioSource add;



    void Start()
    {
        isOn = true;
    }

    void Update()
    {
        if (PlayerPrefs.GetInt("music") == 0)
        {
            MusicButton.GetComponent<Image>().sprite = onMusic;
            MusicButton.transform.localPosition = new Vector3(56f, 0f, 0f);
            add.enabled = true;
            isOn = true;
        }
        else if(PlayerPrefs.GetInt("music") == 1)
        {
            MusicButton.GetComponent<Image>().sprite = offMusic;
            MusicButton.transform.localPosition = new Vector3(-56f, 0f, 0f);
            add.enabled = false;
            isOn = false;
        }
    }

    public void OffMusic()
    {
        if(!isOn)
        {
            PlayerPrefs.SetInt("music", 0);

        }
        else if (isOn)
        {
            PlayerPrefs.SetInt("music", 1);

        }
    }
}
