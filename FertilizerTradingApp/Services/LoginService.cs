using System;
using System.Windows.Forms;
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
            try
            {
                string storedHashedPassword = _loginRepository.GetAccountLogin(username);
                if (string.IsNullOrEmpty(storedHashedPassword))
                {
                    MessageBox.Show("Account does not exist.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                bool isPasswordCorrect = BCrypt.Net.BCrypt.Verify(password, storedHashedPassword);
                if (isPasswordCorrect)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Incorrect password.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while checking login: {ex.Message}", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
