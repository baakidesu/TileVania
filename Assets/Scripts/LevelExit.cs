using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelExit : MonoBehaviour
{
    [SerializeField] private int levelLoadDelay = 2;
    private GameObject[] numberOfCoins;

    private void Start()
    {
        if (numberOfCoins == null)
        {
            numberOfCoins = GameObject.FindGameObjectsWithTag("Coin");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
          
        //Debug.Log("total coins: " + numberOfCoins.Length + "Your Coins: " + FindObjectOfType<GameSession>().score);
        if (other.tag == "Player" && FindObjectOfType<GameSession>().score == numberOfCoins.Length)
        {
            StartCoroutine(LoadNextLevel());
        }
    }

    IEnumerator LoadNextLevel()
    {
        yield return new WaitForSecondsRealtime(levelLoadDelay);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
 
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }
}
