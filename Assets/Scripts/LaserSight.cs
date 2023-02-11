using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSight : MonoBehaviour
{
    // Start is called before the first frame update
    public LineRenderer laserLineRenderer;
    public float laserWidth = 0.1f;
    public float laserMaxLength = 5f;
 
    void Start() {
        Vector3[] initLaserPositions = new Vector3[ 2 ] { Vector3.zero, Vector3.zero };
        laserLineRenderer.SetPositions( initLaserPositions );
        laserLineRenderer.SetWidth( laserWidth, laserWidth );
        laserLineRenderer.startColor = Color.red;
        laserLineRenderer.endColor = Color.red;
    }
 
    void Update() 
    {
        if( Input.GetKey( KeyCode.RightShift ) ) {
            ShootLaserFromTargetPosition( transform.position, transform.right, laserMaxLength );    
            laserLineRenderer.enabled = true;
        }
        else {
            laserLineRenderer.enabled = false;
        }
    }
 
    void ShootLaserFromTargetPosition( Vector3 targetPosition, Vector3 direction, float length )
    {
        Ray ray = new Ray( targetPosition, direction );
        RaycastHit raycastHit;
        Vector3 endPosition = targetPosition + ( length * direction );
 
        if( Physics.Raycast( ray, out raycastHit, length ) ) {
            endPosition = raycastHit.point;
        }
 
        laserLineRenderer.SetPosition( 0, targetPosition );
        laserLineRenderer.SetPosition( 1, endPosition );
    }
}
