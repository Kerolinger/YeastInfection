using UnityEngine;

[System.Serializable]
public class VoiceBit
{
    [SerializeField] private string voicebitName;
    [SerializeField] private string voicebitText;
    [SerializeField] private float voicebitDuration;

    public string VoicebitName { get => voicebitName; set => voicebitName = value; }
    public string VoicebitText { get => voicebitText; set => voicebitText = value; }
    public float VoicebitDuration { get => voicebitDuration; set => voicebitDuration = value; }
}
