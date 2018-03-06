using engenious;
using LotaRuntime.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotaRuntime
{
    internal class LotaGame : Game
    {
        internal CameraComponent Camera { get; }
        public LotaGame()
        {
            Window.ClientSize = new Size(500, 300);
            Components.Add(Camera = new CameraComponent(this));
        }
        protected override void Initialize()
        {
            base.Initialize();
        }
        protected override void OnExiting(object sender, EventArgs e)
        {
            base.OnExiting(sender, e);
        }
    }
}
