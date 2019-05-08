# GrowigIO Unity Demo
### 一. 介绍

### 二. 集成步骤
#### Android 端
1. 将最新的Unity埋点SDK `vds-android-agent-game-track-x.x.x.aar`导入 Unity 项目目录`Assets/Plugins/Android/`
2. 在Android工程的`Application`的`onCreate`方法中初始化GrowingIO。如果没有`Application`类请添加一个。
```java
public class GameApp extends Application {
    @Override
    public void onCreate() {
        super.onCreate();
        GrowingIO.startWithConfiguration(this, new Configuration()     
            .setProjectId("xxxxx")
            .setURLScheme("growing.xxxxx")
            .setDebugMode(true));
        );
    }
}
```
3. 在`LAUNCHER Activity`的`onNewIntent`方法中调用`public GrowingIO onNewIntent(Activity activity, Intent intent)`API。如果使用的是Unity默认的`UnityPlayerActivity`为`LAUNCHER Activity`，请自定义一个`LAUNCHER Activity`。
4. 添加`AndroidManifest.xml`文件到 Unity 项目目录`Assets/Plugins/Android/`，并注意修改`AndroidManifest.xml`中`${您的APP包名}`等关键字
5. 更多细节请参看[UnityDemo](https://github.com/growingio/GrowingSDK-Unity-GameTrack/tree/master/UnityDemo)和[Android原生端埋点SDK文档](https://docs.growingio.com/docs/sdk-integration/android-sdk/android-mai-dian-sdk)

#### iOS端

1. 将最新的埋点SDK `GrowingCoreKit.framework` 导入 Unity 项目目录 `Assets/Plugins/iOS/` 中
2. 将 `BuildPostProcessor` 脚本文件导入 Unity 项目目录 `Assets/Editor`中  
3. 配置 URLScheme：将在GrowingIO官网申请到的应用的 `URL Scheme` 填入到 `BuildPostProcessor` 中的 `AddInfoPlist(path, "XXX");` XXX 处并保存
4. Unity 工程中可以通过 `GrowingIOGame.cs`脚本调用指定的埋点方法
5. 初始化埋点SDK:Unity 导出 Xcode 工程后，通过在GrowingIO官网申请到项目ID，在 `UnityAppController.mm` 文件中的代码方法中完成初始化

```objc
- (BOOL)application:(UIApplication*)application didFinishLaunchingWithOptions:(NSDictionary*)launchOptions
{
     [Growing startWithAccountId:@"xxxxx"];
     return YES;
}

```
