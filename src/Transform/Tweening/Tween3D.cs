﻿namespace Transform
{
    using System;
    using Microsoft.Xna.Framework;

    public class Tween3D : ITween
    {
        public Tween3D(TimeSpan duration, Transform3D transform, Transform3D to, Ease ease)
            : this(duration, transform, new Transform3D()
            {
                Position = transform.Position,
                Rotation = transform.Rotation,
                Scale = transform.Scale,
            }, to, EaseFunctions.Get(ease))
        {
        }

        public Tween3D(TimeSpan duration, Transform3D transform, Transform3D from, Transform3D to, Ease ease)
            : this(duration, transform, from, to, EaseFunctions.Get(ease))
        {
        }

        public Tween3D(TimeSpan duration, Transform3D transform, Transform3D from, Transform3D to, Func<float, float> ease)
        {
            this.Duration = duration;
            this.Transform = transform;
            this.From = from;
            this.To = to;
            this.Ease = Ease;
            this.easeFunction = ease;
        }

        private Func<float, float> easeFunction;

        public TimeSpan Time { get; private set; }

        public TimeSpan Duration { get; }

        public Transform3D Transform { get; }

        public Transform3D From { get; }

        public Transform3D To { get; }

        public bool IsRevert { get; }

        public Ease Ease { get; }

        public bool IsFinished { get; private set; }

        public void Reset()
        {
            this.IsFinished = false;
            this.Time = TimeSpan.Zero;

            Transform.Position = From.Position;
            Transform.Scale = From.Scale;
            Transform.Rotation = From.Rotation;
        }

        public bool Update(GameTime time)
        {
            if (!this.IsFinished)
            {
                var delta = (float)time.ElapsedGameTime.TotalSeconds;

                this.Time += time.ElapsedGameTime;

                var t = Math.Max(0, Math.Min(1, (float)(this.Time.TotalMilliseconds / this.Duration.TotalMilliseconds)));

                var amount = easeFunction(t);

                Transform.Position = From.Position + (To.Position - From.Position) * amount;
                Transform.Scale = From.Scale + (To.Scale - From.Scale) * amount;
                Transform.Rotation = From.Rotation + (To.Rotation - From.Rotation) * amount;

                this.IsFinished = (t >= 1);
            }

            return this.IsFinished;
        }
    }
}
