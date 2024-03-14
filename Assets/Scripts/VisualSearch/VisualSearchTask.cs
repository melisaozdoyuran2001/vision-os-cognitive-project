using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualSearchTask : MonoBehaviour
{
    public GameObject uniquePrefab; // Assign in editor
    public GameObject notUniquePrefab; // Assign in editor
    public int numberOfCubes = 5; // Total number of cubes including the unique one
    private GameObject uniqueCube;

    void Start()
    {
        SpawnCubes();
    }

    void SpawnCubes()
    {
        Debug.Log("Spawning");
        // Destroy previous cubes if any
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        int uniqueIndex = Random.Range(0, numberOfCubes); // Randomly decide the unique cube

        for (int i = 0; i < numberOfCubes; i++)
        {
            GameObject cube = i == uniqueIndex ? Instantiate(uniquePrefab, RandomPosition(), Quaternion.identity, transform) : Instantiate(notUniquePrefab, RandomPosition(), Quaternion.identity, transform);
            if (i == uniqueIndex) uniqueCube = cube; // Keep reference to the unique cube
        }
    }

   Vector3 RandomPosition()
{
    float xPosition = Random.Range(-2.5f, -1.8f); // Example range, adjust as needed
    float yPosition = 0.8f; // Adjust as needed based on your scene's ground level
    float zPosition = -5.2f; // Adjust if you want some depth variance

    return new Vector3(xPosition, yPosition, zPosition);
}


    public void CheckSelection(GameObject selectedCube)
{
    Debug.Log("Clicked object tag: " + selectedCube.tag); // Debugging line

    if (selectedCube.CompareTag("Unique"))
    {
        Debug.Log("Right!");
        SpawnCubes(); // Restart with new cubes
    }
    else
    {
        Debug.Log("Wrong!");
    }
}

}

