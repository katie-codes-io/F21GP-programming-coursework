using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    private GameObject[] swarms;
    private GameObject[] plots;

    void Start() {
        swarms = GameObject.FindGameObjectsWithTag("Swarm");
        plots  = GameObject.FindGameObjectsWithTag("Sunflower Plot");
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

        // Set the plant score for the scene
        PlayerStats.SetPlants(sunflowers);

        // Set the maximum score possible for level
        SetMaxScore();
    }

    void SetMaxScore() {

        // Calculate the max bug score
        int bugCount = 0;
        foreach (GameObject swarm in swarms) {
            bugCount += swarm.GetComponent<Swarm>().count;
        }
        int bugMax = bugCount * PlayerStats.GetBugScore();

        // Count the max plant score
        int plantCount = 9 * plots.Length;
        int plantMax = plantCount * PlayerStats.GetPlantScore();

        // Set the max possible score
        int max = plantMax + bugMax;
        PlayerStats.SetMaxScore(max);
    }
}
