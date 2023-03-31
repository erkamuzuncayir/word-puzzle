using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class inherits scriptable object to create customized event layer for project.
/// </summary>
[CreateAssetMenu(fileName = "Int Event", menuName = "Events/Int Event")]
public class IntEvent : DescriptionBaseSO
{
    #region Fields
    List< IntEventListener > _eventListenerList = new();
    public bool hasAnyDependent;

    public List< IntEvent > eventsDependOnThis;
    #endregion
    
    #region API
    public void Raise( int param )
    {
        for ( int i = _eventListenerList.Count - 1; i >= 0; i-- )
            _eventListenerList[ i ].OnEventRaised( param );
    }

    public void RaiseSelfAndDependents( int param )
    {
        Raise( param );

        if( hasAnyDependent && eventsDependOnThis != null )
            for( var i = 0; i < eventsDependOnThis.Count; i++ )
                eventsDependOnThis[ i ].Raise( param );
    }
    public void RegisterListener( IntEventListener listener )
    { 
        _eventListenerList.Add( listener ); 
    }

    public void UnregisterListener( IntEventListener listener )
    { 
        _eventListenerList.Remove( listener ); 
    }
    #endregion

    #region Editor Only
#if UNITY_EDITOR
#endif
    #endregion
}
