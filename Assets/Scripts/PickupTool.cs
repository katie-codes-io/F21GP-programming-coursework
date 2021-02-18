using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupTool : MonoBehaviour
{
    public GameObject tool;
    public string label;
    public float horizontal = 0.5f;
    public float vertical = 0.5f;

    private Rect popup;
    private GUIStyle style = new GUIStyle();
    private bool showPopup = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Pick up tool
    void PickUp() {
        Debug.Log("Pick up");
    }

    // Trigger
    void OnTriggerStay(Collider other) {

        // First check if other is a player
        if (other.tag == "Player") {

            // Show the popup
            showPopup = true;

            // Check if player wants to pick up tool
            var controller = other.GetComponent<KeyboardController>();
            bool pickingUp = Input.GetKey(controller.keyPickup);

            if (pickingUp) {
                PickUp();
            }
        }

    }

    // Trigger
    void OnTriggerExit(Collider other) {

        // First check if other is a player
        if (other.tag == "Player") {

            // Stop showing the popup
            showPopup = false;
        }
    }

    void OnGUI() {

        // Render the popup
        if (showPopup) {
            style.fontSize = 48;
            style.normal.textColor = Color.white;
            popup = new Rect((horizontal*Screen.width), (vertical*Screen.height), 300, 60);
            GUI.Label(popup, label, style);
        }
    }
}
