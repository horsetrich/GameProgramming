using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [Header("Menu Buttons")]
    [SerializeField] private Button newGameButton;
    [SerializeField] private Button continueGameButton;

    private void Start()
    {
        if (!DataPersistenceManager.Instance.HasGameData())
        {
            continueGameButton.interactable = false;
        }
    }

    public void OnNewGameClicked()
    {
        DataPersistenceManager.Instance.NewGame();

        SceneManager.LoadSceneAsync("Sample scene");
        

        DisableMenuButtons();
    }

    public void OnContinueGameClicked()
    {
        SceneManager.LoadSceneAsync(SceneManagement.GetInstance().sceneToLoad);

        DisableMenuButtons();
    }

    public void ExitApplication()
    {
        Application.Quit();
    }

    private void DisableMenuButtons()
    {
        newGameButton.interactable = false;
        continueGameButton.interactable = false;
    }
}
