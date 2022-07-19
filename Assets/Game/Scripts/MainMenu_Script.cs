using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_Script : MonoBehaviour
{
    public void playGame() {
        Debug.Log(111);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
