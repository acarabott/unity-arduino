using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInstallation : MonoBehaviour
{
    public SerialHandler serial;
    public SerialDataWrite data;

    public static int SIZE_1 = 13;
    public static int SIZE_2 = 10;
    public static int SIZE_3 = 5;

    public int[] baseAngles1 = new int[SIZE_1];

    public int[] jointAngles1 = new int[SIZE_1];

    public int[] led1 = new int[SIZE_1];

    public int[] baseAngles2 = new int[SIZE_2];

    public int[] jointAngles2 = new int[SIZE_2];

    public int[] led2 = new int[SIZE_2];

    public int[] baseAngles3 = new int[SIZE_3];

    public int[] jointAngles3 = new int[SIZE_3];

    public int[] led3 = new int[SIZE_3];


    // Start is called before the first frame update
    void Awake() {
        serial = gameObject.GetComponent<SerialHandler>();
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // for (int i = 0; i < SIZE_1; i++)
        // {
            int i = 1;
            // data.group = 1;
            // data.id = i.ToString().PadLeft(2, '0');
            // data.baseAngle = baseAngles1[i].ToString().PadLeft(3, '0');
            // data.jointAngle = jointAngles1[i].ToString().PadLeft(3, '0');;
            // data.led = led1[i].ToString().PadLeft(3, '0');;
            // serial.WriteData(data);
        // }

        // for (int i = 0; i < SIZE_2; i++)
        // {
        //     data.group = 2;
        //     data.id = i.ToString().PadLeft(2, '0');
        //     data.baseAngle = baseAngles2[i].ToString().PadLeft(3, '0');
        //     data.jointAngle = jointAngles2[i].ToString().PadLeft(3, '0');;
        //     data.led = led2[i].ToString().PadLeft(3, '0');;
        //     serial.WriteData(data);
        // }

        // for (int i = 0; i < SIZE_3; i++)
        // {
        //     data.group = 3;
        //     data.id = i.ToString().PadLeft(2, '0');
        //     data.baseAngle = baseAngles3[i].ToString().PadLeft(3, '0');
        //     data.jointAngle = jointAngles3[i].ToString().PadLeft(3, '0');;
        //     data.led = led3[i].ToString().PadLeft(3, '0');;
        //     serial.WriteData(data);
        // }

    }
}
