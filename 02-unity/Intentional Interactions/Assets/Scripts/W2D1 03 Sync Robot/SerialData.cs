[System.Serializable]
public struct SerialDataRead
{
    public string msg;
    public string state;
    // public float A0;
    // public float A1;
    // public float A2;
    // public float A3;
    // public float A4;
    // public float A5;

    // public int D2;
    // public int D4;
    // public int D7;
}

[System.Serializable]
public struct SerialDataWrite
{
    // public int group;
    // public string id;
    public int baseAngle;
    public int jointAngle;
    public int led;
    // public int test;
    // public int[] jointAngles1;
    // public int[] led1;


    // public int[] baseAngles2;
    // public int[] jointAngles2;
    // public int[] led2;

    // public int[] baseAngles3;
    // public int[] jointAngles3;
    // public int[] led3;
}
