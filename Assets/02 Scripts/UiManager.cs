using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_timerText;
    [SerializeField] private GameObject m_winStateMenu;
    [SerializeField] private GameObject m_failStateMenu;
    [SerializeField] private GameObject m_TextBox;

    private TextMeshProUGUI m_voiceCaptionText;

    private float remainingTime;

    private Coroutine textCoroutine;

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
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        StopAllCoroutines();
        m_winStateMenu.SetActive(true);
        m_TextBox.SetActive(false);

        GameManager.Instance.IsCameraInputDisabled = true;
        GameManager.Instance.IsMovementInputDisabled = true;
    }

    public void TriggerFailState()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        m_failStateMenu.SetActive(true);

        GameManager.Instance.IsCameraInputDisabled = true;
        GameManager.Instance.IsMovementInputDisabled = true;
    }

    public void ActivateCaption(VoiceBit voiceBit)
    {
        if(textCoroutine!=null)
            StopCoroutine(textCoroutine);

        m_TextBox.SetActive(true);
        m_voiceCaptionText.text = voiceBit.VoicebitText;

        textCoroutine = StartCoroutine(DeactivateCaptionText(voiceBit.VoicebitDuration));
    }

    private IEnumerator DeactivateCaptionText(float captionDuration)
    {
        yield return new WaitForSeconds(captionDuration + 0.5f);
        m_TextBox.SetActive(false);
        textCoroutine = null;
    }

    private IEnumerator TimerGoingDown()
    {
        while (remainingTime > 0)
        {
            m_timerText.text = remainingTime.ToString() ;
            yield return new WaitForSeconds(1f);
            remainingTime -= 1;
        }

        remainingTime = 0;
        m_timerText.text = remainingTime.ToString();
        TriggerFailState();
    }

    public void BTN_RestartGame()
    {
        SceneManager.LoadScene(1);
    }


    public void BTN_MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
