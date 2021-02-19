using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    public float timeLimit = 60.0f;

    private string timeRemaining;
    private Rect countdownLabel;
    private bool gameover = false;
    private float elapsed = 0.0f;
    private GUIStyle style = new GUIStyle();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CalculateTime();
    }

    void CalculateTime()
    {
        // Update elapsed
        elapsed = elapsed + Time.deltaTime;

        // Calculate remaining time
        float remaining = timeLimit - elapsed;

        // Determine if time has run out
        if (remaining <= 0) {
            gameover = true;

        } else {

            // Format time for display
            float minutes = Mathf.FloorToInt(remaining / 60);
            float seconds = Mathf.FloorToInt(remaining % 60);
            timeRemaining = string.Format("{0:0}:{1:00}", minutes, seconds);
        }
    }

    void OnGUI()
    {
        // Style the label
        style.fontSize = 80;
        style.normal.textColor = Color.red;

        // Set window size
        int windowWidth = 100;
        int windowHeight = 100;

        // Game over screen or render time remaining
        if (gameover) {
            GetComponent<GameOver>().GameOverScreen();
        
        } else {

            // Show the time remaining
            countdownLabel = new Rect((0.5f*Screen.width) - (0.5f*windowWidth), (Screen.height - windowHeight), windowWidth, windowHeight);
            GUI.Label(countdownLabel, timeRemaining, style);
        }
    }

}
