using UnityEngine;
using System.Collections;

public class AzarashiController : MonoBehaviour
{

    Rigidbody2D rb2d;
    Animator animator;
    float angle;
    bool isDead;
    
    public float maxHeight;
    public float flapVelocity;
    public float relativeVelocityX;
    public GameObject sprite;
    
    public bool IsDead ()
    {
        return isDead;
    }
    
    void Awake ()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = sprite.GetComponent<Animator>();           
    }
    
    void Update ()
    {
        if (Input.GetButtonDown("Fire1") && transform.position.y < maxHeight)
        {
            Flap();
        }
        
        ApplyAngle();
        
        animator.SetBool("flap", angle >= 0.0f);
    }
    
    public void Flap ()
    {
        // If the azarashi is dead, he cannot flap
        if (isDead) return;
        
        // If the game is not started, the azarashi cannot flap 
        if (rb2d.isKinematic) return;
        
        rb2d.velocity = new Vector2(0.0f, flapVelocity);
    }
    
    // Determine the angle of the azarashi
    void ApplyAngle () {
        float targetAngle;
        
        if (isDead)
        {
            targetAngle = -90.0f;
        }
        else
        {
            targetAngle = Mathf.Atan2(rb2d.velocity.y, relativeVelocityX) * Mathf.Rad2Deg;
        }
        angle = Mathf.Lerp(angle, targetAngle, Time.deltaTime * 10.0f);
        sprite.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, angle);
    }
    
    // When the azarashi collides with something (ground or blocks)
    void OnCollisionEnter2D (Collision2D collision)
    {
        if (isDead) return;
        
        Camera.main.SendMessage("Clash");
        isDead = true;
    }
    
    // Switch on and off of RigidBody
    public void SetSteerActive (bool active)
    {
        rb2d.isKinematic = !active;
    }
    
}
