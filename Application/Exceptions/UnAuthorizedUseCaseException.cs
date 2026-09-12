using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Exceptions
{
    public class UnAuthorizedUseCaseException : Exception
    {
        public UnAuthorizedUseCaseException(string username, string useCaseName)
            :base($"Korisnik {username}, nema dozvolu za {useCaseName}")
        {

        }
    }
}
