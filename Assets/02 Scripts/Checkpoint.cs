using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private VoiceBit voiceBitCheckpoint;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.PlayVoiceBit(voiceBitCheckpoint);
            gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("not the player");
        }
    }
}
