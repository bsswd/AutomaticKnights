using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Unit
{
    private void Awake()
    {
        movementDirectionFromX = -1f;
            
        UnitsOnScene.Enemies.Add(this);
    }

    private void Start()
    {
        EnemiesList = UnitsOnScene.Knights;
    }

    protected override void Kill()
    {
        base.Kill();
        UnitsOnScene.Enemies.Remove(this);
    }
}
