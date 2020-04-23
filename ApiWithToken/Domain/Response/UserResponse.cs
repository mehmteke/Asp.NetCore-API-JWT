using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWithToken.Domain.Response
{
    public class UserResponse:BaseResponse
    {
        public User user { get; set; }
        private UserResponse(bool success, string message):base(success,message)
        {
        }

        public UserResponse(User user):this(true,"")
        {
            this.user = user;
        }

        public UserResponse(string message):this(false,message)
        {
        }
    }
}
