using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAI : MonoBehaviour {


    // Variables

    // Determines move speed of the AI
    public float walkSpeed = 3f;
    // Determines rotation speed of the AI
    public float rotateSpeed = 100f;

    // Determines if animal is wandering around or not
    // I have decided to serialize this field so I can check whether or not the script is affecting the AI at any time
    [SerializeField] private bool isWandering = false;
    // Determines if animal is rotating left or not
    private bool isRotatingLeft = false;
    // Determines if animal is rotating right or not
    private bool isRotatingRight = false;
    // Determines if animal is walking or not
    private bool isWalking = false;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (isWandering == false)
        {
            // Calls the coroutine 'Wander'
            StartCoroutine(Wander());
        }

        // The following IF statements make the AI rotate
        if (isRotatingRight == true)
        {
            // We use Time.deltaTime so the AI is consistent accross all framerates
            transform.Rotate(transform.up * Time.deltaTime * rotateSpeed);
        }

        if (isRotatingLeft == true)
        {
            // In this instance I use -moveSpeed to turn the AI the other way (there is no transform.down)
            transform.Rotate(transform.up * Time.deltaTime * -rotateSpeed);
        }


        // Now for the walking code
        if (isWalking == true)
        {
            transform.position += transform.forward * walkSpeed * Time.deltaTime;
        }

       
    }

    





    IEnumerator Wander()
    {
        // rotTime is the amount of time the AI will be rotating, NOT the amount of time inbetween
        int rotTime = Random.Range(1, 3);
        // rotateWait IS the amount of time inbetween rotations
        int rotateWait = Random.Range(1, 3);
        // rotateLorR randomises which direction the AI turns
        int rotateLorR = Random.Range(0, 3);
        // walkWait is the time between checking the coroutine
        int walkWait = Random.Range(1, 3);
        // walkTime is the amount of time the AI walks for
        int walkTime = Random.Range(1, 4);

        isWandering = true;

        // We don't want the coroutine to be called every single frame, so we wait
        // This value is set above
        yield return new WaitForSeconds(walkWait);
        isWalking = true;

        // After the following timer finishes, we communicate that the AI is no longer walking
        yield return new WaitForSeconds(walkTime);
        isWalking = false;

        // Now the AI needs to wait after it has finished walking
        yield return new WaitForSeconds(rotateWait);

        // This IF statement 
        if (rotateLorR == 1)
        {
            isRotatingRight = true;
            // The following two lines makes sure that the AI stops rotating altogether (rather than always left or right)
            yield return new WaitForSeconds(rotTime);
            isRotatingRight = false;
        }

        // Now I use the same IF statement for rotating left
        if (rotateLorR == 2)
        {
            isRotatingLeft = true;
            yield return new WaitForSeconds(rotTime);
            isRotatingLeft = false;
        }

        isWandering = false;

    }


}
