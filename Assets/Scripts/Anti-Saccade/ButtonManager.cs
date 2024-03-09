using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Rendering;

public class ButtonManager : MonoBehaviour
{
    private float startTime; 
    private float firstReactionTime; 
    private float secondReactionTime;
    public Button firstPartButton; 
    public Button secondPartButton; 
    public GameObject explosionAnimation; 
    public TextMeshProUGUI statusText; 
    public TextMeshProUGUI reactionTimeText; 

    void Start() {

         StartCoroutine(StartFirstPart());
    }

    IEnumerator StartFirstPart()
    {
        firstPartButton.gameObject.SetActive(true);
        statusText.text = "Press the left side of the screen when I say press. Ready?";
        yield return new WaitForSeconds(3); 
        startTime = Time.time; 
        statusText.text = "Press!";
    }

     public void OnLeftSidePressedFirstPart()
    {
        firstReactionTime = Time.time - startTime;
        StartCoroutine(SecondPartRoutine());
    }

    IEnumerator SecondPartRoutine()
    {
        firstPartButton.gameObject.SetActive(false);
        secondPartButton.gameObject.SetActive(true);
        statusText.text = "Let's do it again, press the left as soon as it says press. Ready? ";
        yield return new WaitForSeconds(5); 
        statusText.text = "";
        explosionAnimation.SetActive(true);
        yield return new WaitForSeconds(0.3f); 
        statusText.text = "Press!";
        startTime = Time.time; 
        yield return new WaitForSeconds(5); 
        explosionAnimation.SetActive(false);
        startTime = Time.time;
       
    }

     public void OnLeftSidePressedSecondPart()
    {
        secondReactionTime = Time.time - startTime;
        CompareReactionTimes();
    }

    void CompareReactionTimes()
    {
        Debug.Log($"First Reaction Time: {firstReactionTime}, Second Reaction Time: {secondReactionTime}");
        statusText.text = $"First Reaction Time: {firstReactionTime}, Second Reaction Time: {secondReactionTime}";
    }

}
