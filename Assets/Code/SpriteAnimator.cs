using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


namespace WORLDGAMEDEVELOPMENT
{
    public sealed class SpriteAnimator : IDisposable
    {
        private sealed class Animation
        {
            public AnimState Track;
            public List<Sprite> Sprites;
            public bool IsLoop;
            public float Speed = 10;
            public float Counter = 0;
            public bool Sleeps = false;


            public void Update()
            {
                if (Sleeps)
                {
                    return;
                }
                Counter += Time.deltaTime * Speed;

                if (IsLoop)
                {
                    while (Counter > Sprites.Count)
                    {
                        Counter -= Sprites.Count;
                    }
                }
                else if (Counter > Sprites.Count)
                {
                    Counter = Sprites.Count;
                    Sleeps = true;
                }
            }
        }

        private SpriteAnimatorConfig _config;

        private Dictionary<SpriteRenderer, Animation> _activeAnimations = new Dictionary<SpriteRenderer, Animation>();

        public SpriteAnimator(SpriteAnimatorConfig config)
        {
            _config = config;
        }

        public void StartAnimation(SpriteRenderer renderer, AnimState track, bool loop, float speed)
        {
            if (_activeAnimations.TryGetValue(renderer, out var animation))
            {
                animation.IsLoop = loop;
                animation.Speed = speed;
                animation.Sleeps = false;
                if (animation.Track != track)
                {
                    animation.Track = track;
                    animation.Sprites = _config.Sequences.Find(sequences => sequences.Track == track).Sprites;
                    animation.Counter = 0;
                }
            }
            else
            {
                _activeAnimations.Add(renderer, new Animation()
                {
                    Track = track,
                    Sprites = _config.Sequences.Find(sequences => sequences.Track == track).Sprites,
                    IsLoop = loop,
                    Speed = speed
                });
            }
        }


        public void StopAnimation(SpriteRenderer renderer)
        {
            if (_activeAnimations.ContainsKey(renderer))
            {
                _activeAnimations.Remove(renderer);
            }
        }

        public void Update()
        {
            foreach (var animation in _activeAnimations)
            {
                animation.Value.Update();
                if (animation.Value.Counter < animation.Value.Sprites.Count)
                {
                    animation.Key.sprite = animation.Value.Sprites[(int)animation.Value.Counter];
                }
            }
        }

        public void Dispose()
        {
            _activeAnimations.Clear();
        }
    }
}