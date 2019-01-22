﻿namespace CodingArena.Player.Battlefield
{
    public interface IBattlefield
    {
        IBattlefieldSize Size { get; }
        IBattlefieldPlace this[int x, int y] { get; }
        IBattlefieldPlace this[IBattlefieldObject battlefieldObject] { get; }
        IBattlefieldPlace this[IBot bot] { get; }
    }
}