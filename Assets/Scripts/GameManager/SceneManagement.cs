using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour, IDataPersistence
{
    public string scene;
    public string sceneToLoad;

    public static SceneManagement instance;
    // Start is called before the first frame update
    void Start()
    {
        GetScene();
    }
    public void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    public static SceneManagement GetInstance()
    {
        return instance;
    }

    public void GetScene()
    {
        scene = SceneManager.GetActiveScene().name;
    }

    public void BeginGame()
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    public void LoadData(GameData data)
    {
        this.sceneToLoad = data.sceneName;
    }

    public void SaveData(GameData data)
    {
        data.sceneName = this.scene;
    }
}
