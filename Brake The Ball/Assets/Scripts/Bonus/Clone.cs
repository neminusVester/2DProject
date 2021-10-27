using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clone : Bonus
{
    public override void Apply()
    {
        BallCloning ballCloning = GetComponentInParent<BallCloning>();
        if (ballCloning != null)
        {
            ballCloning.CreateClone();
        }
        Destroy(gameObject);
    }

    protected override void Remove()
    {
        throw new System.NotImplementedException();
    }
}
