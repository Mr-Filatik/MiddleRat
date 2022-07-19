using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    public Sprite onSound;
    public Sprite offSound;

    public Image SoundButton;
    public bool isOn;
    public AudioSource add;



    void Start()
    {
        isOn = true;
    }

    void Update()
    {
        if (PlayerPrefs.GetInt("sound") == 0)
        {
            SoundButton.GetComponent<Image>().sprite = onSound;
            SoundButton.transform.localPosition = new Vector3(56f, 0f, 0f);
            add.enabled = true;
            isOn = true;
        }
        else if(PlayerPrefs.GetInt("sound") == 1)
        {
            SoundButton.GetComponent<Image>().sprite = offSound;
            SoundButton.transform.localPosition = new Vector3(-56f, 0f, 0f);
            add.enabled = false;
            isOn = false;
        }
    }

    public void OffSound()
    {
        if(!isOn)
        {
            PlayerPrefs.SetInt("sound", 0);

        }
        else if (isOn)
        {
            PlayerPrefs.SetInt("sound", 1);

        }
    }
}