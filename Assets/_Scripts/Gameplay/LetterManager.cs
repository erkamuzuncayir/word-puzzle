using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class LetterManager : MonoBehaviour
{
    public static event Action<char[]> CheckIfPossibleWordsFromRemaining = delegate {  };
    public VoidEvent levelEnd;
    public LevelTextAsset levelTextAsset;
    public SharedListChar availableLetters;
    public GameObject letter;
    public GameObject spawnParent;
    public List<GameObject> spawnedLetters = new List<GameObject>();
    private List<List<int>> _blockerTiles;
    private List<List<int>> _blockedTiles;

    private void OnEnable()
    {
        WordBuildSystem.SubmitWord += OnSubmitWord;
    }

    private void OnDisable()
    {
        WordBuildSystem.SubmitWord -= OnSubmitWord;
    }
    
    void Start()
    {
        availableLetters.sharedList = new List<char>();
        availableLetters.sharedList.Clear();
        Tile[] letters = levelTextAsset.tiles;
        _blockerTiles = new List<List<int>>();
        _blockedTiles = new List<List<int>>();
        for (int i = 0; i < letters.Length; i++)
        {
            _blockerTiles.Add(new List<int>());
            _blockedTiles.Add(new List<int>());
        }

        for (int i = 0; i < letters.Length; i++)
        {
            Tile letter = letters[i];

            var spawnPos = new Vector3(letter.position.x , letter.position.y ,
                letter.position.z * 5);
            var spawnedLetter = Instantiate(this.letter, spawnPos, Quaternion.identity, spawnParent.transform );
            spawnedLetters.Add(spawnedLetter);
            spawnedLetter.GetComponentInChildren<TextMeshProUGUI>().text = letter.character;
            spawnedLetter.GetComponent<Letter>().letter = char.Parse(letter.character.ToLower());
            spawnedLetter.GetComponent<Letter>().assetIndex = letter.id;

            if (letter.children.Count > 0)
            {
                for (int j = 0; j < letter.children.Count; j++)
                {
                    _blockerTiles[i].Add(letter.children[j]);
                    _blockedTiles[letter.children[j]].Add(i);
                }
            }
        }

        SetStateOfLetters();
    }

    public void SetStateOfLetters()
    {
        for (int i = 0; i < _blockedTiles.Count; i++)
        {
            if (_blockedTiles[i].Count > 0)
            {
                spawnedLetters[i].GetComponent<Letter>().LockLetter();
            }
            else
            {
                spawnedLetters[i].GetComponent<Letter>().UnlockLetter();
            }
        }
    }

    private  void OnSubmitWord( List<GameObject> submittedLetters )
    {
        for (int i = 0; i < _blockedTiles.Count; i++)
        {
            for (int j = 0; j < submittedLetters.Count; j++)
            {
                if (_blockedTiles[i].Contains(submittedLetters[j].GetComponent<Letter>().assetIndex))
                {
                    _blockedTiles[i].Remove(submittedLetters[j].GetComponent<Letter>().assetIndex);
                }
                // if (_blockedTiles[i].Contains(submittedLetters[j].GetComponent<Letter>().assetIndex))
                // {
                // }
            }
        }
        
        submittedLetters.ForEach( l => l.SetActive(false));
        int count = spawnedLetters.Count(l => l.activeSelf);
        if (count < 1)
        {
            Debug.Log("i raised");
            levelEnd.Raise();
        }
        SetStateOfLetters();
        CheckRemainingLetters();
    }

    private void CheckRemainingLetters()
    {
        var remainingLetters = spawnedLetters.
            Where( l => l.activeSelf).
            Where(l => l.GetComponent<Letter>().isAvailable).Select(l => l.GetComponent<Letter>().letter).ToArray();

        CheckIfPossibleWordsFromRemaining(remainingLetters);
    }
}