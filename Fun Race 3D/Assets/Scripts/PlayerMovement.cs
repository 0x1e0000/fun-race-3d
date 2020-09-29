using UnityEngine;
using PathCreation;

public class PlayerMovement : MonoBehaviour
{
	static Animator anim;
	public PathCreator pathCreator;
	public float speed = 2.5f;
	public EndOfPathInstruction end;
	float distanceTravelled;
	// public Vector3[] Cameraoffset;
	public Camera camera;

	void Start()
	{
		anim = GetComponent<Animator>();
	}

	void Update()
	{
		// If the player fall
		if (transform.position.y < -0.2f)
			FindObjectOfType<GameManager>().RestartLevel();

		// While holding the screen
		if (Input.GetMouseButton(0))
		{
			// move the player forward
			distanceTravelled += speed * Time.deltaTime;
			transform.position = new Vector3(pathCreator.path.GetPointAtDistance(distanceTravelled, end).x, transform.position.y, pathCreator.path.GetPointAtDistance(distanceTravelled, end).z);

			transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, end);
			transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);

			// play running animation
			anim.SetBool("isRunning", true);
		}
		else
			// stop running animation
			anim.SetBool("isRunning", false);
	}

	// void OnCollisionEnter(Collision info)
	// {
	// 	if (info.collider.name == "Camera-1")
	// 		camera.transform.position = Cameraoffset[0];
	// 	Debug.Log("sdfads");
	// }

}
