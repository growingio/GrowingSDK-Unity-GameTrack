# GrowigIO Unity Demo
### 一. 介绍

### 二. 集成步骤
#### Android 端
1. 将最新的Unity埋点SDK `vds-android-agent-game-track.jar`导入 Unity 项目目录`Assets/Plugins/Android/`
2. 在Android工程的`Application`的`onCreate`方法中初始化GrowingIO
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
* 如果没有`Application`类请添加一个。如Demo中`android-native.jar`的`GameApp.class`,代码如下
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
3. 在`LAUNCHER Activity`的`onNewIntent`方法中调用`public GrowingIO onNewIntent(Activity activity, Intent intent)`API。如果使用的是Unity默认的`UnityPlayerActivity`为`LAUNCHER Activity`，请自定义一个`LAUNCHER Activity`。如Demo中`android-native.jar`的`UnityActivity.class`,代码如下
```java
public class UnityActivity extends UnityPlayerActivity {
    @Override
    protected void onNewIntent(Intent intent) {
        super.onNewIntent(intent);
        GrowingIO.getInstance().onNewIntent(this, intent);
    }
}
```
4. 添加自定义`AndroidManifest.xml`文件，格式如下（可以参考Demo中的`AndroidManifest.xml`文件）：
```xml
<?xml version="1.0" encoding="utf-8"?>
<manifest
    xmlns:android="http://schemas.android.com/apk/res/android"
    package="${您的APP包名}"
    xmlns:tools="http://schemas.android.com/tools"
    android:installLocation="preferExternal">

   <!--非危险权限，不需要运行时请求，Manifest文件中添加即可-->
    <uses-permission android:name="android.permission.INTERNET"/>
    <uses-permission android:name="android.permission.ACCESS_NETWORK_STATE"/>
    <uses-permission android:name="android.permission.SYSTEM_ALERT_WINDOW"/>
    <uses-permission android:name="android.permission.ACCESS_WIFI_STATE"/>

    <supports-screens
        android:smallScreens="true"
        android:normalScreens="true"
        android:largeScreens="true"
        android:xlargeScreens="true"
        android:anyDensity="true"/>

    <application
        android:name="${您的Application类}"
        android:theme="@style/UnityThemeSelector"
        android:icon="@mipmap/app_icon"
        android:label="@string/app_name">
        <activity android:name="${您的LAUNCHER Activity类}"
                  android:label="@string/app_name">
            <intent-filter>
                <action android:name="android.intent.action.MAIN"/>
                <category android:name="android.intent.category.LAUNCHER"/>
            </intent-filter>
            <!--请添加这里的整个 intent-filter 区块，并确保其中只有一个 data 字段-->
            <intent-filter>
                <data android:scheme="${您的URL Scheme}"/>
                <action android:name="android.intent.action.VIEW"/>
                <category android:name="android.intent.category.DEFAULT"/>
                <category android:name="android.intent.category.BROWSABLE"/>
            </intent-filter>
            <!--请添加这里的整个 intent-filter 区块，并确保其中只有一个 data 字段-->
            <meta-data android:name="unityplayer.UnityActivity" android:value="true"/>
        </activity>
    </application>
</manifest>
```
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
