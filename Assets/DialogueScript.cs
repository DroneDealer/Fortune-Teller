using UnityEngine;
using TMPro;
using System.Collections;
public class DialogueScript : MonoBehaviour
{
    public TextMeshProUGUI textBox;

    public GameObject continueIndicator;
    public string[] lines;
    public float delay = 0.03f;
    private int index = 0;
    private bool isTyping = false;
    private bool lineFinished = false;
    private void Start()
    {
        StartCoroutine(TypeText());
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isTyping)
        {
            NextLine();
        }
    }
    public IEnumerator TypeText()
    {
        isTyping = true;
        lineFinished = false;
        continueIndicator.SetActive(false);
        textBox.text = "";

        foreach (char c in lines[index])
        {
            textBox.text += c;
            yield return new WaitForSeconds(delay);
        }

        isTyping = true;
        lineFinished = false;
    }
    void NextLine()
    {
        continueIndicator.SetActive(false);
        if (index < lines.Length - 1)
        {
            index++;
            StartCoroutine(TypeText());
        }
        else
        {
            textBox.text = "";
            Debug.Log("End of dialogue");
            //add more to trigger next game action here (if nessecary for text)
        }
    }
}
