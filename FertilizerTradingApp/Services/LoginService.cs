using System;
using System.Data.SqlClient;
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
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while checking login: {ex.Message}", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public bool UpdatePassword(string username, string oldPassword, string newPassword)
        {
            try
            {
                string storedHashedPassword = _loginRepository.GetAccountLogin(username);
                if (string.IsNullOrEmpty(storedHashedPassword))
                {
                    MessageBox.Show("Tài khoản không tồn tại", "Password Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                bool isOldPasswordCorrect = BCrypt.Net.BCrypt.Verify(oldPassword, storedHashedPassword);
                if (isOldPasswordCorrect)
                {
                    string newHashedPassword = BCrypt.Net.BCrypt.HashPassword(newPassword);
                    _loginRepository.UpdatePassword(username, newHashedPassword);
                    return true;
                }
                else
                {
                    MessageBox.Show("Sai mật khẩu cũ", "Password Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while updating the password: {ex.Message}", "Password Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
