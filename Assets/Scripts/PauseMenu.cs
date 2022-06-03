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

         void ContinueButtonPressed()
        {
            Resume();
        }
         void MenuButtonPressed()
        {
            print("Menu button pressed");
            SceneManager.LoadScene("MenuScene");
        }
         void Pause()
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            GameIsPaused = true;
        }

        void Resume()
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
            GameIsPaused = false;
        }
    }
}
