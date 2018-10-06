using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class UICanvasController : MonoBehaviour
{
    public Slider Hope;
    public Slider Horror;

    public static UICanvasController Instance
    {
        get { return _instance; }
    }

    private static UICanvasController _instance;

    // Use this for initialization
    void Start()
    {
        _instance = this;
        Hope.maxValue = GameSettingsManager.LevelStartingHope;
        Hope.value = GameSettingsManager.LevelStartingHope;
        Horror.maxValue = GameSettingsManager.LevelMaxHorror;
        Horror.value = GameSettingsManager.LevelMaxHorror;
    }
}