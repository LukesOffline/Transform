namespace Transform
{
    using System;
    using Microsoft.Xna.Framework;

    public class Acceleration3D
    {
        public Acceleration3D(Velocity3D velocity)
        {
            this.Velocity = velocity ?? throw new ArgumentException(nameof(velocity));
        }

        public Transform3D Transform => this.Velocity.Transform;

        public Velocity3D Velocity { get; }

        public Vector3 Position { get; set; }

        public Vector3 Scale { get; set; }

        public float Rotation { get; set; }

        public void Update(GameTime time)
        {
            var delta = (float)time.ElapsedGameTime.TotalSeconds;
            this.Velocity.Position += this.Position * delta;
            this.Velocity.Scale += this.Scale * delta;
            this.Velocity.Rotation += this.Rotation * delta;

            this.Velocity.Update(time);
        }
    }
}