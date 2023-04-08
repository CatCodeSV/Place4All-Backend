using System;

namespace Place4AllBackend.Application.Common.Exceptions
{
    public class ForbiddenAccessException : Exception
    {
        public ForbiddenAccessException() : base()
        {
        }
    }
}