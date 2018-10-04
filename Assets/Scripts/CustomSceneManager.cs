using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomSceneManager : MonoBehaviour
{
    public void NavigateToScene(String scenename)
    {
        SceneManager.LoadScene(scenename);
    }
}