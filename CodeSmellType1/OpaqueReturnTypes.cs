using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSmellType1
{
    public class OpaqueReturnTypes
    {
        // Opaque return types are types that do not reveal much about their structure or behavior.
        // Assuming that if the method works there wont be any exceptions
        public void Register(string username,string email)
        {

        }

        // Better approach is to return a result boolen or throw specific exceptions
        public bool Register2(string userName,string email)
        {

            return false;
        }

        // Approch 2
        public bool Register3(string userName, string email)
        {

            // Boundary Conditions
            throw new InvalidOperationException("Could not complete registration");
        }


    }

    //Result Patten
    public class Result<T>
    {
        public bool IsSuccess { get; }
        public T Value { get; }
        public string ErrorMessage { get; }
        private Result(bool isSuccess, T value, string errorMessage)
        {
            IsSuccess = isSuccess;
            Value = value;
            ErrorMessage = errorMessage;
        }
        public static Result<T> Success(T value) => new Result<T>(true, value, null);
        public static Result<T> Failure(string errorMessage) => new Result<T>(false, default, errorMessage);
    }


    public class RegistrationServiceWithResult
    {
        public Result<int> RegisterUser(string userName,string email)
        {
            if(string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(email))
            {
                return Result<int>.Failure("Username and Email cannot be empty");
            }


            //We simulate a successful registration and return a user ID
            int userId = new Random().Next(1, 1000);
            return Result<int>.Success(userId);
        }
    }

    public class LoginService
    {
        public static Result<string> Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return Result<string>.Failure("Username and Password cannot be empty");
            }
            // Simulate a successful login and return a token
            string token = Guid.NewGuid().ToString();
            return Result<string>.Success(token);
        }
    }
}
