using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    private const int point_for_every_letter = 1;
    private const int letter_multiplier = 10;
    public StringEvent sessionScoreModified;
    public StringEvent uiWordScoreModified;
    public SharedListChar guessLetters;
    public SharedInt sessionScore;
    private int _currentWordScore;
    
    // Hack:!
    private char[][] _letterScores =
    {
        new char[]{ '0', 'e', 'a', 'o', 'n', 'r', 't', 'l', 's', 'u'},
        new char[]{ '1', 'd', 'g' },
        new char[]{ '2', 'b', 'c', 'm', 'p' },
        new char[]{ '3', 'f', 'h', 'ı','v', 'w','y' },
        new char[]{ '4', 'k'},
        new char[]{ '7', 'j','x'},
        new char[]{ '9', 'q', 'z' }
    };

    public void SetWordScore( bool isLegit )
    {
        if (isLegit)
        {
            int wordScore = 0;
            for (int i = 0; i < _letterScores.Length; i++)
            {
                for (int j = 0; j < _letterScores[i].Length; j++)
                {
                    for (int k = 0; k < guessLetters.sharedList.Count; k++)
                    {
                        if (guessLetters.sharedList[k] == _letterScores[i][j])
                            wordScore += ( _letterScores[i][0] - '0') + 1;
                    }
                }
            }
            wordScore *= letter_multiplier * guessLetters.sharedList.Count * point_for_every_letter;
            _currentWordScore = wordScore;
            uiWordScoreModified.Raise($"Word Score: {wordScore}");
        }
        else
        {
            uiWordScoreModified.Raise($"Word Score: 0");
        }
    }

    public void SetSessionScore()
    {
        sessionScore.value += _currentWordScore;
        _currentWordScore = 0;
        sessionScoreModified.Raise($"Score: {sessionScore.value}");
        uiWordScoreModified.Raise($"Word Score: 0");
    }
}
