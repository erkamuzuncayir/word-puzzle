using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharedListBase <TSharedListType> : ScriptableObject
{
    #region Fields
    public List<TSharedListType> sharedList;
    #endregion

    #region Editor Only
#if UNITY_EDITOR
#endif
    #endregion
}
