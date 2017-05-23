using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Controls quit menu button.
public class quitOnClick : MonoBehaviour {
    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
