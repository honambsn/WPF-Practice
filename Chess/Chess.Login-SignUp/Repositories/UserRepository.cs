using Chess.Login_SignUp.Model;
using Chess.LoginSignUp.Infrastructure.Persistence;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Login_SignUp.Repositories
{
    public class UserRepository : RepositoryBase, IUserRepository
    {
        public void Add(UserModel user)
        {
            throw new NotImplementedException();
        }

        public bool AuthenticateUser(NetworkCredential credential)
        {
            bool validUser;
            using (var connection = GetConnection())
            {
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = "select * from [User] where username=@username and [password]=@password";
                    command.Parameters.Add("@username", System.Data.SqlDbType.NVarChar).Value = credential.UserName;
                    command.Parameters.Add("@password", System.Data.SqlDbType.NVarChar).Value = credential.Password;
                    validUser = command.ExecuteScalar() == null ? false : true;
                }
            }
            return validUser;
        }

        // only use  when using applicationdbcontext
        //public bool AuthenticateUser2(NetworkCredential credential)
        //{
        //    using (var context = new YourDbContext()) // Sử dụng DbContext của bạn ở đây
        //    {
        //        var user = context.Users
        //                          .FirstOrDefault(u => u.Username == credential.UserName && u.Password == credential.Password);
        //        return user != null;
        //    }
        //}

        public void Edit(UserModel user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public UserModel GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public UserModel GetByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
