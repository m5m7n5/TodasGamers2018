using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class UICanvasController : MonoBehaviour
{
    public Slider Hope;
    public Slider Horror;
    public GameObject PickGiftGameObject;
    public GameObject GiveGiftGameObject;

    public Text GiftsDeliveredTextObject;
    public Text CurrentGiftsTextObject;

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
        Horror.value = 0;
        GiftsDeliveredTextObject.text = "0";
        CurrentGiftsTextObject.text = "0";
    }

    public void ShowPickGiftMessage(Vector3 position)
    {
        PickGiftGameObject.SetActive(true);
        PickGiftGameObject.transform.position = position;
    }

    public void ShowGiveGiftMessage(Vector3 position)
    {
        GiveGiftGameObject.SetActive(true);
        GiveGiftGameObject.transform.position = position;
    }

    public void DeactivatePickGiftMessage()
    {
        PickGiftGameObject.SetActive(false);
    }

    public void DeactivateGiveGiftMessage()
    {
        GiveGiftGameObject.SetActive(false);
    }

    public void GiftsDelivered(int value)
    {
        GiftsDeliveredTextObject.text = "" + value;
    }

    public void CurrentGifts(int value)
    {
        CurrentGiftsTextObject.text = "" + value;
    }
}