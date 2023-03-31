using System.Collections;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public SharedListLevelData allLevelData;
    public VoidEvent newHighScoreAchieved;
    public GameObject parentGameplay;
    public GameObject parentLevelSelection;
    public GameObject parentHighScoreScreen;
    public SharedInt sessionScore;
    public VoidEvent levelStart;
    public VoidEvent levelEnd;
    public TextMeshProUGUI titleText;
    private LevelData _currentLevelData;
    private int _levelIndex;
    private int _oldHighScore;
    
    public void SetLevelData(int index)
    {
        sessionScore.value = 0;
        _currentLevelData = allLevelData.sharedList[_levelIndex];
        _levelIndex = index;
        _oldHighScore = _currentLevelData.highScore;
        titleText.text = _currentLevelData.title;
    }
    
    public void LevelEndSceneChooser()
    {
        Debug.Log("hey");
        parentGameplay.SetActive(false);
        parentLevelSelection.SetActive(false);
        if (_oldHighScore < sessionScore.value)
        {
            newHighScoreAchieved.Raise();
            parentHighScoreScreen.SetActive(true);
            _currentLevelData.highScore = sessionScore.value;
            sessionScore.value = 0;
            parentHighScoreScreen.GetComponentInChildren<TextMeshProUGUI>().text = $"New High Score!\n{sessionScore.value}";
            StartCoroutine(GoToLevelSelection());
        }
        else
        {
            parentGameplay.SetActive(false);
            parentLevelSelection.SetActive(true);
        }
    }

    IEnumerator GoToLevelSelection()
    {
        yield return new WaitForSeconds(3);
        parentHighScoreScreen.SetActive(false);
        parentGameplay.SetActive(false);
        parentLevelSelection.SetActive(true);
    }
}
