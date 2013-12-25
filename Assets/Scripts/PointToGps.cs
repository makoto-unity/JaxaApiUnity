using UnityEngine;
using System.Collections;

public class PointToGps : MonoBehaviour {
	
	// Update is called once per frame
	static public void GetLatitudeLongitude(Vector3 point, out float latDeg, out float lonDeg) {
		float lengXZ = Mathf.Sqrt(point.z * point.z + point.x * point.x);
		float lat = Mathf.Atan2 (point.y, lengXZ);
		latDeg = Mathf.Rad2Deg * lat; // 緯度
		
		float lon = Mathf.Atan2 (point.z, point.x);
		lonDeg = Mathf.Rad2Deg * lon; // 経度
	}
}
