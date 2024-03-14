using UnityEngine;
using TMPro; // For TextMeshPro elements
using UnityEngine.UI; // For UI elements like Buttons

public class StroopTest : MonoBehaviour
{
    public TextMeshProUGUI colorWordText; // Assign your TextMeshPro UI element in the inspector
    public Button correctButton; // Assign the correct answer button
    public Button wrongButton; // Assign the wrong answer button
    public string[] colorsInText = { "RED", "GREEN", "BLUE", "YELLOW" }; // Text values
    public Color[] colorsInInk = { Color.red, Color.green, Color.blue, Color.yellow }; // Ink colors

    private int correctAnswerIndex; // To keep track of the correct ink color

    void Start()
    {
        correctButton.onClick.AddListener(() => CheckAnswer(true));
        wrongButton.onClick.AddListener(() => CheckAnswer(false));
        GenerateStroopTest();
    }

    void GenerateStroopTest()
    {
        int textIndex = Random.Range(0, colorsInText.Length);
        int colorIndex = Random.Range(0, colorsInInk.Length);
        
        // Ensure the ink color is different for the wrong answer
        int wrongAnswerIndex;
        do
        {
            wrongAnswerIndex = Random.Range(0, colorsInInk.Length);
        } while (wrongAnswerIndex == colorIndex);

        colorWordText.text = colorsInText[textIndex];
        colorWordText.color = colorsInInk[colorIndex];
        correctAnswerIndex = colorIndex;

        // Randomly assign the correct and wrong answers to the two buttons
        if (Random.Range(0, 2) == 0)
        {
            correctButton.GetComponentInChildren<TextMeshProUGUI>().text = colorsInText[colorIndex];
            correctButton.image.color = colorsInInk[colorIndex];
            wrongButton.GetComponentInChildren<TextMeshProUGUI>().text = colorsInText[wrongAnswerIndex];
            wrongButton.image.color = colorsInInk[wrongAnswerIndex];
        }
        else
        {
            correctButton.GetComponentInChildren<TextMeshProUGUI>().text = colorsInText[wrongAnswerIndex];
            correctButton.image.color = colorsInInk[wrongAnswerIndex];
            wrongButton.GetComponentInChildren<TextMeshProUGUI>().text = colorsInText[colorIndex];
            wrongButton.image.color = colorsInInk[colorIndex];
        }
    }

    void CheckAnswer(bool isCorrect)
    {
        if (isCorrect)
        {
            // Correct answer logic here
            Debug.Log("Correct Answer!");
        }
        else
        {
            // Wrong answer logic here
            Debug.Log("Wrong Answer!");
        }
        // Generate the next question
        GenerateStroopTest();
    }
}
