using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : Unit
{
    private void Awake()
    {
        movementDirectionFromX = 1f;

        UnitsOnScene.Knights.Add(this);
    }

    private void Start()
    {
        EnemiesList = UnitsOnScene.Enemies;
    }

    protected override void Kill()
    {
        base.Kill();    
        UnitsOnScene.Knights.Remove(this);
    }
}
