using UnityEngine;

public class SwipeInput : MonoBehaviour
{
	public const float MAX_SWIPE_TIME = 0.5f;
	public const float MIN_SWIPE_DISTANCE = 0.17f;
	public static bool swipedRight = false;
	public static bool swipedLeft = false;
	public static bool swipedUp = false;
	public static bool swipedDown = false;
	public static bool swipedRightSide = false;
	public static bool swipedLeftSide = false;
	public static bool ballRadiusReached = false;

	public static Vector2 deltaVector;

	public Camera camera;
	public bool debugWithArrowKeys = true;

	Vector2 startPos;
	float startTime;

	public void Update()
	{
			
		swipedRight = false;
		swipedLeft = false;
		swipedUp = false;
		swipedDown = false;
		swipedLeftSide = false;
		swipedRightSide = false;
		

		if (Input.touches.Length > 0)
		{
			
			Touch t = Input.GetTouch(0);
			if (t.phase == TouchPhase.Began)
			{
				CheckBallRadiusRayCross();
				startPos = new Vector2(t.position.x / (float)Screen.width, t.position.y / (float)Screen.width);
				startTime = Time.time;
				
			}
			if (t.phase == TouchPhase.Moved)
			{
				if (Time.time - startTime > MAX_SWIPE_TIME)
					return;

				Vector2 endPos = new Vector2(t.position.x / (float)Screen.width, t.position.y / (float)Screen.width);
				
				Vector2 swipe = new Vector2(endPos.x - startPos.x, endPos.y - startPos.y);
				deltaVector = swipe;
				if (swipe.magnitude < MIN_SWIPE_DISTANCE)
					return;

				if (Mathf.Abs(swipe.x) > Mathf.Abs(swipe.y))
				{
					if (swipe.x > 0)
					{
						swipedRight = true;
					}
					else
					{
						swipedLeft = true;
					}
				}
				else
				{
					if (swipe.y > 0)
					{
						swipedUp = true;
					}
					else
					{
						swipedDown = true;
					}
				}
				if (endPos.x<0.5f)
                {
					swipedLeftSide = true;
					Debug.Log("LeftSideSwipe"+endPos.x);
				}
				else
                {
					swipedRightSide = true;
					Debug.Log("RightSideSwipe");
					
                }
			}
			if (t.phase==TouchPhase.Ended)
            {
				ballRadiusReached = false;
			}
		}
		DebugWithArrowKeys();

	}
	private void CheckBallRadiusRayCross()
	{
		RaycastHit hit;
		Ray ray = camera.ScreenPointToRay(Input.mousePosition);

		if (Physics.Raycast(ray, out hit))
		{
			Transform objectHit = hit.transform;
			if (objectHit.tag == "BallControllRadius")
			{
				Debug.Log("BallControllRadius");
				ballRadiusReached = true;
			}
		}
	}
	private void DebugWithArrowKeys()
    {
		if (debugWithArrowKeys)
		{
			swipedDown = swipedDown || Input.GetKeyDown(KeyCode.DownArrow);
			swipedUp = swipedUp || Input.GetKeyDown(KeyCode.UpArrow);
			swipedRight = swipedRight || Input.GetKeyDown(KeyCode.RightArrow);
			swipedLeft = swipedLeft || Input.GetKeyDown(KeyCode.LeftArrow);
		}
	}
}