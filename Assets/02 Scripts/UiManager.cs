using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_timerText;
    [SerializeField] private GameObject m_winStateMenu;
    [SerializeField] private GameObject m_failStateMenu;
    [SerializeField] private GameObject m_TextBox;

    private TextMeshProUGUI m_voiceCaptionText;

    private float remainingTime;

    private void Start()
    {
        m_winStateMenu.SetActive(false);
        m_failStateMenu.SetActive(false);
        m_timerText.gameObject.SetActive(false);
        m_TextBox.SetActive(false);

        m_voiceCaptionText = m_TextBox.GetComponentInChildren<TextMeshProUGUI>();  
    }

    public void StartTimer(float timeDuration)
    {
        m_timerText.gameObject.SetActive(true);
        remainingTime = timeDuration;

        StartCoroutine(TimerGoingDown());
    }

    public void TriggerWinState()
    {
        m_winStateMenu.SetActive(true);
    }

    public void TriggerFailState()
    {
        m_failStateMenu.SetActive(true);
    }

    public void ActivateCaption(VoiceBit voiceBit)
    {
        m_TextBox.SetActive(true);
        m_voiceCaptionText.text = voiceBit.VoicebitText;

        StartCoroutine(DeactivateCaptionText(voiceBit.VoicebitDuration));
    }

    private IEnumerator DeactivateCaptionText(float captionDuration)
    {
        yield return new WaitForSeconds(captionDuration + 0.5f);
        m_TextBox.SetActive(false);
    }

    private IEnumerator TimerGoingDown()
    {
        while (remainingTime > 0)
        {
            m_timerText.text = remainingTime.ToString() ;
            yield return new WaitForSeconds(1f);
            remainingTime -= 1;
        }

    }
}
