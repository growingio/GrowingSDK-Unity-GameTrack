//
//  GrowingCoreAPI.c
//  GrowingIO_Manual
//
//  Created by GrowingIO on 2019/5/6.
//  Copyright © 2019 GrowingIO. All rights reserved.
//

#import <GrowingCoreKit/GrowingCoreKit.h>

// Converts C style string to NSString
static NSString *gioCreateNSString(const char *string) {
    if (string)
        return [NSString stringWithUTF8String:string];
    else
        return [NSString stringWithUTF8String:""];
}

static NSDictionary *gioCreateDiction(const char *keys[], const char *stringValues[], double numberValues[],int count) {
    NSMutableDictionary *dic = [NSMutableDictionary dictionary];
    for (int i = 0; i < count; i++) {
        if (keys[i] != NULL) {
            if (stringValues[i] != NULL) {
                [dic setObject:gioCreateNSString(stringValues[i])
                        forKey:gioCreateNSString(keys[i])];
            } else {
                [dic setObject:[NSNumber numberWithDouble:numberValues[i]] forKey:gioCreateNSString(keys[i])];
            }
        }
    }
    return dic.copy;
}


extern "C" {
    
#pragma GCC diagnostic ignored "-Wmissing-prototypes"
    
    //  发送事件
    void gioTrack(const char *eventId) {
        [Growing track:gioCreateNSString(eventId)];
    }
    
    void gioTrackWithNumber(const char *eventId, double number) {
        [Growing track:gioCreateNSString(eventId) withNumber:[NSNumber numberWithDouble:number]];
    }
    
    void gioTrackWithNumberAndVariable(const char *eventId, double number, const char *keys[], const char *stringValues[], double numberValues[], int count) {
        [Growing track:gioCreateNSString(eventId) withNumber:[NSNumber numberWithDouble:number] andVariable:gioCreateDiction(keys, stringValues, numberValues, count)];
    }
    
    void gioTrackWithVariable(const char *eventId, const char *keys[], const char *stringValues[], double numberValues[], int count) {
        [Growing track:gioCreateNSString(eventId) withVariable:gioCreateDiction(keys, stringValues, numberValues, count)];
    }
    
    //  转换变量
    void gioSetEvar(const char *keys[], const char *stringValues[], double numberValues[], int count) {
        [Growing setEvar:gioCreateDiction(keys, stringValues, numberValues, count)];
    }
    
    void gioSetEvarWithKeyAndString(const char *key, const char *string) {
        [Growing setEvarWithKey:gioCreateNSString(key) andStringValue:gioCreateNSString(string)];
    }
    
    void gioSetEvarWithKeyAndNumber(const char *key, double number) {
        [Growing setEvarWithKey:gioCreateNSString(key) andNumberValue:[NSNumber numberWithDouble:number]];
    }
    
    //  用户变量
    void gioSetPeople(const char *keys[], const char *stringValues[], double numberValues[], int count) {
        [Growing setPeopleVariable:gioCreateDiction(keys, stringValues, numberValues, count)];
    }
    
    void gioSetPeopleWithKeyAndString(const char *key, const char *string) {
        [Growing setPeopleVariableWithKey:gioCreateNSString(key) andStringValue:gioCreateNSString(string)];
    }
    
    void gioSetPeopleWithKeyAndNumber(const char *key, double number) {
        [Growing setPeopleVariableWithKey:gioCreateNSString(key) andNumberValue:[NSNumber numberWithDouble:number]];
    }

    //  访问用户变量
    void gioSetVistor(const char *keys[], const char *stringValues[], double numberValues[], int count) {
        [Growing setVisitor:gioCreateDiction(keys, stringValues, numberValues, count)];
    }
    
    //  设置用户ID
    void gioSetUserId(const char *userId) {
        [Growing setUserId:gioCreateNSString(userId)];
    }
    
    //  清除登录用户ID
    void gioClearUserId(){
        [Growing clearUserId];
    }
    
#pragma GCC diagnostic warning "-Wmissing-prototypes"
    
}

