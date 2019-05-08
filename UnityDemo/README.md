# GrowingIO Unity Demo
### 运行截图
![](https://github.com/growingio/GrowingSDK-Unity-GameTrack/blob/master/UnityDemo/screenshots.png) 
### 运行Demo
Build scenes选择Main，然后运行到相应设备上。

### Android 端
`android-native.jar`中只包含了两个类，关键代码如下：   
`GameApp.class`   
```java
public class GameApp extends Application {
    private static final String TAG = "GameApp";

    @Override
    public void onCreate() {
        Log.e(TAG, "onCreate: ");
        super.onCreate();
        GrowingIO.startWithConfiguration(this, new Configuration()
                .setProjectId("0a1b4118dd954ec3bcc69da5138bdb96")
                .setURLScheme("growing.d0823191073f2fbe")
                .setDebugMode(true));
    }
}
```
`UnityActivity.class`   
```java
public class UnityActivity extends UnityPlayerActivity {
    @Override
    protected void onNewIntent(Intent intent) {
        super.onNewIntent(intent);
        GrowingIO.getInstance().onNewIntent(this, intent);
    }
}
```