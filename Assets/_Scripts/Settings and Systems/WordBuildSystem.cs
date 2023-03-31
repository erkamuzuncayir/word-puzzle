using System;
using System.Collections.Generic;
using UnityEngine;

public class WordBuildSystem : MonoBehaviour
{
    public static event Action<List<GameObject>> SubmitWord = delegate{  };
    public VoidEvent letterPlaced;
    public VoidEvent emptyWordArea;
    public SharedListChar guessLetters;
    public SharedListString submittedWords;
    public Transform[] slots;
    private List<GameObject> _placedLetters = new List<GameObject>();
    private void Awake()
    {
        submittedWords.sharedList = new List<string>();
        guessLetters.sharedList = new List<char>();
    }

    private void OnEnable()
    {
        Letter.PlaceMe += PlaceLetter;
        Letter.RemoveMe += RemoveLetter;
    }

    private void OnDisable()
    {
        Letter.PlaceMe -= PlaceLetter;
        Letter.RemoveMe -= RemoveLetter;
    }

    public void PlaceLetter( GameObject receivedLetter )
    {
        _placedLetters.Add(receivedLetter);
        for (int i = 0; i < _placedLetters.Count; i++)
        {
            _placedLetters[i].transform.localScale = new Vector3(4f, 4f, 4f);
            _placedLetters[i].transform.position = slots[i].transform.position;
        }
        guessLetters.sharedList.Add(receivedLetter.GetComponent<Letter>().letter);
        receivedLetter.GetComponent<Letter>().wordIndex = guessLetters.sharedList.Count - 1;
        
        letterPlaced.Raise();
    }

    private void RemoveLetter(GameObject receivedLetter)
    {
        guessLetters.sharedList.RemoveAt(guessLetters.sharedList.Count - 1);
        _placedLetters.Remove(receivedLetter);
        receivedLetter.GetComponent<Letter>().wordIndex = -1;
        if (guessLetters.sharedList.Count < 1)
        {
            emptyWordArea.Raise();
        }
        // Raise this due to check again for submit button in edge cases.
        letterPlaced.Raise();
    }
    
    public void SendSubmittedLetters()
    {
        SubmitWord(_placedLetters);
        submittedWords.sharedList.Add(new string(guessLetters.sharedList.ToArray()));
        _placedLetters.Clear();
        guessLetters.sharedList.Clear();
    }
}
