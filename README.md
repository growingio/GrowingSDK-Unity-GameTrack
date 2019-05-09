
# GrowingSDK-Unity-GameTrack
GrowingIO Unity 平台埋点SDK

### 一. 介绍

#### API列表

**事件类型以及对应函数如下**

1. Track：发送自定义事件，对应于`cstm`事件，提供以下4个函数：
    ```C#
    public static void Track(string eventId)
    public static void Track(string eventId, double number)
    public static void Track(string eventId, Dictionary<string, object> variable)
    public static void Track(string eventId, double number, Dictionary<string, object> variable)
    ```
2. SetEvar：发送转化变量，对应于`evar` 事件，提供以下3个函数：
    
    ```C#
    public static void SetEvar(string key, string value)
    public static void SetEvar(string key, double number)
    public static void SetEvar(Dictionary<string, object> variable)
    ```
3. SetPeopleVariable：发送用户变量，对应于`ppl`事件，提供以下3个函数：
    
    ```C#
    public static void SetPeopleVariable(string key, string value)
    public static void SetPeopleVariable(string key, double number)
    public static void SetPeopleVariable(Dictionary<string, object> variable)
    ```
4. SetVisitor：设置访问用户变量，对应于`vstr`事件，提供函数如下：
    
    ```C#
    public static void SetVisitor(Dictionary<string, object> variable)
    ```

5. SetUserId：设置登录用户Id，对应于`cs1`字段，提供函数如下：
    
    ```C#
    public static void SetUserId(string userId)
    ```

6. ClearUserId：清除登录用户Id，提供函数如下：
    
    ```C#
    public static void ClearUserId()
    ```

**参数限制条件**


 参数名称| 限制条件
 ------ |---  
 eventId  | 非空，长度限制小于等于50。
 number   | 非空。
 variable | value 传入`string` 或者基本数值类型，对于嵌套的对应，会统一转换成`string`,key 长度限制小于等于50，value长度小于等于1000。
 userId   | 长度限制小于等于1000；如果值为空则清空了登录用户变量，不建议这么用，请使用 clearUserId 清除登录用户变量。

**调用示例**

`Unity`通过`GrowingIOGame`类的函数来调用`Native`的埋点API，调用方式如下：

```C#
    
    //Track 设置自定义事件
    GrowingIOGame.Track("StringTrack");
    GrowingIOGame.Track("NumberTrack", 10);
    
    //Track 设置自定义事件，传递字典参数
    Dictionary<string, object> dictionary = new Dictionary<string, object> {{"key1", "value1"}, {"key2", 111}, {"key3", false}};
    GrowingIOGame.Track("DictionaryTrack", dictionary);

    Dictionary<string, object> dictionary = new Dictionary<string, object> {{"key1", "value1"}, {"key2", 111.11}};
    GrowingIOGame.Track("NumberDictionaryTrack", 66.66, dictionary);
    
    //SetEvar 设置转化变量
    GrowingIOGame.SetEvar("EvarStringKey", "EvarString");
    GrowingIOGame.SetEvar("EvarNumberKey", "100");
    
    //SetEvar 设置转化变量，传递字典参数
    Dictionary<string, object> dictionary = new Dictionary<string, object> {{"EvarKey1", "EvarValue1"}, {"EvarKey2", true}};
    GrowingIOGame.SetEvar(dictionary);
    
    //SetPeopleVariable 设置用户变量
    GrowingIOGame.SetPeopleVariable("PeopleStringKey", "PeopleString");
    GrowingIOGame.SetPeopleVariable("PeopleNumberKey", "PeopleNumber");
    
    //SetPeopleVariable 设置用户变量，传递字典参数
    Dictionary<string, object> dictionary = new Dictionary<string, object> {{"PeopleKey1", "PeopleValue1"}, {"PeopleKey2", 6.66}};
    GrowingIOGame.SetPeopleVariable(dictionary);
    
    //SetVisitor 设置访问用户变量，传递字典参数
    Dictionary<string, object> dictionary = new Dictionary<string, object> {{"VisitorKey1", "VisitorValue1"}, {"VisitorKey2", false}};
    GrowingIOGame.SetVisitor(dictionary);
    
    //SetUserId 设置登录用户名称
    GrowingIOGame.SetUserId("张三");
    
    //ClearId 清除登录用户名称
    GrowingIOGame.ClearUserId();
            
```

**验证SDK是否正常工作**

##### 验证内容

1. 验证打点事件是否发送成功

##### 验证工具
1. `Unity`导出原生应用后，利用`Mobile Debuuger`查看
2. `Android`查看日志：设置`TestMode`和`DebugMode`:

```Java
GrowingIO.startWithConfiguration(this,new Configuration()
    //BuildConfig.DEBUG 这样配置就不会上线忘记关闭
    .setDebugMode(BuildConfig.DEBUG)
    .setTestMode(true)
    ...
    );
```
3. iOS查看日志：iOS在`UnityAppController.mm` 文件中如下方法中打开日志：

```OC
- (BOOL)application:(UIApplication*)application didFinishLaunchingWithOptions:(NSDictionary*)launchOptions
{
    //打开日志
    [Growing setEnableLog:YES];
    return YES;
}
```

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
3. 在`LAUNCHER Activity`的`onNewIntent`方法中调用`public GrowingIO onNewIntent(Activity activity, Intent intent)`API。如果使用的是Unity默认的`UnityPlayerActivity`为`LAUNCHER Activity`，请自定义一个`LAUNCHER Activity`。
4. 添加`AndroidManifest.xml`文件到 Unity 项目目录`Assets/Plugins/Android/`，并注意修改`AndroidManifest.xml`中`${您的APP包名}`等关键字
5. 更多细节请参看[UnityDemo](https://github.com/growingio/GrowingSDK-Unity-GameTrack/tree/master/UnityDemo)和[Android原生端埋点SDK文档](https://docs.growingio.com/docs/sdk-integration/android-sdk/android-mai-dian-sdk)

#### iOS端

1. 将最新的埋点SDK `GrowingCoreKit.framework` 导入 Unity 项目目录 `Assets/Plugins/iOS/` 中
2. 将 `BuildPostProcessor` 脚本文件导入 Unity 项目目录 `Assets/Editor`中  
3. 配置 URLScheme：将在GrowingIO官网申请到的应用的 `URL Scheme` 填入到 `BuildPostProcessor` 中的 `AddInfoPlist(path, "XXXXX");` XXXXX 处并保存
4. Unity 工程中可以通过 `GrowingIOGame.cs`脚本调用指定的埋点方法
5. 初始化埋点SDK:Unity 导出 Xcode 工程后，通过在GrowingIO官网申请到项目ID，在 `UnityAppController.mm` 文件中的代码方法中完成初始化

```objc
- (BOOL)application:(UIApplication*)application didFinishLaunchingWithOptions:(NSDictionary*)launchOptions
{
     [Growing startWithAccountId:@"xxxxx"];
     return YES;
}

```
6. 更多细节请参考[UnityDemo](https://github.com/growingio/GrowingSDK-Unity-GameTrack/tree/master/UnityDemo)和[iOS原生端埋点SDK文档](https://docs.growingio.com/docs/sdk-integration/ios-sdk-1/mai-dian-sdk-ji-cheng)
