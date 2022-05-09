using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.ViewModel.Common
{
    public class ApiResultError<T>:ApiResult<T>
    {
        public ApiResultError(string message)
        {
            isSuucess = false;
            Messgae = message;
        }
        public ApiResultError()
        {
            isSuucess = false;
        }
    }
}
