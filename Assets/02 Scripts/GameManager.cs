using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    [Header("Ingame References")]
    [SerializeField] LightSwitch[] lightSwitches;
    [SerializeField] VoiceBit[] lightSwitchVoiceBits;
    [SerializeField] UiManager uiManager;
    static public GameManager Instance;

    [Header("Customizable")]
    [SerializeField] private float endTimerDuration;

    private List<LightSwitch> turnedOnSwitches;

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


    void LightSwitchTurned(LightSwitch lightSwitch)
    {
        turnedOnSwitches.Add(lightSwitch);

        if(turnedOnSwitches.Count == lightSwitches.Length)
        {
            //Trigger Red Light turning on
            uiManager.StartTimer(endTimerDuration);
        }
    }

    public void PlayVoiceBit(VoiceBit voiceBit)
    {

    }
}
