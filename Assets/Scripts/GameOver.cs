using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOverScreen() {
        // Calculate and set score
        SetScore();

        // Show Game Over scene
        SceneManager.LoadScene("GameOver");

    }

    void SetScore() {

        // Get number of surviving plants
        int sunflowers = GameObject.FindGameObjectsWithTag("Sunflower").Length;

        // Get the active scene
        Scene scene = SceneManager.GetActiveScene();

        // Set the score for the scene
        PlayerStats.SetScore(sunflowers);

        // Set the max possible score for the scene
        if (scene.name == "Level1") {
            PlayerStats.SetMaxPossible(9);

        } else if (scene.name == "Level2") {
            PlayerStats.SetMaxPossible(18);

        }

        Debug.Log(PlayerStats.GetMaxPossible());
    }
}
