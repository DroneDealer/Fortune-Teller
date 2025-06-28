using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI;

public class MagicManager : MonoBehaviour
{
    public TMP_Text ResponseText;
    public GameObject ButtonOptions;
    public GameObject TryAgainButton;
    public CanvasGroup ButtonGroup;
    private Vector3 initialScale;

    private void Start()
    {
        initialScale = ResponseText.transform.localScale;
        ResponseText.transform.localScale = Vector3.zero;
        ResponseText.text = "";
        ButtonOptions.SetActive(true);
        ButtonGroup.alpha = 0f;
        ButtonGroup.interactable = false;
        ButtonGroup.blocksRaycasts = false;
        TryAgainButton.SetActive(false);
        StartCoroutine(FadeInButtons());
    }

    IEnumerator FadeInButtons()
    {
        float fadeDuration = 1f;
        float elapsed = 0f;
        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            ButtonGroup.alpha = Mathf.Lerp(0f, 1f, elapsed / fadeDuration);
            yield return null;
        }
        ButtonGroup.alpha = 1f;
        ButtonGroup.interactable = true;
        ButtonGroup.blocksRaycasts = true;
    }

    void ShowResponse(string message)
    {
        Debug.Log("ShowResponse called!");
        StopAllCoroutines();
        ResponseText.text = "";
        ButtonOptions.SetActive(false);
        TryAgainButton.SetActive(false);
        StartCoroutine(ShowSequence(message));

    }

    IEnumerator ShowSequence(string message)
    {
        yield return StartCoroutine(ZoomInEffect());
        yield return StartCoroutine(TypeText(message));
        TryAgainButton.SetActive(true);
    }
    IEnumerator ZoomInEffect()
    {
        float duration = 1f;
        float elapsed = 0f;
        Vector3 targetScale = initialScale;

        while (elapsed < duration)
        {
            ResponseText.transform.localScale = Vector3.Lerp(Vector3.zero, targetScale, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        ResponseText.transform.localScale = targetScale;
    }

    IEnumerator TypeText(string message)
    {
        ResponseText.text = "";
        foreach (char c in message)
        {
            ResponseText.text += c;
            yield return new WaitForSeconds(0.025f);
        } 
    }

    public void OnTryAgainClicked()
    {
        ResponseText.text = "";
        ResponseText.transform.localScale = Vector3.zero;
        TryAgainButton.SetActive(false);
        ButtonOptions.SetActive(true);
        StartCoroutine(FadeInButtons());

    }
    public void OnLoveCLicked()
    {
        ShowResponse(GetRandomResponse(new string[]
        {
            "Beware of love potions crafted with glitter - the effects will never wear off!",
            "In three arcane cycles' time, you will be struck with Cupid's arrow - just make sure he hits your heart rather than your head!",
            "Only the enchanted goblet of root beer can unlcok your romantic destiny.",
            "Your heart will be stolen by a mischievious creature - please make sure to get it back before it's sacrificed in a blood ritual!",
            "Your true love’s name is hidden inside the terms and conditions of a dating app.",
            "Romance will bloom once you hand-deliver a heart-shaped chicken nugget.",
            "Love spells are 65% ore effective when cast with a glitter pen."
        }));

    }

    public void OnLuckCLicked()
    {
        ShowResponse(GetRandomResponse(new string[]
        {
            "Luck will strike after you juggle three rabbits' feet and bathe in the barf of two dozen leprechauns.",
            "The universe winks at you - or perhaps it's simply a traffic light.",
            "Fortune will favor you upon the alignment of the 3 moons in the sky.",
            "All of the four leaf clovers in your vicinity run away from you the minute you step onto theri grounds. Try finding a 5 leaf one instead.",
            "Luck is on your side! Unless it's Tuesday. Then... oof."
        }));
    }

    public void OnStudiesCLicked()
    {
        ShowResponse(GetRandomResponse(new string[]
        {
            "You will undoubtedly pass your next exam upon sacrificing your calculator to the crescent moon.",
            "The pen is mightier than the sword, but ChatGPT is mightier still.",
            "Master the runes of the arcane library, lest you be trapped in the academy for yet another year.",
            "Beware the tricksters who rearrange your thoughts before our exam, lest you forget everything you studied for.",
            "Pepare yourself ofr your greatest challenge yet.",
            "The gods of academia demand you sacrifice one (1) mechanical pencil.",
            "Wisdom is stored inside your school’s lost-and-found bin."
        }));
    }

    public void OnFriendshipCLicked()
    {
        ShowResponse(GetRandomResponse(new string[]
        {
            "Your new friend may or may not be several dozen weasels in a very long trench coat.",
            "Your future best freind is currently trapped inside a vending machine.",
            "Be sure to befriend the new members at your next cult meeting.",
            "Your loyal companion awaits, bound by the oath of free food.",
            "The friendships you share with your comrades will last you several lifetimes and well into the afterlife as well!"
        }));
    }

    public void OnDangerCLicked()
    {
        ShowResponse(GetRandomResponse(new string[]
        {
            "Beware the one who knows your search history.",
            "Avoid eye cotact with any geese after exactly 5:29 PM.",
            "Do not enter the kitchen while holding both a fork and negative thoughts.",
            "The only way to remain safe tonight is to bathe in a barrrel of eels' eyes.",
            "Do not scream 'CHICKEN JOCKEY' this weekend, lest you be brutally attacked by an oncoming mob."
        }));
    }

    public void OnMoneyCLicked()
    {
        ShowResponse(GetRandomResponse(new string[]
        {
            "Gold awaits you... upon the completion of your chores.",
            "Beware the greedy trolls who have been stealing from your savings for the past 15 moon cycles.",
            "A debit card left in your pocket will unlock countless vaults of treasure.",
            "Countless riches await you in the couch cushions of destiny.",
        }));
    }

    public void OnHealthCLicked()
    {
        ShowResponse(GetRandomResponse(new string[]
        {
            "Your aches and pains will be cured upon realigning your chakras...and your WiFi router.",
            "Your very soul appears to be fueled purely by copious amounts of spite and caffeine",
            "Rest will return to you once you flip your pillow exactly 17 times under a waxing moon.",
            "Upon sleeping for longer than 5 hours at a time, you will find that all your pains have been cured.",
            "In order to reach the pinnacle of human athleticism, you must sacrifice your slice of pizza to the demigods."
        }));
    }

    public void OnSecretsCLicked()
    {
        ShowResponse(GetRandomResponse(new string[]
        {
            "Someone close to you is hiding something from you. Perhaps it's a slice of particularly delectable cake.",
            "You were cursed the moment you said ‘I’ll just rest my eyes for 5 minutes.’",
            "Your fridge light blinks in Morse Code.",
            "There is a truth you must face: your pets have been silently judging you. Justifiably so."
        }));
    }
    public void OnDreamsCLicked()
    {
        ShowResponse(GetRandomResponse(new string[]
        {
            "You will soar on the back of a flying toaster. Don’t ask why.",
            "WATER BUCKET RELEASE"//placeholder
        }));
    }

    private string GetRandomResponse(string[] responses)
    {
        return responses[Random.Range(0, responses.Length)];
    }
}