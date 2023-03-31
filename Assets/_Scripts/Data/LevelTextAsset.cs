using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "level_text_asset_", menuName = "Level Text Asset")]
[System.Serializable]
public class LevelTextAsset : ScriptableObject
{
    public string title;
    public Tile[] tiles;
}
[System.Serializable]
public class Tile
{
    public int id;
    public Position position;
    public string character;
    public List<int> children;
}
[System.Serializable]
public class Position
{
    public float x;
    public float y;
    public float z;
}
