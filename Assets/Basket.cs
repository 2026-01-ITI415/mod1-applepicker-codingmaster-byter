 using System.Collections;
using System.Collections.Generic;
 using UnityEngine;

  public class Basket : MonoBehaviour {
     public ScoreCounter scoreCounter;                                    // a

    void Start() {
         // Find a GameObject named ScoreCounter in the Scene Hierarchy
         GameObject scoreGO = GameObject.Find( "ScoreCounter" );         // b
        // Get the ScoreCounter (Script) component of scoreGO
        scoreCounter = scoreGO.GetComponent<ScoreCounter>();            // c
    }

    void Update() {  // Get the current mouse position in 2D screen space
    Vector3 mousePos2D = Input.mousePosition;

    // Set the Z coordinate to distance from camera
    mousePos2D.z = -Camera.main.transform.position.z;

    // Convert to 3D world position
    Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

    // Move the basket horizontally
    Vector3 pos = transform.position;
    pos.x = mousePos3D.x;
    transform.position = pos;
}


    void OnCollisionEnter( Collision coll ) {
        // Find out what hit this basket
         GameObject collidedWith = coll.gameObject;
         if ( collidedWith.CompareTag("Apple") ) {
             Destroy( collidedWith );
             // Increase the score
             scoreCounter.score += 100;  
              HighScore.TRY_SET_HIGH_SCORE( scoreCounter.score );                                       // d
         }
     }
 }