using TidalInfra.Log;
using OpenTidl;
using OpenTidl.Methods;
using OpenTidl.Models;
using System;
using System.Threading.Tasks;
using TidalInfra.DTO;


namespace TidalInfra
{
    public class LoginLogic
    {
        private readonly ConsoleLogger logger = new ConsoleLogger();

        private readonly OpenTidlClient rea; 
        private const string UserName = @"danganon8520@gmail.com";
        private const string Password = @"Presley@1977";
        public LoginLogic()
        {
            logger.WriteInfo("Add log here");
            var defaultConfiguration = ClientConfiguration.Default;
            rea = new OpenTidlClient(defaultConfiguration);
        }

        

        public async Task<OpenTidlSession> BaseLogin()
        {

            logger.WriteInfo("Hi");
            var loginObject = new LoginDto { Username = UserName, Password = Password };
            return await rea.LoginWithUsername(loginObject.Username, loginObject.Password);
            
        }

        public OpenTidlClient GetClient()
        {
            return rea;
        }
    }
}
