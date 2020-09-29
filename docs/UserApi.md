# IO.Swagger.Api.UserApi

All URIs are relative to */*

Method | HTTP request | Description
------------- | ------------- | -------------
[**UserGetcloseusersGet**](UserApi.md#usergetcloseusersget) | **GET** /User/getcloseusers | Gets all users nearby.
[**UserPost**](UserApi.md#userpost) | **POST** /User | Creates a new user.

<a name="usergetcloseusersget"></a>
# **UserGetcloseusersGet**
> void UserGetcloseusersGet (double? longitude = null, double? latitude = null)

Gets all users nearby.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class UserGetcloseusersGetExample
    {
        public void main()
        {
            var apiInstance = new UserApi();
            var longitude = 1.2;  // double? |  (optional) 
            var latitude = 1.2;  // double? |  (optional) 

            try
            {
                // Gets all users nearby.
                apiInstance.UserGetcloseusersGet(longitude, latitude);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling UserApi.UserGetcloseusersGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **longitude** | **double?**|  | [optional] 
 **latitude** | **double?**|  | [optional] 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="userpost"></a>
# **UserPost**
> void UserPost (InsertUserDaten body = null)

Creates a new user.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class UserPostExample
    {
        public void main()
        {
            var apiInstance = new UserApi();
            var body = new InsertUserDaten(); // InsertUserDaten | The user to create. (optional) 

            try
            {
                // Creates a new user.
                apiInstance.UserPost(body);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling UserApi.UserPost: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**InsertUserDaten**](InsertUserDaten.md)| The user to create. | [optional] 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/_*+json
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
