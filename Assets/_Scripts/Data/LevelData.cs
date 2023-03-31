using UnityEngine;

[CreateAssetMenu(fileName = "level_data", menuName = "Level Data")]
public class LevelData : ScriptableObject
{
    public int levelIndex;
    public string title;
    public bool isLocked = true;
    public int highScore;
}
