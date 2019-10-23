using System;

[Flags]
public enum PlayerDirections
{
    None = 0b0000,
    Up = 0b0001,
    Down = 0b0010,
    Left = 0b0100,
    Right = 0b1000,
    UpLeft = 0b0101,
    UpRight = 0b1001,
    DownLeft = 0b0110,
    DownRight = 0b1010,
    Everything = 0b1111
}