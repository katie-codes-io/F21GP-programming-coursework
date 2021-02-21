using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetScore : MonoBehaviour
{
    public Text rating;
    public Text plantScore;
    public Text bugScore;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerStats.GetTotalScore() >= (0.8f * PlayerStats.GetMaxScore())) {
            rating.text     = "Rating: Gold";
        } else if (PlayerStats.GetTotalScore() >= (0.6f * PlayerStats.GetMaxScore())) {
            rating.text     = "Rating: Silver";
        } else if (PlayerStats.GetTotalScore() >= (0.4f * PlayerStats.GetMaxScore())) {
            rating.text     = "Rating: Bronze";
        } else {
            rating.text     = "You lost";
        }
        plantScore.text = string.Format("You got {0} points from saving {1} plants", PlayerStats.GetTotalPlantScore(), PlayerStats.GetPlants());
        bugScore.text   = string.Format("You got {0} points from killing {1} bugs",  PlayerStats.GetTotalBugScore(), PlayerStats.GetBugs());
    }
}
