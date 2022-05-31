using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public Button ContinueButton;
    public Button menuButton;
    public static bool GameIsPaused = false;
    public GameObject pauseMenu;
    public GameObject UIDocument;
    // Start is called before the first frame update
    void Start()
    {
        


    }
    void Update()
    {
        try
        {
            var root = UIDocument.GetComponent<UIDocument>().rootVisualElement;
            ContinueButton = root.Q<Button>("start_button");
            menuButton = root.Q<Button>("exit_button");
            ContinueButton.clicked += ContinueButtonPressed;
  

            menuButton.clicked += MenuButtonPressed;
        }
        catch
        {

        }
       
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!GameIsPaused)
            {


                Pause();
            }
            else
            {


                Resume();
            }
        }
    }
    public void ContinueButtonPressed()
    {
        print("continue button pressed");

        pauseMenu.SetActive(false);
    }
    public void MenuButtonPressed()
    {
        print("Menu button pressed");
        SceneManager.LoadScene("MenuScene");
    }
    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
}
