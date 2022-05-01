using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBullet : PlayerBullet
{
    // Start is called before the first frame update
    protected override void Start()
    {
        speed = 10;
        hp = 3;
        base.Start();
    }

    // Update is called once per frame
    //void Update()
    //{

    //}
}
