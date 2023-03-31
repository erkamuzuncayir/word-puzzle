using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UILevelDataHandler : MonoBehaviour
{
    public LevelData levelData;
    public TextMeshProUGUI levelInfo;
    public Button playButton;

    private void Start()
    {
        TakeLevelData();
    }

    public void TakeLevelData()
    {
        levelInfo.text = $"Level {levelData.levelIndex} - {levelData.title}\nHigh Score: {levelData.highScore}";
        if (levelData.isLocked)
            playButton.interactable = false;
    }
    
    public void UnlockLevelUI()
    {
        if (!levelData.isLocked)
            playButton.interactable = true;
    }
    
}
