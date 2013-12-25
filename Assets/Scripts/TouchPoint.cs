using UnityEngine;
using System.Collections;

public class TouchPoint : MonoBehaviour {

	// Use this for initialization
	void Start () {
		mousePos = Input.mousePosition;
	}

	Vector3 mousePos;
	public JaxaApi jaxa;
	public string dateStr = "2012-12-25";
	float latDeg, lonDeg;

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			mousePos = Input.mousePosition;
		}
		if (Input.GetMouseButtonUp(0)) {
			float dis = (mousePos - Input.mousePosition).magnitude;
			if ( dis <= 1.0f ) {
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				RaycastHit hitInfo;
				if (Physics.Raycast(ray, out hitInfo)) {
					print( hitInfo.point );
					PointToGps.GetLatitudeLongitude( hitInfo.point, out latDeg, out lonDeg );
					print ( "lat:" + latDeg + "   lon:" + lonDeg );
					jaxa.AskPrcAverage( dateStr, latDeg, lonDeg, 0.1f );
					print( jaxa.responseData["value"] );
				}
			}	
		}
	}

	public Rect rect;
	void OnGUI() {
		dateStr = GUI.TextField(rect, dateStr);
		if ( jaxa.responseData != null && jaxa.responseData.ContainsKey("value") ) {
			string latStr = ((float)Mathf.FloorToInt(latDeg * 10.0f) / 10.0f).ToString();
			string lonStr = ((float)Mathf.FloorToInt(lonDeg * 10.0f) / 10.0f).ToString();
			GUI.Label(new Rect(10, 30, 600, 20), "緯度:" + latStr + " 経度:" + lonStr + " 降水量:" +  jaxa.responseData["value"]);
		}
	}
}
