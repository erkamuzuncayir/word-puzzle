using UnityEngine;
using UnityEngine.EventSystems;

public class LevelInfoAnnouncer : MonoBehaviour, IPointerClickHandler
{
    public IntEvent levelIndex;
    public VoidEvent levelStart;
    public void OnPointerClick(PointerEventData eventData)
    {
//        levelStart.Raise();
        var handlerScript = eventData.pointerPressRaycast.gameObject.GetComponentInParent<UILevelDataHandler>();
        levelIndex.Raise(handlerScript.levelData.levelIndex);
    }
}
