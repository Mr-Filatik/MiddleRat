using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VibroController : MonoBehaviour
{
    public Sprite onVibro;
    public Sprite offVibro;

    public Image VibroButton;
    public bool isOn;
    public AudioSource add;



    void Start()
    {
        isOn = true;
    }

    void Update()
    {
        if (PlayerPrefs.GetInt("vibro") == 0)
        {
            VibroButton.GetComponent<Image>().sprite = onVibro;
            VibroButton.transform.localPosition = new Vector3(56f, 0f, 0f);
            add.enabled = true;
            isOn = true;
        }
        else if(PlayerPrefs.GetInt("vibro") == 1)
        {
            VibroButton.GetComponent<Image>().sprite = offVibro;
            VibroButton.transform.localPosition = new Vector3(-56f, 0f, 0f);
            add.enabled = false;
            isOn = false;
        }
    }

    public void OffVibro()
    {
        if(!isOn)
        {
            PlayerPrefs.SetInt("vibro", 0);

        }
        else if (isOn)
        {
            PlayerPrefs.SetInt("vibro", 1);

        }
    }
}