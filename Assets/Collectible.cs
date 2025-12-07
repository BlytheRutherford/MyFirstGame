using UnityEngine;

public class Collectible : MonoBehaviour
{
    private bool playerNearby = false;
    
    void Update()
    {
        // Rotate the collectible to make it obvious
        transform.Rotate(0, 500 * Time.deltaTime, 0);
        
        // Check if player presses E while nearby
        if (playerNearby && Input.GetKeyDown(KeyCode.E))
        {
            Collect();
        }
    }
    
    void OnTriggerEnter(Collider other)
    {
        // Check if player entered trigger zone
        if (other.CompareTag("Player"))
        {
            playerNearby = true;
            Debug.Log("The fuck is this?");
        }
    }
    
    void OnTriggerExit(Collider other)
    {
        // Check if player left trigger zone
        if (other.CompareTag("Player"))
        {
            playerNearby = false;
        }
    }
    
    void Collect()
    {
        Debug.Log("*You decide to throw it in the trash.");
        Destroy(gameObject);
    }
}
