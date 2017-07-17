using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MadarshoAnalyticsDotNetFramework.Enums
{
    public enum ActionsEnum
    {
        FirstOpen, AppOpen, CantResolve,
        RegisterPregnant, RegisterTtc, RegisterNone, InvalidRegisteration,
        Login, ForgotPass, VerifyPhone, InvalidLogin,
        ViewSection, Get401,
        EnterWeight, EnterSymptom, EnterPrenatalCare,
        RemoveWeight, RemoveSymptom, RemovePrenatalCare,
        ViewedUrl, AddedPhoto, ChangedPhoto, ViewProfileDemographic, ViewProfileHealth,
        ChangeProfileHealth, ChangeProfileDemographic, ShareApp, ShareLink,
        Logout
    }
}