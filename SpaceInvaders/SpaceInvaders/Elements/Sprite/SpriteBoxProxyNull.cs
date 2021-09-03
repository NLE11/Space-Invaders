using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class SpriteBoxProxyNull : SpriteBoxProxy
    {
        public SpriteBoxProxyNull()
            : base(SpriteBoxProxy.Name.ProxyBox_null)
        {
        }

        public override void Render()
        {
            // do nothing
        }

        public override void Update()
        {
            // do nothing
        }
    }
}
