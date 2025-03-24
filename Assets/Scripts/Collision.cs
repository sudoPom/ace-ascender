using UnityEngine;
using UnityEngine.SceneManagement;

public class Collision : MonoBehaviour
{
    private bool death = false; //If the player has lost the game

    void Update()
    {
        if(death == true) //Switch to the GameOver screen if death is true
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") //If the player has collided with this GameObject set death to true
        {
            death = true;
        }
    }
}

