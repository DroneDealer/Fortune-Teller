using UnityEngine;
using TMPro;
using System.Collections;

public class DialogueScript : MonoBehaviour
{
    public TextMeshProUGUI textBox;
    public GameObject dialogueBubble;
    public GameObject continueIndicator;
    public string[] lines;
    public float delay = 0.03f;
    private int index = 0;
    private bool isTyping = false;

    public FinalZoom cameraZoom;  // Add this, assign in Inspector

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
        continueIndicator.SetActive(false);
        textBox.text = "";

        foreach (char c in lines[index])
        {
            textBox.text += c;
            yield return new WaitForSeconds(delay);
        }

        isTyping = false;
        continueIndicator.SetActive(true);
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
            textBox.gameObject.SetActive(false);
            continueIndicator.SetActive(false);
            dialogueBubble.SetActive(false);
            Debug.Log("End of dialogue");

            // Trigger camera zoom here:
            if (cameraZoom != null)
            {
                cameraZoom.StartZoom();
            }
        }
    }
}
