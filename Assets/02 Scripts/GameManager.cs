using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    [Header("Ingame References")]
    [SerializeField] LightSwitch[] lightSwitches;
    [SerializeField] UiManager uiManager;
    [SerializeField] GameObject checkPoints;
    [SerializeField] GameObject IdlePC;
    [SerializeField] GameObject WinSwitch;
    [SerializeField] GameObject volumeEnd;


    [Header("Voice Bits")]
    [SerializeField] VoiceBit startVoiceBit;
    [SerializeField] VoiceBit waitingTooLongVoiceBit01;
    [SerializeField] VoiceBit waitingTooLongVoiceBit02;
    [SerializeField] VoiceBit waitingTooLongVoiceBit03;
    [SerializeField] VoiceBit[] lightSwitchVoiceBits;

    [Header("Customizable")]
    [SerializeField] private float endTimerDuration;

    private List<LightSwitch> turnedOnSwitches;
    static public GameManager Instance;
    private LightSwitch currentLightSwitch;

    private bool isWinnable;
    private bool isEndgame;

    private bool isCameraInputDisabled;
    private bool isMovementInputDisabled;

    private Coroutine waitingTooLongTimer;

    private string currentVoiceBit;

    public bool IsWinnable { get => isWinnable; set => isWinnable = value; }
    public bool IsEndgame { get => isEndgame; set => isEndgame = value; }
    public bool IsCameraInputDisabled { get => isCameraInputDisabled; set => isCameraInputDisabled = value; }
    public bool IsMovementInputDisabled { get => isMovementInputDisabled; set => isMovementInputDisabled = value; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(Instance);
            Instance = this;
        }

        turnedOnSwitches = new List<LightSwitch>();
    }

    private void Start()
    {
        StartCoroutine(StartGame());
        checkPoints.SetActive(false);
    }

    private IEnumerator StartGame()
    {
        IsMovementInputDisabled = true;
        IsCameraInputDisabled = false;

        yield return new WaitForSeconds(0.5f);
        PlayVoiceBit(startVoiceBit);
        yield return new WaitForSeconds(startVoiceBit.VoicebitDuration);

        IsMovementInputDisabled = false;

        waitingTooLongTimer = StartCoroutine(CheckForLongWait());
    }

    private IEnumerator CheckForLongWait()
    {
        yield return new WaitForSeconds(15f);
        PlayVoiceBit(waitingTooLongVoiceBit01);
        yield return new WaitForSeconds(30f);
        PlayVoiceBit(waitingTooLongVoiceBit02);
        yield return new WaitForSeconds(30f);
        PlayVoiceBit(waitingTooLongVoiceBit03);
    }

    public void LightSwitchTurned()
    {
        StopCoroutine(waitingTooLongTimer);

        turnedOnSwitches.Add(currentLightSwitch);
        currentLightSwitch.SetSwitchOn();

        if (turnedOnSwitches.Count == lightSwitches.Length)
        {
            TriggerEndGame();
        }

        PlayVoiceBit(lightSwitchVoiceBits[turnedOnSwitches.Count -1]);
        ResetCurrentLightSwitch();
    }

    private void TriggerEndGame()
    {
        isEndgame = true;
        uiManager.StartTimer(endTimerDuration);
        checkPoints.SetActive(true);
        IdlePC.SetActive(false);
        volumeEnd.SetActive(true);

        foreach (LightSwitch s in lightSwitches)
        {
            s.TriggerRedLight();
        }
    }

    public void PlayVoiceBit(VoiceBit voiceBit)
    {
        AudioManager.instance.Stop(currentVoiceBit);
        uiManager.ActivateCaption(voiceBit);
        AudioManager.instance.Play(voiceBit.VoicebitName);
        currentVoiceBit = voiceBit.VoicebitName;
    }

    public void SetCurrentLightSwitch(LightSwitch lightSwitch)
    {
        currentLightSwitch = lightSwitch;
    }

    public void ResetCurrentLightSwitch()
    {
        currentLightSwitch = null;
    }

    public void CheckForLightSwitch()
    {
        if (currentLightSwitch != null && !currentLightSwitch.IsTurnedOn)
        {
            LightSwitchTurned();
            AudioManager.instance.Play("interact_success");
        }
        else
        {
            AudioManager.instance.Play("interact_fail");
        }
    }

    public void TryWinGame()
    {
        if (isWinnable)
        {
            uiManager.TriggerWinState();
            WinSwitch winSwitch = FindObjectOfType<WinSwitch>();

            winSwitch.ChangeScreen();
        }
        else
            return;

    }
}

