using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    [SerializeField] private GameObject credits;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void BTN_ToggleCredits()
    {
        credits.SetActive(!credits.activeSelf);
    }

    public void BTN_StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void BTN_QuitGame()
    {
        Application.Quit();
    }
}
