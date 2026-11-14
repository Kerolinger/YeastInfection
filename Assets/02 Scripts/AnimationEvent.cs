using UnityEngine;

public class AnimationEvent : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void PlaySound(string soundName)
    {
        AudioManager.instance.Play(soundName);
    }

    public void DeactivateObject()
    {
        gameObject.SetActive(false);
    }
}
