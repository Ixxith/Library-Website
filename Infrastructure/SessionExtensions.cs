using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Library_Website.Infrastructure
{
    // This class is a tool used to seralize and deserialize the cart object to json to be stored in the session
    public static class SessionExtensions
    {
        // Sets the session string
        public static void SetJson (this ISession sesstion, string key, object value)
        {
            sesstion.SetString(key, JsonSerializer.Serialize(value));
        }
        // Retrieves the session string
        public static T GetJson<T> (this ISession session, string key)
        {
            var sessionData = session.GetString(key);
            return sessionData == null ? default(T) : JsonSerializer.Deserialize<T>(sessionData);
        }
    }
}
