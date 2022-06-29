using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatusController : MonoBehaviour
{
    [SerializeField] private float satietyStat;
    [SerializeField] private float poisonStat;
    [SerializeField] private float satietySpeed;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float poisoningDeviationSpeed;
    [SerializeField] private TMP_Text text1;
    public bool isAlive;
    public void Eating(float eat)
    {
        if (eat < 0)
            throw new ArgumentOutOfRangeException(nameof(eat));
        
        if (satietyStat < 100) satietyStat += eat;

        if (satietyStat > 100) satietyStat = 100;

    }
    public void Poisoning(float poison)
    {
        if (poison < 0)
            throw new ArgumentOutOfRangeException(nameof(poison));

        if (poisonStat < 100) poisonStat += poison;

        if (poisonStat > 100) poisonStat = 100;

    }
    public void SatietyReduction()
    {
        movementSpeed = satietyStat; //скорректировать

        if (satietyStat > 0)
        {
            satietyStat -= satietySpeed * Time.deltaTime;
        }
        if (satietyStat < 0) satietyStat = 0;
    }
    public void PoisoningReduction()
    {
        poisoningDeviationSpeed = poisonStat;

        if (poisonStat > 0)
        {
            poisonStat -= 1 * Time.deltaTime;
        }
        if (poisonStat < 0) poisonStat = 0;
    }
    public void GameOver()
    {
        if (movementSpeed <= 0) isAlive = false;
    }
    // Start is called before the first frame update
    public void StartGame()
    {
        satietyStat = 100;
    }

    // Update is called once per frame
    void Update()
    {
        SatietyReduction();
        PoisoningReduction();
        text1.text = "q";
    }
}
