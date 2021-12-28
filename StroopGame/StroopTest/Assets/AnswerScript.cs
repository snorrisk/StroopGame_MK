using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerScript : MonoBehaviour
{

    public bool isCorrect = false;
    public QuizManager quizManager;

    // Answer will be called when clicking on the buttons
    public void Answer()
    {

        if (isCorrect)
        {
            Debug.Log("Err... Correcto!");
            quizManager.correct();
        }

        else
        {
            Debug.Log("No Answero!");
            quizManager.correct();
        }
    }
}
