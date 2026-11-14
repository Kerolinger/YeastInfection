using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private VoiceBit voiceBitCheckpoint;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("something entered");
        if (other.CompareTag("Player"))
        {
            Debug.Log("something entered");
            GameManager.Instance.PlayVoiceBit(voiceBitCheckpoint);
            gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("no player");
        }
    }
}
