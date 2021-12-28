using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{

    public List<QuestionsAndAnswers> QnA;

    // Reference for options
    public GameObject[] options;

    // Current question index
    public int currentQuestion;

    public GameObject Quizpanel;
    public GameObject GoPanel;

    public Text QuestionTxt;
    public Text ScoreTxt;

    int totalQuestions = 0;
    public int score;

    private void Start()
    {

        totalQuestions = QnA.Count;
        GoPanel.SetActive(false);
        generateQuestion();
    }

    public void Retry()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GameOver()
    {

        Quizpanel.SetActive(false);
        GoPanel.SetActive(true);
        ScoreTxt.text = score + "/" + totalQuestions;
    }

    public void correct()
    {

        score += 1;
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
    }

    public void incorrect()
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

            if (QnA[currentQuestion].CorrectAnswer == i + 1)
            {

                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }

    // Create a method to generate questions
    void generateQuestion()
    {

        if(QnA.Count > 0)
        {

            currentQuestion = Random.Range(0, QnA.Count);

            QuestionTxt.text = QnA[currentQuestion].Questions;
            SetAnswers();
        }

        else
        {

            Debug.Log("Out of Questions!");
            GameOver();
        }
    }
}
