using Assets.Scripts;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public EntityController EntityController;

    private float _hope;
    private float _horror;

    public float Hope
    {
        get { return _hope; }
        set
        {
            UICanvasController.Instance.Hope.value = value;
            _hope = value;
        }
    }

    public float Horror
    {
        get { return _horror; }
        set
        {
            UICanvasController.Instance.Horror.value = value;
            _horror = value;
        }
    }

    // Use this for initialization
    void Start()
    {
        _hope = GameSettingsManager.LevelStartingHope;
        _horror = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movementVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        movementVector.Normalize();
        EntityController.Move(movementVector.x, movementVector.y);
        Hope = _hope - Time.deltaTime * (1f + 1.0f / GameSettingsManager.LevelMaxHorror);
    }
}