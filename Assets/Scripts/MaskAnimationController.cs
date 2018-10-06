using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class MaskAnimationController : MonoBehaviour
    {
        //1st spawn
        //2nd die
        //3rd iddle
        //next 2 ability
        //next 4th movement directions
        public List<AnimationSprites> AnimationSpriteses;

        public float ImagesPerSecond = 1;

        public EnemyController EnemyController;
        public SpriteMask Mask;

        private float _timeCounter;
        private int _imageCounter;
        private int _currentAnimation;

        private bool _playing;

        private void Start()
        {
            Reset(0);
        }

        private void Update()
        {
            if (_playing)
            {
                _timeCounter += Time.deltaTime;

                if (_timeCounter >= 1 / ImagesPerSecond)
                {
                    if (_imageCounter < AnimationSpriteses[_currentAnimation].Sprites.Count)
                    {
                        Mask.sprite = AnimationSpriteses[_currentAnimation].Sprites[_imageCounter];
                    }
                    else
                    {
                        EnemyController.Status = AnimationStatus.Moving;
                        _playing = false;
                    }

                    _timeCounter = 0;
                    _imageCounter++;
                }
            }
        }

        public void Reset(int animationToPlay)
        {
            _currentAnimation = animationToPlay;
            _timeCounter = 1 / ImagesPerSecond + 1;
            _imageCounter = 0;
            _playing = true;
        }
    }

    [Serializable]
    public struct AnimationSprites
    {
        public List<Sprite> Sprites;
    }
    
}