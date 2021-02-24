using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetScore : MonoBehaviour
{
    //=========================================================//
    // Declare public variables
    public Text rating;
    public Text plantScore;
    public Text bugScore;

    //=========================================================//
    // Declare lifecycle methods
    void Start()
    {
        // Check the total score against the gold score
        if (PlayerStats.GetTotalScore() >= PlayerStats.GetGoldScore()) {
            rating.text = "Rating: Gold";

        } else if (PlayerStats.GetTotalScore() >= (0.5f * PlayerStats.GetGoldScore())) {
            rating.text = "Rating: Silver";

        } else if (PlayerStats.GetTotalScore() >= (0.25f * PlayerStats.GetGoldScore())) {
            rating.text = "Rating: Bronze";

        } else if (PlayerStats.GetPlants() == 0) {
            rating.text = "You lost";
        
        } else {
            rating.text = "Rating: Squish more bugs";
        }

        // Set the game over screen text
        plantScore.text = string.Format("You got {0} points from saving {1} plants", PlayerStats.GetTotalPlantScore(), PlayerStats.GetPlants());
        bugScore.text = string.Format("You got {0} points from killing {1} bugs", PlayerStats.GetTotalBugScore(), PlayerStats.GetBugs());
    }
}
