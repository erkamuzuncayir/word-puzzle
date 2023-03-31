using System.Collections.Generic;
using UnityEngine;

public class AssetManager : MonoBehaviour
{
    public GameSettings gameSettings;
    public SharedListLevelData allLevelData;
    public List<LevelTextAsset> levelsTextAssets = new List<LevelTextAsset>();
    public List<LevelData> levelsData;
    private int _levelCount;

    private void Awake()
    {
        allLevelData.sharedList.Clear();
        if (_levelCount != gameSettings.levelCount)
        {
            int levelCount = gameSettings.levelCount;
            for (int i = 0; i < levelCount; i++)
            {
                TextAsset jsonLevel = Resources.Load<TextAsset>($"Level Sources/level_{i + 1}");
                JsonUtility.FromJsonOverwrite(jsonLevel.text, levelsTextAssets[i]);

                levelsData[i].levelIndex = i + 1;
                levelsData[i].title = levelsTextAssets[i].title;
                allLevelData.sharedList.Add(levelsData[i]);
            }
        }
    }
}