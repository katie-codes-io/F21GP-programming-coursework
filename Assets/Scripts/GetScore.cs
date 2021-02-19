using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetScore : MonoBehaviour
{
    public Text winLose;
    public Text score;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerStats.GetScore() == 0) {
            winLose.text = "You lost :-(";
            score.text = "You didn't save any plants";
        } else if (PlayerStats.GetScore() == PlayerStats.GetMaxPossible()) {
            winLose.text = "You won :-)";
            score.text = "You saved all the plants";
        } else {
            winLose.text = "You won";
            score.text = string.Format("You saved {0} plants", PlayerStats.GetScore());
        }
    }
}
