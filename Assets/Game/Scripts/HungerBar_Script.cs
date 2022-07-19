using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HungerBar_Script : MonoBehaviour
{
    public Image speedBar;
    public Image color1;
    public Image color2;
    public Image color3;

    // Start is called before the first frame update
    void Start()
    {
        speedBar = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        color1.fillAmount = speedBar.fillAmount*3;
        if (color1.fillAmount == 1) color2.fillAmount = speedBar.fillAmount*3 - color1.fillAmount;
        else color2.fillAmount = 0;
        if (color2.fillAmount == 1) color3.fillAmount = speedBar.fillAmount*3 - color2.fillAmount - color1.fillAmount;
        else color3.fillAmount = 0;
    }
}