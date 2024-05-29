using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using RhizomaAlismatisBackend.Models;
using RhizomaAlismatisBackend.Services;

namespace RhizomaAlismatisBackend.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly MusicBoxService _databaseService;

    public UserController(MusicBoxService databaseService)
    {
        _databaseService = databaseService;
    }


    [HttpPost]
    [Route("register")]
    public Response Register(string userName, string userEmail, string userPassword)
    {
        //检查email是否存在
        if (_databaseService.GetUserByEmail(userEmail).Result.Email != string.Empty)
        {
            return new Response
            {
                StatusCode = 400,
                Message = "用户已存在"
            };
        }
        var user = new User
        {
            Name = userName,
            Email = userEmail,
            Password = TextToMd5(userPassword),
            Icon = "https://cdn.discordapp.com/attachments/1009518762415995520/1009518762415995520/unknown.png",
            CreateTime = Utils.TimeStamp.GetUnixTimeStamp().ToString()
        };
        _ = _databaseService.InsertUser(user);
        return new Response
        {
            StatusCode = 200,
            Message = user.Id
        };
    }

    [HttpGet]
    [Route("login")]
    public Response Login(string userEmail, string userPassword)
    {
        var user = _databaseService.GetUserByEmail(userEmail);
        if (user.Result.Email == string.Empty)
        {
            return new Response
            {
                StatusCode = 400,
                Message = "用户不存在"
            };
        }
        if (user.Result.Password != TextToMd5(userPassword))
        {
            return new Response
            {
                StatusCode = 400,
                Message = "密码错误"
            };
        }
        return new Response
        {
            StatusCode = 200,
            Message = user.Result.Id
        };
    }

    private static string TextToMd5(string input)
    {
        var data = MD5.HashData(Encoding.UTF8.GetBytes(input));
        var sBuilder = new StringBuilder();
        foreach (var t in data)
        {
            sBuilder.Append(t.ToString("x2"));
        }
        return sBuilder.ToString();
    }
}