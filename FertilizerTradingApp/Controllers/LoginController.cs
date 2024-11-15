using FertilizerTradingApp.Repository;
using FertilizerTradingApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace FertilizerTradingApp.Controllers
{
	public class LoginController
	{
		private readonly LoginService _loginService;
		public LoginController()
		{
			_loginService = new LoginService(ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString);
		}
		public bool LoginCheck(string username, string password)
		{
			return _loginService.LoginCheck(username, password);
		}
	}
}
