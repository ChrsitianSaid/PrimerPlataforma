using UnityEngine;

public class Coin : MonoBehaviour
{

    private UIManager uiManager; // Reference to the UIManager script
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {

            uiManager = Object.FindObjectOfType<UIManager>(); // Find the UIManager script in the scene
            uiManager.CollectCoin(); // Call the CollectCoin method in the UIManager script to update the coin count
            
            Destroy(gameObject); // Destroy the coin object when the player collides with it
        }
    }
}
