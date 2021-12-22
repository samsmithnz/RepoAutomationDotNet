﻿using System.Net.Http.Headers;

namespace RepoAutomation.APIAccess;

public static class BaseAPIAccess
{

    public async static Task<string> GetGitHubMessage(string url, string clientId, string clientSecret)
    {
        HttpClient client = BuildHttpClient(url, clientId, clientSecret);
        HttpResponseMessage response = await client.GetAsync(url);
        return await ProcessResponse(response);
        //Console.WriteLine($"Running GitHub url: {url}");
        //string responseBody = "";
        //CheckUrl(url);
        //using (HttpClient client = new())
        //{
        //    client.DefaultRequestHeaders.Accept.Clear();
        //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //    client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("SamsRepoAutomation", "0.1"));
        //    //If we use a id/secret, we significantly increase the rate from 60 requests an hour to 5000. https://developer.github.com/v3/#rate-limiting
        //    if (string.IsNullOrEmpty(clientId) == false && string.IsNullOrEmpty(clientSecret) == false)
        //    {
        //        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(string.Format("{0}:{1}", clientId, clientSecret))));
        //    }
        //    using (HttpResponseMessage response = await client.GetAsync(url))
        //    {
        //        //Throw a response exception
        //        response.EnsureSuccessStatusCode();
        //        if (response.IsSuccessStatusCode)
        //        {
        //            responseBody = await response.Content.ReadAsStringAsync();
        //            //Console.WriteLine(responseBody);
        //        }
        //    }
        //}
        //return responseBody;
    }

    public async static Task<string> PostGitHubMessage(string url, string clientId, string clientSecret, StringContent content)
    {
        HttpClient client = BuildHttpClient(url, clientId, clientSecret);
        HttpResponseMessage response = await client.PostAsync(url, content);
        return await ProcessResponse(response);

        //Console.WriteLine($"Running GitHub url: {url}");
        //string responseBody = "";
        //CheckUrl(url);
        //using (HttpClient client = new())
        //{
        //    client.DefaultRequestHeaders.Accept.Clear();
        //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //    client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("SamsRepoAutomation", "0.1"));
        //    //If we use a id/secret, we significantly increase the rate from 60 requests an hour to 5000. https://developer.github.com/v3/#rate-limiting
        //    if (string.IsNullOrEmpty(clientId) == false && string.IsNullOrEmpty(clientSecret) == false)
        //    {
        //        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(string.Format("{0}:{1}", clientId, clientSecret))));
        //    }
        //    using (HttpResponseMessage response = await client.PostAsync(url, content))
        //    {
        //        //Throw a response exception
        //        response.EnsureSuccessStatusCode();
        //        if (response.IsSuccessStatusCode)
        //        {
        //            responseBody = await response.Content.ReadAsStringAsync();
        //            //Console.WriteLine(responseBody);
        //        }
        //    }
        //}
        //return responseBody;
    }

    public async static Task<string> DeleteGitHubMessage(string url, string clientId, string clientSecret)
    {
        HttpClient client = BuildHttpClient(url, clientId, clientSecret);
        HttpResponseMessage response = await client.DeleteAsync(url);
        return await ProcessResponse(response);
    }

    private static bool CheckUrl(string url)
    {
        if (!url.Contains("api.github.com"))
        {
            throw new Exception("api.github.com missing from URL");
        }
        return true;
    }

    private static HttpClient BuildHttpClient(string url, string clientId, string clientSecret)
    {
        Console.WriteLine($"Running GitHub url: {url}");
        if (!url.Contains("api.github.com"))
        {
            throw new Exception("api.github.com missing from URL");
        }
        HttpClient client = new();
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("SamsRepoAutomation", "0.1"));
        //If we use a id/secret, we significantly increase the rate from 60 requests an hour to 5000. https://developer.github.com/v3/#rate-limiting
        if (string.IsNullOrEmpty(clientId) == false && string.IsNullOrEmpty(clientSecret) == false)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(string.Format("{0}:{1}", clientId, clientSecret))));
        }
        return client;
    }

    private async static Task<string> ProcessResponse(HttpResponseMessage response)
    {
        string responseBody = "";
        //Throw a response exception
        response.EnsureSuccessStatusCode();
        if (response.IsSuccessStatusCode)
        {
            responseBody = await response.Content.ReadAsStringAsync();
        }
        return responseBody;
    }
}
