using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BCrypt.Net;
using FertilizerTradingApp.Models;
using FertilizerTradingApp.Repository;

namespace FertilizerTradingApp.Services
{
	public class LoginService
	{
		private readonly LoginRepository _loginRepository;
		public LoginService(string connectionString)
		{
			_loginRepository = new LoginRepository(connectionString);
		}
		public bool LoginCheck(string username, string password)
		{
			string storedHashedPassword = _loginRepository.GetAccountLogin(username);
			
			bool isPasswordCorrect = BCrypt.Net.BCrypt.Verify(password, storedHashedPassword);

			return isPasswordCorrect;
		}
	}
}
