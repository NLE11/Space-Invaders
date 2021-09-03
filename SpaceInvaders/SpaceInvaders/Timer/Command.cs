using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract public class Command
    {
        abstract public void Execute(float deltaTime);
    }
}
