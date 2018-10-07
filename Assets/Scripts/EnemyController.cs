using Assets.Scripts;
using Assets.Scripts.AbstractClasses;
using Assets.Scripts.Brains;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public EntityController EntityController;

    public AnimationStatus Status = AnimationStatus.Spawning;
    public GameObject ParticleSystem;
    public AbstractBrain Brain;

    // Use this for initialization
    void Start()
    {
        Brain = new GhostBrain(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (Status != AnimationStatus.Spawning && Status != AnimationStatus.Dying) //||
        {
            EntityController.Move(Brain.Move().x, Brain.Move().y);
            Brain.ThinkOnCastAbility();
        }

/*
        if (Input.GetKeyDown(KeyCode.E))
        {
            EntityController.SetPhysics(false);
            ParticleSystem.SetActive(true);
            Status = AnimationStatus.Dying;
        }
*/
    }
}