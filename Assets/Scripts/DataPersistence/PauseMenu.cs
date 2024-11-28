using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [Header("Pause Menu Buttons")]
    [SerializeField] private GameObject firstSelected;

    [SerializeField] private GameObject hideUI;
    public static bool GameIsPause = false;
    public GameObject pauseMenuUI;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            if (GameIsPause)

            {
                Resume();
            }
            else
            {
                Pause();
                //start coroutine
                StartCoroutine(SelectFirstChoice());
            }
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPause = false;
        hideUI.SetActive(true);
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPause = true;
        hideUI.SetActive(false);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }
    private IEnumerator SelectFirstChoice()
    {
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(firstSelected.gameObject);
    }
}
