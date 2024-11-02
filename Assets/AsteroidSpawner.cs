using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public float fixedZPosition = 20f;   // Set a fixed Z position for all asteroids
    public float minXPosition = -4.5f;    // Minimum X position range
    public float maxXPosition = 4.5f;     // Maximum X position range

    private GameObject currentAsteroid;

    void Start()
    {
        SpawnAsteroid();
    }

    // Method to spawn a new asteroid at a random X position
    public void SpawnAsteroid()
    {
        // Generate a random X position within the defined range
        float randomXPosition = Mathf.Clamp(Random.Range(minXPosition, maxXPosition), minXPosition, maxXPosition);
        Debug.Log("Random x Posi: "+ randomXPosition);
        
        // Set the position for the new asteroid
        Vector3 spawnPosition = new Vector3(randomXPosition, 0.2f, fixedZPosition);
        
        // Instantiate the asteroid and keep track of it
        currentAsteroid = Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity);
        
        // Add a listener to detect when the asteroid is destroyed
        currentAsteroid.GetComponent<AsteroidBehaviour>().onDestroyed += SpawnAsteroid;
    }
}
