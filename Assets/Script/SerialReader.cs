using System.IO.Ports;
using UnityEngine;

public class SerialReader : MonoBehaviour
{
    SerialPort serial = new SerialPort("COM3", 9600); // Change COM3 if needed

    public static float distanceCm = 0f;

    void Start()
    {
        serial.Open();
        serial.ReadTimeout = 100;
    }

    void Update()
    {
        try
        {
            string data = serial.ReadLine();
            if (float.TryParse(data, out float value))
            {
                distanceCm = value;
                Debug.Log(distanceCm);
            }
        }
        catch (System.Exception) { }
    }

    void OnApplicationQuit()
    {
        if (serial.IsOpen) serial.Close();
    }
}
