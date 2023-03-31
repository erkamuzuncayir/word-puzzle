using TMPro;
using UnityEngine;

public class UIFoundWord : MonoBehaviour
{
    public SharedListString submittedWords;
    private TextMeshProUGUI _foundWordText;  
    private void Awake()
    {
        _foundWordText = gameObject.GetComponent<TextMeshProUGUI>();
    }

    public void SetFoundWordText()
    {
        _foundWordText.text = "";
        for (var i = 0; i < submittedWords.sharedList.Count; i++)
        {
            _foundWordText.text += $"{submittedWords.sharedList[i]}\n";
        }
    }

    public void ResetText()
    {
        _foundWordText.text = "";
    }
}
