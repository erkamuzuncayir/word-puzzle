using UnityEngine;

public class AddGameObjectToRuntimeSet : MonoBehaviour
{
#region Fields
    public GameObjectRuntimeSet gameObjectRuntimeSet;
#endregion

#region Unity API
    void OnEnable()
    {
        gameObjectRuntimeSet.AddToList( this.gameObject );
    }
    void OnDisable()
    {
        gameObjectRuntimeSet.RemoveFromList( this.gameObject );
    }
#endregion
}
