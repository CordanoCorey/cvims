using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Threading.Tasks;
using CVIMS.Api.Infrastructure.Auth;
using CVIMS.Api.Infrastructure.Models;

namespace CVIMS.Api.Infrastructure.Services
{
    public class Helpers
    {
        public static bool IsNullOrDefault<T>(T argument)
        {
            // deal with normal scenarios
            if (argument == null) return true;
            if (object.Equals(argument, default(T))) return true;

            // deal with non-null nullables
            Type methodType = typeof(QueryModel<T>);
            if (Nullable.GetUnderlyingType(methodType) != null) return false;

            // deal with boxed value types
            Type argumentType = argument.GetType();
            var typeInfo = argumentType.GetTypeInfo();
            if (typeInfo.IsValueType && argumentType != methodType)
            {
                object obj = Activator.CreateInstance(argument.GetType());
                return obj.Equals(argument);
            }

            return false;
        }
    }
}
