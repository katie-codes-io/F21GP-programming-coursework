using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    public float health = 10.0f;
    public float damageMultiplier = 1.0f;

    private float damage = 0.0f;
    private Vector3 scaleChange;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Damage sunflower
    void Damage() {

        // Increment damage
        float increment = damageMultiplier * Time.fixedDeltaTime;
        damage += increment;

        // First check if sunflower has been killed
        if (damage >= health) {
            Destroy(gameObject);
        }
        
        // Calculate proportional damage - the sunflower shrinks by that amount
        float propDamage = (increment / health) / 2;
        scaleChange = new Vector3(-propDamage, -propDamage, -propDamage);
        transform.localScale += scaleChange;
    }

    // Collision with bug begins
    void OnCollisionEnter (Collision collision) {

        // First check if other is a bug
        if (collision.collider.tag == "Bug") {
            foreach (Transform child in transform) {
                child.GetComponent<Renderer>().material.color = Color.red;
            }
        }
    }

    // Collision with bug is ongoing
    void OnCollisionStay (Collision collision) {

        // First check if other is a bug
        if (collision.collider.tag == "Bug") {
            // calculate damage
            Damage();
        }
    }

    // Collision stopped
    void OnCollisionExit (Collision collision) {

        // First check if other is a bug
        if (collision.collider.tag == "Bug") {
            foreach (Transform child in transform) {
                child.GetComponent<Renderer>().material.color = Color.white;
            }
        }
    }
}
