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

シーンをプレイしてください。
操作は、マウスドラッグで地球回転、マウスホイールでズームインズームアウトです。

そして、クリックすることで、その緯度経度を測定し、その地点の降水量平均をJaxa APIを使って取得してきます。

---

プログラムの説明
