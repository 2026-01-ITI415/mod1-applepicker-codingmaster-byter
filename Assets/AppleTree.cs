using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;

public class AppleTree : MonoBehaviour
 {
    [Header("Inscribed")]
                                                  // a
    // Prefab for instantiating apples
    public GameObject   applePrefab;
 
     // Speed at which the AppleTree moves
     public float        speed = 1f;

    // Distance where AppleTree turns around
    public float        leftAndRightEdge = 10f;

    // Chance that the AppleTree will change directions
  public float        changeDirChance = 0.1f;

    // Seconds between Apples instantiations
    public float        appleDropDelay = 1f;

 public static float     bottomY = -20f;


     void Start () {
          Invoke( "DropApple", 2f );                                        // a
     
         // Start dropping apples                                           // b
    }
 void DropApple() {                                                    // b
       GameObject apple = Instantiate<GameObject>( applePrefab );        // c
         apple.transform.position = transform.position;                    // d
         Invoke( "DropApple", appleDropDelay );                            // e
     }
   void Update()
{
    // Move AppleTree
    Vector3 pos = transform.position;
    pos.x += speed * Time.deltaTime;
    transform.position = pos;

    // Change direction at edges
    if (pos.x < -leftAndRightEdge)
    {
        speed = Mathf.Abs(speed);
    }
    else if (pos.x > leftAndRightEdge)
    {
        speed = -Mathf.Abs(speed);
    }

    // Destroy if below bottom
    if (transform.position.y < bottomY)
    {
        Destroy(this.gameObject);

        ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();
        apScript.AppleMissed();
    }
}

     void FixedUpdate() {                                                 // b
        // Random direction changes are now time-based due to FixedUpdate()
        if ( Random.value < changeDirChance ) {                          // b
             speed *= -1; // Change direction 
         }
     }
}