using Assets.Scripts.AbstractClasses;
using UnityEngine;

namespace Assets.Scripts.Brains
{
    public class GhostBrain : AbstractBrain
    {
        public GhostBrain(GameObject entity)
        {
            Entity = entity;
        }

        public override Vector2 Move()
        {
            Vector3 playerPosition = GameController.Instance.PlayerController.gameObject.transform.position;
            return (new Vector2(playerPosition.x, playerPosition.z) -
                    new Vector2(Entity.transform.position.x, Entity.transform.position.z))
                .normalized;
        }

        public override void ThinkOnCastAbility()
        {
        }
    }
}