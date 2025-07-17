using UnityEngine;
using TMPro;
using System.Collections;

public class MagicManager : MonoBehaviour
{
    public TMP_Text ResponseText;
    public GameObject ButtonOptions;
    //private Vector3 initialScale = Vector3.one;
    public GameObject TryAgainButton;
    public AudioSource audioSource;
    public AudioClip crystalBallRevealSound;

    private void Start()
    {
        TryAgainButton.SetActive(false);
        //initialScale = new Vector3(1f, 1f, 1f);
        //Debug.Log("Initial scale: " + initialScale);
        ResponseText.gameObject.SetActive(true);
    }

    void ShowResponse(string message)
    {
        ResponseText.gameObject.SetActive(true);
        ResponseText.text = message;
        if (audioSource != null && crystalBallRevealSound != null)
        {
            audioSource.PlayOneShot(crystalBallRevealSound);
        }
        else
        {
            Debug.Log("Either your audio manager or your audio clip are unassigned");
        }
        ResponseText.transform.localScale = Vector3.zero;
        ButtonOptions.SetActive(false);
        TryAgainButton.SetActive(false);
        StartCoroutine(ZoomInAndShowTryAgain());
        Debug.Log("Final scale: " + ResponseText.transform.localScale);

    }
    IEnumerator ZoomInEffect()
    {
        float duration = 1f;
        float elapsed = 0f;
        Vector3 startScale = Vector3.zero;
        Vector3 endScale = Vector3.one;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / duration);
            ResponseText.transform.localScale = Vector3.Lerp(startScale, endScale, t);
            yield return null;
        }
        ResponseText.transform.localScale = endScale;

    }
    IEnumerator ZoomInAndShowTryAgain()
    {
        yield return StartCoroutine(ZoomInEffect());
        TryAgainButton.SetActive(true);
    }

    public void OnTryAgainClicked()
    {
        ButtonOptions.SetActive(true);
        ResponseText.text = "";
        ResponseText.transform.localScale = Vector3.zero;
        TryAgainButton.SetActive(false);
    }
    public void OnLoveCLicked()
    {
        ShowResponse(GetRandomResponse(new string[]
        {
            "Beware of love potions crafted with glitter - the effects last ages!",
            "In three arcane cycles' time, you will be struck with Cupid's arrow - just make sure he hits your heart rather than your head!",
            "Only the enchanted goblet of miscellanious sludge can unlock your romantic destiny.",
            "Your heart will be stolen by a mischievous creature - please make sure to get it back before it's sacrificed in a blood ritual!",
            "Your true love’s name is hidden inside the terms and conditions of a dating app.",
            "Romance will bloom once you hand-deliver a heart-shaped chicken nugget.",
            "Love spells are 65% more effective when cast with a glitter pen.",
            "There is no substitute for a heart of gold and the willingness to lend an ear.",
            "NEVER resort to supplements like love potions or currency to condition someone's love - it never ends well for anyone!",
            "Love will undoubtedly find you very, very soon. If you want to ward it off for now, I suggest surrounding your house with a salt ring..."
        }));

    }

    public void OnLuckCLicked()
    {
        ShowResponse(GetRandomResponse(new string[]
        {
            "Luck will strike after you juggle three rabbits' feet and bathe in the barf of two dozen leprechauns.",
            "The universe winks at you - or perhaps it's simply a traffic light.",
            "Fortune will favor you upon the alignment of the 3 moons in the sky.",
            "All of the four leaf clovers in your vicinity immediately wilt the minute you step onto their turf. I did not know that was possible. Congratulations. You mark a new level of unluckiness.",
            "Luck is on your side! Unless it's Tuesday. Then... oof.",
            "Luck will continue to evade you for quite some time - may I suggest hunting it yourself instead of taking a passive role?",
            "You will almost trip, but catch yourself like a majestic gazelle. No one will see.",
            "Great fortune is near. Unfortunately, it’s very near someone else.",
            "The cosmos are whispering your name… and now they are giggling. Oh dear.",
            "You are the chosen one. Of what, exactly, is still under review."
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
            "Pepare yourself for your greatest challenge yet.",
            "The gods of academia demand you sacrifice one (1) mechanical pencil.",
            "Wisdom is stored inside your school’s lost-and-found bin.",
            "Wisdom has been chasing you, but you have always been faster.",
            "The secrets of the universe can only be unfurled by the hardest of workers and the wisest of mentors - so get to it!",
            "You will understand everything… five minutes after turning in the assignment.",
            "The answer is C. Always C. Trust the prophecy.",
            "Your future self sends this message: 'Do not trust tomorrow’s motivation.'",
            "The spirits say your group project partner is already ghosting you."
        }));
    }

    public void OnFriendshipCLicked()
    {
        ShowResponse(GetRandomResponse(new string[]
        {
            "Your new friend may or may not be several dozen weasels in a very long trench coat.",
            "Your future best friend is currently trapped inside a vending machine. Somehow.",
            "Be sure to befriend the new members at your next cult meeting.",
            "Your loyal companion awaits, bound by the oath of free food.",
            "The friendships you share with your comrades will last you several lifetimes and well into the afterlife as well!",
            "A shared glance shall ignite ancient forces… or just synchronized laughter. Both are sacred.",
            "A friend will reach out at the exact moment you think you’re alone. This is no accident.",
            "You are the safe place in someone’s world — even if they never say it out loud.",
            "One day, you will laugh about something painful — and a friend will be the reason you can.",
            "There are people who choose you, again and again — even on your worst days. Let that mean something."
        }));
    }

    public void OnDangerCLicked()
    {
        ShowResponse(GetRandomResponse(new string[]
        {
            "Beware the one who knows your search history.",
            "Avoid eye contact with any geese after exactly 5:29 PM.",
            "Do not enter the kitchen while holding both a fork and negative thoughts.",
            "The only way to remain safe tonight is to bathe in a barrel of eels' eyes.",
            "Do not scream 'CHICKEN JOCKEY' this weekend, lest you be brutally attacked by an oncoming mob.",
            "The next 'harmless' and 'unproblematic' idea that you have will undoubtedly result in exactly 4 new, very problematic issues.",
            "It is fortold that you will masquerade your poor judgement and your subsequent decisions as a grand adventure.",
            "Something is watching you. Upon sensing it, don’t turn around too fast to face it. It hates that.",
            "You are being watched. Not with malice, just... interest. One could argue that that is worse.",
            "Your next step will be into something wet. You will not know what it was.",
            "Beware the group chat. Sinister plans are brewing.",
            "Your next brilliant idea will end with '...well, that excalated quickly.'"
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
            "Your future holds riches. Spiritually. Emotionally. Oh, in terms of currency? Hmm...I don't concern myself with such frivolities. Yeah. Such things are beyond me.",
            "You will make quite the financial decision! It will be bold and unforgettable. It will also be laughably foolish.",
            "You will check your balance soon. I wouldn’t.",
            "Wealth is within reach... of someone nearby. Not you. But someone.",
            "Good things will come to you - you just have to recover from 3 different crises in addition to perishing and resurrecting yourself a couple times.",
            "The universe offers you abundance. You will most likely decline politely and buy snacks instead."
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
            "In order to reach the pinnacle of human athleticism, you must sacrifice your slice of pizza to the demigods.",
            "Your body is a temple. Its build blueprints are currently missing along with half of the materials.",
            "A single vegetable will pass through your day. Blink and you’ll miss it.",
            "You will find that all your injuries ahve been iraculously heald upon properly and consistently hydrating your body. You will never do this again.",
        }));
    }

    public void OnSecretsCLicked()
    {
        ShowResponse(GetRandomResponse(new string[]
        {
            "Someone close to you is hiding something from you. Perhaps it's a slice of particularly delectable cake.",
            "You were cursed the moment you said ‘I’ll just rest my eyes for 5 minutes.’",
            "Your fridge light blinks in Morse Code.",
            "There is a truth you must face: your pets have been silently judging you. Justifiably so.",
            "A locked drawer. A forgotten message. The key is in your possession, metaphorically or not.",
            "Something you forgot remembers you.",
            "You’ve just been trusted with a secret. You didn’t ask for this responsibility, but here we are.",
            "You have many talents. Use them irresponsibly. I am BEGGING you. I need something interesting to forsee.",
            "Secrets are like soda pop - keep them open, they become stale. But if bottle them up, and someone shakes... well, the explosion is not enviable."
        }));
    }
    public void OnDreamsCLicked()
    {
        ShowResponse(GetRandomResponse(new string[]
        {
            "You chase greatness with fire in your eyes. Just don’t forget the map.",
            "You’re sprinting up a staircase meant for climbing. Pace yourself — you’ll still reach the top.",
            "A detour doesn’t mean defeat. Your path curves on purpose.",
            "Your ambition is admirable. Your follow-through? Not so much...",
            "The stars say: shoot your shot. But please, make sure to aim first.",
            "Keep climbing. The view from the middle is wildly underappreciated.",
            "A spark of inspiration will light your path when you least expect it.",
            "The seeds of aspiration, fed by hard work and hope, will bloom into triumph.",
            "One day, your “someday” plans will become “today.” Until then, keep procrastinating beautifully.",
            "You will find success, one accidental breakthrough at a time."
        }));
    }

    private string GetRandomResponse(string[] responses)
    {
        return responses[Random.Range(0, responses.Length)];
    }

}