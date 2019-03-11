using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoBehaviour
{
    public GameObject[] asteroidPrefabs;
    public float maxVelocity = 3f;
    public float spawnRate = 1f;
    public float spawnPadding = 2f;
    public Color debugColor = Color.cyan;
    private void Start()
    {
        InvokeRepeating("SpawnLoop", 0, spawnRate); // Invoke a function repeaedly with given rate
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = debugColor;
        Gizmos.DrawWireSphere(transform.position, spawnPadding);
    }
    public void Spawn(GameObject prefab, Vector3 position)
    {
        Quaternion randomRot = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f)); //Randomize the rotation of the Asteroids
        GameObject asteroid = Instantiate(prefab, position, randomRot, transform); // Spawn random Asteroid at random position and default Quaternion rotation
        Rigidbody2D rigid = asteroid.GetComponent<Rigidbody2D>(); // Get Rigidbody2D from SAteroid
        Vector2 randomForce = Random.insideUnitCircle * maxVelocity;
        rigid.AddForce(randomForce, ForceMode2D.Impulse); // Apply random force to rigidbody
	}
	void SpawnLoop()
    {
        Vector3 randomPos = Random.insideUnitCircle * spawnPadding; //Generate random position inside sphere with spawn padding (radius)
        int randomIndex = Random.Range(0, asteroidPrefabs.Length); //Generate random index into Asteroids prefabs array
        GameObject randomAsteroid = asteroidPrefabs[randomIndex]; //Get random asteroid prefab from array unsing index
        Spawn(randomAsteroid, randomPos); // Spawn using random pos

	}
}
