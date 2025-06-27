using TMPro;
using UnityEngine;

public class PromptSubmit : MonoBehaviour
{
    public TMP_InputField KnowledgeSeekerQuestion;

    public void SubmitButtonClicked()
    {
        string prompt = KnowledgeSeekerQuestion.text;


        KnowledgeSeekerQuestion.text = "";
    }

    void SendProntToAI(string prompt)
    {
        
    }
}