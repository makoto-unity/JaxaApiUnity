JaxaApiUnity
============

Sample project using Jaxa API with Unity.

JAXA APIを使うためのUnityサンプルプロジェクトです。

まずは、JAXA APIの仕様を理解しましょう。

http://www.satnavi.jaxa.jp/jaxa_api_competition/

（現在アプリ開発コンペ開催中です）

で、何はともあれ利用者登録して、APIを使えるようにしておきましょう。

https://www.satnavi-sub-jaxa.jp/jaxa_api_competition/form/form03.cgi


登録したメールアドレスにトークンが送られてくるので、これを後ほど使います。

そして、このUnityプロジェクトをダウンロードして、Sampleシーンを開きましょう。

シーンの中の「JaxaSample」を選択し、Inspector で「Jaxa Api」の「Token」に先ほど送られてきたトークンを代入します。

シーンをプレイしてください。操作は、マウスドラッグで地球回転、マウスホイールでズームインズームアウトです。

そして、クリックすることで、その緯度経度を測定し、その地点の降水量平均をJaxa APIを使って取得してきます。

---

プログラムの説明

JaxaApi.cs

APIは５種類（降水量、海面水温、海上風速、土壌水分量、積雪深）×２パターン（全地点、平均）あります。

	// 日降水量 prc
	public void AskPrcAverage( string dateStr /*2012-08-01 */, float latitude, float longitude, float range) {

引数は順番に日付の文字列、緯度、経度、範囲（0.1〜）ということになります。

一旦、Ask〜系の関数でデータをネットから取得した後、public変数のresponseDataでデータを取得してください。

--

MiniJSON.cs

https://gist.github.com/darktable/1411710

JSONパーサーとしては手軽だが、メモリを多く消費してしまうのが難点。メモリが問題になりそうであれば、他のパーサーに変更した方がいいでしょう。

--

MouseOrbitImproved.cs

マウスドラッグで対象物中心にカメラを回すプログラム。
元ネタは

http://wiki.unity3d.com/index.php?title=MouseOrbitImproved

--

PointToGps.cs

地球のXYZ座標を緯度経度に変換するユーティリティ関数

--

TouchPoint.cs

サンプルプログラム。タッチしたところの降水量を表示したり。