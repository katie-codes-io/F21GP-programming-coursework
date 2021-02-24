using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    //=========================================================//
    // Declare private variables
    private GameObject[] swarms;
    private GameObject[] plots;

    //=========================================================//
    // Declare lifecycle methods
    void Awake() {
        swarms = GameObject.FindGameObjectsWithTag("Swarm");
        plots  = GameObject.FindGameObjectsWithTag("Sunflower Plot");
    }

    //=========================================================//
    // Declare public methods
    public void GameOverScreen() {

        // Calculate and set score
        SetScore();

        // Show Game Over scene
        SceneManager.LoadScene("GameOver");

    }

    //=========================================================//
    // Declare private methods
    private void SetScore() {

        // Get number of surviving plants
        int sunflowers = GameObject.FindGameObjectsWithTag("Sunflower").Length;

        // Get the active scene
        Scene scene = SceneManager.GetActiveScene();

        // Set the plant score for the scene
        PlayerStats.SetPlants(sunflowers);

        // Set the gold score for level
        SetGoldScore();
    }

    private void SetGoldScore() {

        // Calculate the max bug score
        int bugCount = 0;
        foreach (GameObject swarm in swarms) {
            bugCount += swarm.GetComponent<Swarm>().count;
        }
        int bugMax = bugCount * PlayerStats.GetBugScore();

        // Count the max plant score
        int plantCount = 9 * plots.Length;
        int plantMax = plantCount * PlayerStats.GetPlantScore();

        // Set the gold score
        int goldScore = (plantMax + bugMax)/2;
        PlayerStats.SetGoldScore(goldScore);
    }
}
