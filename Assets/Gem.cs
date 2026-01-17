using UnityEngine;

public class Gem : MonoBehaviour
{
    public int scoreValue = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.AddScore(scoreValue);
            Destroy(gameObject);
        }
    }
}