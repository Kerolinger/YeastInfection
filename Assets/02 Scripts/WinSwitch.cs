using System.Buffers;
using UnityEngine;

public class WinSwitch : MonoBehaviour
{
    [SerializeField] private GameObject m_interactableSignifier;
    [SerializeField] private GameObject m_switchOn;
    [SerializeField] private GameObject m_switchOff;


    private void Start()
    {
        m_interactableSignifier.SetActive(false);
        m_switchOn.SetActive(false);
        m_switchOff.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            m_interactableSignifier.SetActive(true);
            GameManager.Instance.IsWinnable = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            m_interactableSignifier.SetActive(false);
            GameManager.Instance.IsWinnable = false;
        }
    }

    public void ChangeScreen()
    {
        m_switchOn.SetActive(true);
        m_switchOff.SetActive(false);

        m_interactableSignifier.SetActive(false);
    }

}
