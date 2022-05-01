using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    protected Rigidbody rb;

    protected float speed = 1;
    public int hp { get; protected set; }

    GameManager gm;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        var direction = Input.GetAxis("Horizontal");
        Move(direction);
    }

    // ABSTRACTION
    protected virtual void Move(float direction) {
        rb.velocity = new Vector3(speed * direction, 0, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            GetHit();
        }
    }

    // ABSTRACTION
    private void GetHit()
    {
        --hp;

        if(hp <= 0 )
        {
            Debug.Log("Gameover");
            gm.GameOver();

        }

    }

}
