using UnityEngine;

namespace Assets.Scripts
{
    public class GameController : MonoBehaviour
    {
        public PlayerController PlayerController;
        public float MaxHorror;

        private static GameController _instance;

        public static GameController Instance
        {
            get { return _instance; }
        }

        private void Start()
        {
            _instance = this;
        }
    }
}