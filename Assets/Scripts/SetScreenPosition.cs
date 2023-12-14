using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetScreenPosition : MonoBehaviour
{
    private Vector3 cameraPosition;
    [Range(0.1f, 3.0f)] public float acceleration = 1.0f;

    // Update is called once per frame
    void Update(){
        GameObject clickObject = GameObject.Find("ClickRecognizer");
        ClickRecognizer clickRecognizer = clickObject.GetComponent<ClickRecognizer>();

        if(!clickRecognizer.freeze_screen){
            // calculate the vector between camera position and phantom position
            cameraPosition = Camera.main.transform.position;
            Vector3 direction = cameraPosition - transform.position;
            // calculate the quaternion of the direction to turn the screen to
            Quaternion targetRotation = Quaternion.LookRotation(new Vector3 (-direction.x, 0, -direction.z) , Vector3.up);
            // turn the screen in view direction with speed proportional to the angle difference
            transform.rotation = Quaternion.RotateTowards(
                transform.rotation, targetRotation,
                Quaternion.Angle(transform.rotation, targetRotation) * acceleration * Time.deltaTime);
        }
    }
}
