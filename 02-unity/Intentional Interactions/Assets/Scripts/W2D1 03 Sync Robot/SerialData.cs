﻿[System.Serializable]
public struct SerialDataRead
{
    public float A0;
    public float A1;
    public float A2;
    public float A3;
    public float A4;
    public float A5;

    public int D2;
    public int D4;
    public int D7;
}

[System.Serializable]
public struct SerialDataWrite
{
    public int baseAngle;
    public int jointAngle;
}

