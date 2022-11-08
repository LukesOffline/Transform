namespace Transform
{
    using System;
    using Microsoft.Xna.Framework;

    public class Velocity3D
    {
        public Velocity3D(Transform3D transform)
        {
            this.Transform = transform ?? throw new ArgumentException(nameof(transform));
        }

        public Transform3D Transform { get; }

        public Vector3 Position { get; set; }

        public Vector3 Scale { get; set; }
        
        public Vector3 Rotation { get; set; }

        public void Update(GameTime time)
        {
            var delta = (float)time.ElapsedGameTime.TotalSeconds;
            this.Transform.Position += this.Position * delta;
            this.Transform.Scale += this.Scale * delta;
            this.Transform.Rotation += this.Rotation * delta;
        }
    }
}
