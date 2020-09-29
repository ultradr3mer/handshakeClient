# IO.Swagger.Api.PostApi

All URIs are relative to */*

Method | HTTP request | Description
------------- | ------------- | -------------
[**PostGetclosepostsGet**](PostApi.md#postgetclosepostsget) | **GET** /Post/getcloseposts | Gets all posts nearby.
[**PostPost**](PostApi.md#postpost) | **POST** /Post | Posts a new post.

<a name="postgetclosepostsget"></a>
# **PostGetclosepostsGet**
> void PostGetclosepostsGet ()

Gets all posts nearby.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class PostGetclosepostsGetExample
    {
        public void main()
        {
            var apiInstance = new PostApi();

            try
            {
                // Gets all posts nearby.
                apiInstance.PostGetclosepostsGet();
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling PostApi.PostGetclosepostsGet: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="postpost"></a>
# **PostPost**
> void PostPost (InsertPostData body = null)

Posts a new post.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class PostPostExample
    {
        public void main()
        {
            var apiInstance = new PostApi();
            var body = new InsertPostData(); // InsertPostData | The post to post. (optional) 

            try
            {
                // Posts a new post.
                apiInstance.PostPost(body);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling PostApi.PostPost: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**InsertPostData**](InsertPostData.md)| The post to post. | [optional] 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/_*+json
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
