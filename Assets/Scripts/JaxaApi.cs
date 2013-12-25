using UnityEngine;
using System.IO;
using System.Net;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using MiniJSON;

public class JaxaApi : MonoBehaviour {
	private string txt = "";
	private string url = "https://joa.epi.bz/api/";
	public string token = "TOKEN_Lu2C_";
	private string format = "JSON";
	
	// 日降水量 prc
	public void AskPrcAverage( string dateStr /*2012-08-01 */, float latitude, float longitude, float range) {
		AskData ( "prc", "avg", dateStr, latitude, longitude, range );
	}
	public void AskPrcAll( string dateStr /*2012-08-01 */, float latitude, float longitude, float range) {
		AskData ( "prc", "all", dateStr, latitude, longitude, range );
	}
	// 海面水温 sst
	public void AskSstAverage( string dateStr /*2012-08-01 */, float latitude, float longitude, float range) {
		AskData ( "sst", "avg", dateStr, latitude, longitude, range );
	}
	public void AskSstAll( string dateStr /*2012-08-01 */, float latitude, float longitude, float range) {
		AskData ( "sst", "all", dateStr, latitude, longitude, range );
	}
	// 海上風速 ssw
	public void AskSswAverage( string dateStr /*2012-08-01 */, float latitude, float longitude, float range) {
		AskData ( "ssw", "avg", dateStr, latitude, longitude, range );
	}
	public void AskSswAll( string dateStr /*2012-08-01 */, float latitude, float longitude, float range) {
		AskData ( "ssw", "all", dateStr, latitude, longitude, range );
	}
	// 土壌水分量 smc
	public void AskSmcAverage( string dateStr /*2012-08-01 */, float latitude, float longitude, float range) {
		AskData ( "smc", "avg", dateStr, latitude, longitude, range );
	}
	public void AskSmcAll( string dateStr /*2012-08-01 */, float latitude, float longitude, float range) {
		AskData ( "smc", "all", dateStr, latitude, longitude, range );
	}
	// 積雪深 snd
	public void AskSndAverage( string dateStr /*2012-08-01 */, float latitude, float longitude, float range) {
		AskData ( "snd", "avg", dateStr, latitude, longitude, range );
	}
	public void AskSndAll( string dateStr /*2012-08-01 */, float latitude, float longitude, float range) {
		AskData ( "snd", "all", dateStr, latitude, longitude, range );
	}

	public Dictionary<string,object> responseData;

    private void AskData( string prefix, string sufix, string dateStr /*2012-08-01 */, float latitude, float longitude, float range) {
		string cmdUrl = url + prefix + sufix;
		cmdUrl += "?token=" + token;
		cmdUrl += "&date=" + dateStr;
		cmdUrl += "&lat=" + latitude.ToString();
		cmdUrl += "&lon=" + longitude.ToString();
		cmdUrl += "&range=" + range.ToString();
		cmdUrl += "&format=" + format;
		print (cmdUrl);

		HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(cmdUrl);
		request.Method = WebRequestMethods.Http.Get;
		request.Accept = "application/json; charset=utf-8";
		WebResponse resp = null;
		try {
			resp = request.GetResponse();
		} catch {
			resp = null;
		}

		if (resp != null) {
			Stream st = resp.GetResponseStream();
			StreamReader sr = new StreamReader(st, Encoding.GetEncoding("utf-8"));
			txt = sr.ReadToEnd();
			sr.Close();
			st.Close();
			// 強引な方法
			//txt = txt.Replace("{", "{\"");
			//txt = txt.Replace(",", ",\"");
			//txt = txt.Replace(":", "\":");
			print ( txt );
			responseData = Json.Deserialize(txt) as Dictionary<string,object>;
	        Debug.Log("result: " + (string) responseData["result"]);
		} else {
			responseData.Clear();
			Debug.Log("no result");
		}
	}
}