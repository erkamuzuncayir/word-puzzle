using UnityEngine;
using UnityEngine.UI;

public class UndoButtonController : MonoBehaviour
{
    private Button _undoButton;
    public IntEvent undoIndex;
    public SharedListChar guessLetters;

    private void Awake()
    {
        _undoButton = this.gameObject.GetComponent<Button>();
    }

    public void UndoOneLetter()
    {
        if (guessLetters.sharedList.Count > 0)
        {
            undoIndex.Raise( guessLetters.sharedList.Count - 1);
        }
        
    }
}
