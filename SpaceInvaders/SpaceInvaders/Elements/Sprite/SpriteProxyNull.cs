using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class SpriteProxyNull : SpriteProxy
    {
        public SpriteProxyNull()
            : base(SpriteProxy.Name.Proxy_null)
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
