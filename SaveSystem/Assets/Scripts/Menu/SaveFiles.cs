using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveFiles : MonoBehaviour
{
    public void CloseSaveFilesMenu()
    {
        SceneLoader.Instance.UnloadCurrentScene();
    }
}
