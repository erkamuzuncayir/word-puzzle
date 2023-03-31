using System;
using UnityEngine;
using UnityEngine.UI;

public class Letter : MonoBehaviour
{
    public static event Action<GameObject> PlaceMe = delegate {  }; 
    public static event Action<GameObject> RemoveMe = delegate {  }; 
    public Sprite lockImage;
    public Sprite unlockImage;
    public char letter;
    public int wordIndex = -1;
    public bool isAvailable;
    public int assetIndex;
    private Vector3 _initialPosition;
    private Vector3 _initialScale;
    private BoxCollider _letterCollider;
    private Image _letterImage;
    private void Awake()
    {
        var _transform = transform;
        _initialPosition = _transform.position;
        _initialScale = _transform.localScale;
        _letterCollider = gameObject.GetComponent<BoxCollider>();
        _letterImage = gameObject.GetComponentInChildren<Image>();
    }
    
    public void LockLetter()
    {
        _letterImage.sprite = lockImage;
        _letterCollider.enabled = false;
        isAvailable = false;
    }

    public void UnlockLetter()
    {
        _letterImage.sprite = unlockImage;
        _letterCollider.enabled = true;
        isAvailable = true;
    }

    public void OnPlaceMe()
    {
        PlaceMe(this.gameObject);
        LockLetter();
    }
    
    public void UndoLetter( int index )
    {
        if (wordIndex == index)
        {
            UnlockLetter();
            var _transform = transform;
            _transform.position = _initialPosition;
            _transform.localScale = _initialScale;
            RemoveMe(this.gameObject);
        }
    }
}
