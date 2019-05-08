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

### iOS 端

1. Unity 工程项目中可直接调用 `GrowingIOGame.cs`中的公共方法实现埋点
2. Unity 工程导出 Xcode 工程时，需要在 `UnityAppController.mm` 文件中的如下方法调用 `startWithAccountId:`方法实现埋点SDK的启动,

```objc
- (BOOL)application:(UIApplication*)application didFinishLaunchingWithOptions:(NSDictionary*)launchOptions
{

    [Growing startWithAccountId:@"XXXXX"];// XXXXX为GrowingIO官网申请的项目ID
    
    return YES;
}

```
3. 配置 URLScheme：将在GrowingIO官网申请到的应用的 URL Scheme 填入到 BuildPostProcessor 中的 AddInfoPlist(path, "XXXXX"); XXXXX 处并保存，其注意事项请参考[iOS原生端埋点SDK文档](https://docs.growingio.com/docs/sdk-integration/ios-sdk-1/mai-dian-sdk-ji-cheng)
