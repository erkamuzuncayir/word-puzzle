using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class inherits scriptable object to create customized event layer for project.
/// </summary>
[CreateAssetMenu(fileName = "String Event", menuName = "Events/String Event")]
public class StringEvent : DescriptionBaseSO
{
    #region Fields
    List< StringEventListener > _eventListenerList = new();
    public bool hasAnyDependent;
    public List< VoidEvent > eventsDependOnThis;
    #endregion
    
    #region API
    public void Raise( string param )
    {
        for ( int i = _eventListenerList.Count - 1; i >= 0; i-- )
            _eventListenerList[ i ].OnEventRaised( param );
    }

    public void RaiseSelfAndDependents( string param )
    {
        Raise( param );

        if( hasAnyDependent && eventsDependOnThis != null )
            for( var i = 0; i < eventsDependOnThis.Count; i++ )
                eventsDependOnThis[ i ].Raise();
    }
    public void RegisterListener( StringEventListener listener )
    { 
        _eventListenerList.Add( listener ); 
    }

    public void UnregisterListener( StringEventListener listener )
    { 
        _eventListenerList.Remove( listener ); 
    }
    #endregion

    #region Editor Only
#if UNITY_EDITOR
#endif
    #endregion
}
