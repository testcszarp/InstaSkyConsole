using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InstaSharper.API;
using InstaSharper.API.Builder;
using InstaSharper.Classes;
using System.IO;

namespace InstaSkyConsole
{
    class Login
    {
        public List<string> AccounInfo = new List<string>();
        public string tempAccountInfo;

        public IInstaApi _instaApi;

        public Login(IInstaApi instaApi)
        {
            _instaApi = instaApi;
        }


        public void LoadAccountInfo()
        {
            tempAccountInfo = File.ReadAllText(Directory.GetCurrentDirectory() + @"\AccountInfo.txt");
            AccounInfo = tempAccountInfo.Split(' ').ToList();
        }

        public void LoginToInstagramAsync()
        {
            Log log = new Log();

            var userSession = new UserSessionData
            {
                UserName = AccounInfo[0],
                Password = AccounInfo[1]
            };

            // create new InstaApi instance using Builder
            _instaApi = InstaApiBuilder.CreateBuilder()
                        .SetUser(userSession)
                        .SetRequestDelay(TimeSpan.FromSeconds(2))
                        .Build();
            try
            {
                if (!_instaApi.IsUserAuthenticated)
                {
                    // login
                    log.MessageToCOnsole($"Logging in as {userSession.UserName}");
                    var logInResult = _instaApi.LoginAsync();
                    if (logInResult.Result.Succeeded)
                    {
                        log.MessageToCOnsole($"Logged as: {userSession.UserName}");
                    }
                    else if (!logInResult.Result.Succeeded)
                    {
                        log.MessageToCOnsole($"Unable to login: {logInResult.Result.Info.Message}");
                    }
                }
            }
            catch(Exception ex)
            {
                log.MessageToCOnsole(ex.ToString());
            }
        }
    }
}
