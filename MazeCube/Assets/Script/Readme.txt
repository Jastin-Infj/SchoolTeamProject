カメラの導入流れ～

1.main cameraの名前を「PlayerCamera」に変更。

2.「Player Camera」をプレイヤの子に設定

3.Create→Cameraでもう一つカメラを生成

4.Cameraの名前を「MapCamera」に変更

5.作成したカメラにGameObject→align With Viewをアタッチ

6.Edit → ProjectSettings → Inputから
二つあるうちの下のほうにある...
Fire1のPositive Buttonをjoystick button 4
Fire2のPositive Buttonをjoystick button 5
Fire3のPositive Buttonをjoystick button 3
に変更する。

7.Create→Create Emptyで空のプロジェクトを生成して、名前を
「CameraController」に変更後スクリプトをアタッチしてください。

8.「MapCamera」を「CameraController」の子に設定。

以上！