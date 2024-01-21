using UnityEngine;

public abstract class Enemy : MonoBehaviour
{

    private string _name = "";
    
    protected void Start()
    {
        _name = SetupEnemy();
        World.Enemies.Add(this);
    }

    protected abstract string SetupEnemy();

    public string GetName()
    {
        return _name;
    }
}