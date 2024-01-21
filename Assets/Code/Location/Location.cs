using System;
using UnityEngine;

public enum Locations
{
        Cinema,
        Eat,
        Games,
        Sleep,
        Work,
        Friends
}

public abstract class Location : MonoBehaviour
{
        public Locations Typ;
        protected void Start()
        {
                Typ = SetupLocation();
                World.Locations.Add(this);
        }

        protected abstract Locations SetupLocation();
}