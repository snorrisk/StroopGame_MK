using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizManager : MonoBehaviour
{

    public List<QuestionsAndAnswers> QnA;

    // Reference for options
    public GameObject[] options;

    // Current question index
    public int currentQuestion;

    public Text QuestionTxt;

    private void Start()
    {

        generateQuestion();
    }

    public void correct()
    {

        QnA.RemoveAt(currentQuestion);
        generateQuestion();
    }

    void SetAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {

            // All buttons at the start are false
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            // Getting the answers from the buttons
            options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].Answers[i];

            if(QnA[currentQuestion].CorrectAnswer == i + 1)
            {

                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }

    // Create a method to generate questions
    void generateQuestion()
    {
        currentQuestion = Random.Range(0, QnA.Count);

        QuestionTxt.text = QnA[currentQuestion].Question;

        SetAnswers();
    }
}
