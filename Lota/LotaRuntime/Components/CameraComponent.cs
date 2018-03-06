using System;
using engenious;
using engenious.Graphics;
using engenious.Input;
namespace LotaRuntime.Components
{
    internal class CameraComponent : DrawableGameComponent
    {
        public Matrix Projection { get; private set; }
        public Matrix View { get; private set; }
        public CameraComponent(Game game) : base(game)
        {
            game.Resized += HandleResized;
        }
        private void HandleResized(object sender, EventArgs e)
        {
            Projection = Matrix.CreatePerspectiveFieldOfView(60f, GraphicsDevice.Viewport.AspectRatio, 0.1f, 100);
        }

        public override void Update(GameTime gameTime)
        {
            Vector2 horizontalmovement = new Vector2();
            if (Keyboard.GetState().IsKeyDown(Keys.W)) // -z
                horizontalmovement += new Vector2(-1, 0);
            if (Keyboard.GetState().IsKeyDown(Keys.S)) // z
                horizontalmovement += new Vector2(-1, 0);
            if (Keyboard.GetState().IsKeyDown(Keys.A)) // x
                horizontalmovement += new Vector2(-1, 0);
            if (Keyboard.GetState().IsKeyDown(Keys.D)) // -x
                horizontalmovement += new Vector2(-1, 0);

            View = Matrix.CreateLookAt(new Vector3(0f, 0f, 1f), -Vector3.UnitZ, Vector3.UnitY);
        }

#if DEBUG
        private VertexBuffer vertices;
        private IndexBuffer indices;
        private BasicEffect effect;
        public override void Initialize()
        {
            base.Initialize();
            vertices = new VertexBuffer(GraphicsDevice, VertexPositionColor.VertexDeclaration, 4, BufferUsageHint.StaticDraw);
            vertices.SetData(new VertexPositionColor[4]
            {
                new VertexPositionColor(new Vector3(-1f, -1f, 0f), Color.Red),
                new VertexPositionColor(new Vector3(1f, -1f, 0f), Color.Blue),
                new VertexPositionColor(new Vector3(1f, 1f, 0f), Color.Green),
                new VertexPositionColor(new Vector3(-1f, 1f, 0f), Color.Yellow),
            });
            effect = new BasicEffect(GraphicsDevice)
            {
                VertexColorEnabled = true,
            };
        }
        public override void Draw(GameTime gameTime)
        {
            indices = new IndexBuffer(GraphicsDevice, typeof(ushort), 6, BufferUsageHint.StaticDraw);
            indices.SetData(new ushort[] { 0, 2, 3, 0, 1, 2});
            GraphicsDevice.Clear(ClearBufferMask.ColorBufferBit);
            GraphicsDevice.RasterizerState = new RasterizerState()
            {
                CullMode = CullMode.None,
                FillMode = PolygonMode.Fill,
            };
            GraphicsDevice.VertexBuffer = vertices;
            GraphicsDevice.IndexBuffer = indices;
            effect.Projection = Projection;
            effect.View = View;
            foreach(EffectPass pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();
                GraphicsDevice.DrawIndexedPrimitives(PrimitiveType.Triangles, 0, 0, 4, 0, 2);
                //GraphicsDevice.DrawPrimitives(PrimitiveType.TriangleFan, 0,3);
            }
        }
#endif
    }
}
