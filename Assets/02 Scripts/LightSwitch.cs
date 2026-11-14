using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    [SerializeField] private GameObject m_interactableSignifier;
    [SerializeField] private GameObject m_switchOn;
    [SerializeField] private GameObject m_switchOff;
    [Space]
    [SerializeField] private GameObject m_lightOn;
    [SerializeField] private GameObject m_lightOff;
    [SerializeField] private GameObject m_lightRed;

    private bool isTurnedOn;

    public bool IsTurnedOn { get => isTurnedOn; set => isTurnedOn = value; }

    private void Start()
    {
        m_interactableSignifier.SetActive(false);
        m_switchOn.SetActive(false);
        m_switchOff.SetActive(true);

        m_lightOn.SetActive(true);
        m_lightOff.SetActive(false);
        m_lightRed.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            m_interactableSignifier.SetActive(true);
            GameManager.Instance.SetCurrentLightSwitch(this);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            m_interactableSignifier.SetActive(false);
            GameManager.Instance.ResetCurrentLightSwitch();
        }
    }

    public void SetSwitchOn()
    {
        m_switchOn.SetActive(true);
        m_switchOff.SetActive(false);

        m_lightOn.SetActive(false);
        m_lightOff.SetActive(true);

        isTurnedOn = true;
    }

    public void TriggerRedLight()
    {
        m_lightRed.SetActive(true);
    }

}
