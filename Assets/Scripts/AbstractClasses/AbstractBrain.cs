using UnityEngine;

namespace Assets.Scripts.AbstractClasses
{
    public abstract class AbstractBrain
    {
        protected GameObject Entity;
        
        public abstract Vector2 Move();

        public abstract void ThinkOnCastAbility();
    }
}