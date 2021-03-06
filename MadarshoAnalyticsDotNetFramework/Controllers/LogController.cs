﻿using MadarshoAnalyticsDotNetFramework.Context;
using MadarshoAnalyticsDotNetFramework.Models;
using MadarshoAnalyticsDotNetFramework.Utility;
using MadarshoAnalyticsDotNetFramework.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace MadarshoAnalyticsDotNetFramework.Controllers
{  
    public class LogController : ApiController
    {
        //[HttpPost]
        //[Route("api/register")]
        //public async Task<IHttpActionResult> Register(UserView user)
        //{
        //    if (user == null)
        //    {
        //        return BadRequest("user is null");
        //    }
        //    using (var db = new AnalyticsContext())
        //    {
        //        if (db.Users.Any(r=>r.Username.Equals(user.Username)))
        //        {
        //            return BadRequest("duplicate username");
        //        }

        //        var userEntity = new User
        //        {
        //            Username = user.Username,
        //            AppVersion = user.AppVersion,
        //            FirebaseToken = user.FirebaseToken,
        //            RegisterDate = DateTime.Now.ToUnixTime()
        //        };

        //        db.Users.Add(userEntity);
        //        try
        //        {
        //            await db.SaveChangesAsync();
        //            return Ok(userEntity.Id);
        //        }
        //        catch(Exception ex)
        //        {
        //            return BadRequest(ex.Message);
        //        }
        //    }
        //}

        [HttpPost]
        [Route("api/log")]
        public async Task<IHttpActionResult> Log(UserActionView userActionView)
        {
            long userId = 0;
            if (userActionView == null)
            {
                return BadRequest("userActionView is null");
            }
            using (var db = new AnalyticsContext())
            {
                foreach (var item in userActionView.Actions)
                {
                    //if there is no userId
                    if (userActionView.UserId == 0 && userActionView.FirebaseToken != null)
                    {
                        var user = db.Users.FirstOrDefault(t => t.FirebaseToken == userActionView.FirebaseToken);
                        //if there is a user with that token
                        if (user != null)
                        {
                            UserAction userAction = new UserAction
                            {
                                ActionId = item.ActionId,
                                Date = item.Date,
                                Param1 = item.Param1,
                                Param2 = item.Param2,
                                UserId = user.Id
                            };

                            db.UserActions.Add(userAction);
                        }
                        //if the user is new
                        else
                        {
                            var newUser = new User
                            {
                                AppVersion = userActionView.AppVersion,
                                FirebaseToken = userActionView.FirebaseToken,
                                RegisterDate = DateTime.Now.ToUnixTime()
                            };

                            db.Users.Add(newUser);
                            await db.SaveChangesAsync(); 
                            userId = newUser.Id;
                            userActionView.UserId = userId;
                            UserAction userAction = new UserAction
                            {
                                ActionId = item.ActionId,
                                Date = item.Date,
                                Param1 = item.Param1,
                                Param2 = item.Param2,
                                UserId = userActionView.UserId,
                            };
                            db.UserActions.Add(userAction);
                        }
                    }
                    //if it has a userId
                    else
                    {
                        UserAction userAction = new UserAction
                        {
                            ActionId = item.ActionId,
                            Date = item.Date,
                            Param1 = item.Param1,
                            Param2 = item.Param2,
                            UserId = userActionView.UserId,
                        };

                        db.UserActions.Add(userAction);
                    }
                  
                    try
                    {
                        await db.SaveChangesAsync();
                    }
                    catch (Exception ex)
                    {
                        return BadRequest(ex.Message);
                    }
                }

                return Ok(userId);
            }
        }
    }
}