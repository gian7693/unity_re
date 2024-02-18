using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SubtitleMenager : MonoBehaviour
{
    public GameObject captionPanel;
    public TMP_Text caption;

    public float typingSpeed;
    public float displayTime;

    public void ShowSubtitle(string msg)
    {
        caption.text = "";
        captionPanel.SetActive(true);
        StartCoroutine(ShowCaptionLetter(msg));
    }

    IEnumerator ShowCaptionLetter(string subtitle)
    {
        caption.maxVisibleCharacters = 0;
        caption.text = subtitle;

        while(caption.maxVisibleCharacters < subtitle.Length)
        {
            yield return new WaitForSeconds(typingSpeed);
            caption.maxVisibleCharacters++;
        }


        yield return new WaitForSeconds(displayTime);

        captionPanel.SetActive(false);
    }
}
