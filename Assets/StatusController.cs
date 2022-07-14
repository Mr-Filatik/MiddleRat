using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatusController : MonoBehaviour
{
    [SerializeField] private static float satietyStat;
    [SerializeField] private static float poisonStat;
    [SerializeField] private float satietySpeed;
    [SerializeField] private float speed = 5;
    [SerializeField] private static float movementSpeed = 5;
    [SerializeField] private float poisoningDeviationSpeed;
    [SerializeField] private TMP_Text satietyText;
    [SerializeField] private TMP_Text poisonText;

    public bool isFinish;
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
        

        if (poisonStat < 100) poisonStat += poison;

        if (poisonStat > 5) poisonStat = 5;
        if (poisonStat < 0) poisonStat = 0;
    }
    public void SatietyReduction()
    {
        if(satietyStat > 66)
        {
            movementSpeed = speed * (1-(satietyStat / 100)) * 3;
            if (movementSpeed < 1) movementSpeed = 1;
        }
        else if (satietyStat < 33)
        {
            movementSpeed = speed * satietyStat/100 * 3;
        }
        else movementSpeed = speed; //���������������

        if (satietyStat > 0)
        {
            satietyStat -= satietySpeed * Time.deltaTime;
        }
        if (satietyStat < 0) satietyStat = 0;
    }
    /*public void PoisoningReduction()
    {
        poisoningDeviationSpeed = poisonStat;

        if (poisonStat > 0)
        {
            poisonStat -= 1 * Time.deltaTime;
        }
        if (poisonStat < 0) poisonStat = 0;
    } */
    public void GameOver()
    {
        if (movementSpeed <= 0) isAlive = false;
    }
    // Start is called before the first frame update
    public void StartGame()
    {
        satietyStat = 50;
    }
    public static float getEat()
    {
        return satietyStat;
    }
    public static float getSpeed()
    {
        return movementSpeed;
    }
    public static float getPoisoning()
    {
        return poisonStat;
    }
    public void gameFinish()
    {
        if (isFinish)
        {
            Debug.Log("game finished");
        }
        else Debug.Log("game playing");
    }
    void Start()
    {
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        SatietyReduction();
        gameFinish();
        poisonText.text = poisonStat.ToString();
        satietyText.text = satietyStat.ToString();
    }
}
