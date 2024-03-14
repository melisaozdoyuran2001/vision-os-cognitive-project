using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SymbolClick : MonoBehaviour
{
    private VisualSearchTask visualSearchTask;

    void Start()
    {
        visualSearchTask = FindObjectOfType<VisualSearchTask>(); // Find the GameManager in the scene
    }

    void OnMouseDown() // This method is called when the cube is clicked
    {
        visualSearchTask.CheckSelection(gameObject); // Pass this cube to the GameManager to check
    }
}
