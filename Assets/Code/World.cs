using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using Object = UnityEngine.Object;

public class World : MonoBehaviour
{
    public static int Speed = 2;

    public Object timeObject;
    private TextMeshPro timeText;
    public static DateTime Time;

    public static List<Enemy> Enemies = new List<Enemy>();
    public static List<Location> Locations = new List<Location>();

    private void Start()
    {
        timeText = timeObject.GameObject().gameObject.transform.GetComponent<TextMeshPro>();
        DateTime today = DateTime.Now;
        Time = new DateTime(today.Year, today.Month, today.Day, 6, 0, 0);
    }

    private void Update()
    {
        timeText.SetText(Time.ToString("HH:mm"));
        Time = Time.AddSeconds(1 * Speed);

        if (Time.ToString("HH:mm").Equals("00:00"))
        {
            BT_Entity.Work.Work2Do = 50;
        }
    }
}