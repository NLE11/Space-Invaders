using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract public class CollisionVisitor : DLink
    {
        public virtual void VisitRoot(AlienRoot a_root)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by AlienRoot not implemented");
            Debug.Assert(false);
        }
        public virtual void VisitGrid(AlienGrid a_grid)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by AlienGrid not implemented");
            Debug.Assert(false);
        }

        public virtual void VisitColumn(AlienColumn a_column)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by AlienColumn not implemented");
            Debug.Assert(false);
        }

        public virtual void VisitSquid1(Squid1 squid1)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by Squid1 not implemented");
            Debug.Assert(false);
        }

        public virtual void VisitSquid2(Squid2 squid2)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by Squid2 not implemented");
            Debug.Assert(false);
        }

        public virtual void VisitCrab1(Crab1 crab1)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by Crab1 not implemented");
            Debug.Assert(false);
        }

        public virtual void VisitCrab2(Crab2 b)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by Crab2 not implemented");
            Debug.Assert(false);
        }

        public virtual void VisitOctopus1(Octopus1 b)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by Octopus1 not implemented");
            Debug.Assert(false);
        }

        public virtual void VisitOctopus2(Octopus2 b)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by Octopus2 not implemented");
            Debug.Assert(false);
        }



        public virtual void VisitMissile(Missile missile)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by Missile not implemented");
            Debug.Assert(false);
        }

        public virtual void VisitMissileGroup(MissileGroup missile_group)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by MissileGroup not implemented");
            Debug.Assert(false);
        }

        public virtual void VisitNullGameObject(GameObjectNull null_object)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by NullGameObject not implemented");
            Debug.Assert(false);
        }



        public virtual void VisitWallGroup(WallGroup w)
        {
            Debug.WriteLine("Visit by WallGroup not implemented");
            Debug.Assert(false);
        }
        public virtual void VisitWallRight(WallRight w)
        {
            Debug.WriteLine("Visit by WallRight not implemented");
            Debug.Assert(false);
        }
        public virtual void VisitWallLeft(WallLeft w)
        {
            Debug.WriteLine("Visit by WallLeft not implemented");
            Debug.Assert(false);
        }
        public virtual void VisitWallTop(WallTop w)
        {
            Debug.WriteLine("Visit by WallTop not implemented");
            Debug.Assert(false);
        }
        public virtual void VisitWallBottom(WallBottom w)
        {
            Debug.WriteLine("Visit by WallBottom not implemented");
            Debug.Assert(false);
        }
        public virtual void VisitWallMiddle(WallMiddle w)
        {
            Debug.WriteLine("Visit by WallMiddle not implemented");
            Debug.Assert(false);
        }



        public virtual void VisitShieldRoot(ShieldRoot shieldroot)
        {
            Debug.WriteLine("Visit by ShieldRoot not implemented");
            Debug.Assert(false);
        }
        public virtual void VisitShieldBrick(ShieldBrick shieldbrick)
        {
            Debug.WriteLine("Visit by ShieldBrick not implemented");
            Debug.Assert(false);
        }
        public virtual void VisitShieldColumn(ShieldColumn shieldcolumn)
        {
            Debug.WriteLine("Visit by ShieldColumn not implemented");
            Debug.Assert(false);
        }



        public virtual void VisitShipRoot(ShipRoot shiproot)
        {
            Debug.WriteLine("Visit by ShipRoot not implemented");
            Debug.Assert(false);
        }
        public virtual void VisitShip(Ship ship)
        {
            Debug.WriteLine("Visit by Ship not implemented");
            Debug.Assert(false);
        }



        public virtual void VisitBumperRoot(BumperRoot b)
        {
            Debug.WriteLine("Visit by BumperRoot not implemented");
            Debug.Assert(false);
        }
        public virtual void VisitBumperLeft(BumperLeft b)
        {
            Debug.WriteLine("Visit by BumperLeft not implemented");
            Debug.Assert(false);
        }
        public virtual void VisitBumperRight(BumperRight b)
        {
            Debug.WriteLine("Visit by BumperRight not implemented");
            Debug.Assert(false);
        }



        public virtual void VisitBombRoot(BombRoot b)
        {
            Debug.WriteLine("Visit by BombRoot not implemented");
            Debug.Assert(false);
        }
        public virtual void VisitBomb(Bomb b)
        {
            Debug.WriteLine("Visit by Bomb not implemented");
            Debug.Assert(false);
        }



        public virtual void VisitUFORoot(UFORoot u)
        {
            Debug.WriteLine("Visit by UFORoot not implemented");
            Debug.Assert(false);
        }
        public virtual void VisitUFO(UFO u)
        {
            Debug.WriteLine("Visit by UFO not implemented");
            Debug.Assert(false);
        }
        public virtual void VisitUFOSelect(UFOSelect u)
        {
            Debug.WriteLine("Visit by UFOSelect not implemented");
            Debug.Assert(false);
        }


        abstract public void Accept(CollisionVisitor other);
    }

}
