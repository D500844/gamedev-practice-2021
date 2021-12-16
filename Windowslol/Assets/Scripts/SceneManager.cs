using System.Collections;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public void ChangeToScene ( int sceneToChangeTo)
    {
        Application.LoadLevel(sceneToChangeTo);
    }
}