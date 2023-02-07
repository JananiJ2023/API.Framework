using API.Framework.Models;
using API.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Framework
{
    public class Reusable
    {
        public string baseUrl = ConfigurationManager.AppSettings["baseUrl"];
        public readonly CreateUserReq createUserReq;
        public static RestResponse response;
        public string userName;

        public static void VerifyErrorMessage(string errorMessage)
        {
            var content = HandleContent.GetContent<RegisterUnsuccessfulRes>(response);
            Assert.AreEqual(errorMessage, content.Error);
        }
    }
}
