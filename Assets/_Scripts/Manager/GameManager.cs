using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public SharedListLevelData allLevelData;
    private int _currentLevelIndex;
    void Start()
    {
        Application.targetFrameRate = Screen.currentResolution.refreshRate;
    }

    public void LoadScene(int levelIndex)
    {
        _currentLevelIndex = levelIndex;
        SceneManager.LoadScene($"level_{levelIndex}", LoadSceneMode.Additive);
        
        StartCoroutine(WaitForSceneLoad(SceneManager.GetSceneByName($"level_{levelIndex}")));
    }

    public IEnumerator WaitForSceneLoad(Scene scene)
    {
        while(!scene.isLoaded)
        {
            yield return null;  
        }
        SceneManager.SetActiveScene (scene);
    }

    public void UnloadScene()
    {
        SceneManager.UnloadSceneAsync($"level_{_currentLevelIndex}");
    }

    public void UnlockNewLevel()
    {
        // We didn't add 1 because value that _currentLevelIndex hold starts from 1.
        allLevelData.sharedList[_currentLevelIndex].isLocked = false;
    }
}
