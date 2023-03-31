using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// This class listens to the StringEvent scriptable object.
/// When the event raised, it can call the methods assigned to it with a boolean parameter.
/// </summary>
public class StringEventListener : MonoBehaviour
{
    #region Fields
    public StringEvent gameEvent;
    public UnityEvent<string> response;
    #endregion

    #region Unity API
    void OnEnable()
    {
        gameEvent.RegisterListener( this );
    }

    void OnDisable()
    {
        gameEvent.UnregisterListener( this );
    }
    #endregion

    #region API
    public void OnEventRaised( string param )
    {
        response.Invoke( param );
    }
    #endregion
}
