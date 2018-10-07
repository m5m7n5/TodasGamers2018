﻿using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class GameController : MonoBehaviour
    {
        public PlayerController PlayerController;
        public float MaxHorror;
        public SpawnController Spawner;
        public float SpawnRatio;
        public float SpawnRadius = 7;

        private static GameController _instance;
        private float _timeCounter;

        public static GameController Instance
        {
            get { return _instance; }
        }

        private void Start()
        {
            _instance = this;
            _timeCounter = 0;
        }

        private void Update()
        {
            _timeCounter += Time.deltaTime;
            if (_timeCounter >= SpawnRatio)
            {
                List<Vector3> positions = new List<Vector3>();
                Vector2 v;
                for (int i = 0; i < 7; i++)
                {
                    v = Random.insideUnitCircle * SpawnRadius;
                    positions.Add(PlayerController.transform.position + new Vector3(v.x, 1.5f, v.y));
                }

                Spawner.Spawn(2, 3, 2, positions);
                _timeCounter = 0;
            }
        }
    }
}