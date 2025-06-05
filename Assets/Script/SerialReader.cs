using System.IO.Ports;
using UnityEngine;

public class SerialReader : MonoBehaviour
{
    SerialPort serial = new SerialPort("COM3", 9600); // Ganti COM jika perlu
    public static float distanceCm = 0f;

    public static SerialReader instance; // akses global

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        serial.Open();
        serial.ReadTimeout = 100;
    }

    public void Mati()
    {
        serial.WriteLine("lose\n");  // Nyalakan buzzer
    }

    public void Score()
    {
        serial.WriteLine("score\n"); // Nyalakan LED
    }
    public void Reset()
    {
        serial.WriteLine("reset\n");
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
