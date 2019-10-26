using System;

namespace Data
{
    [Serializable]
    public sealed class UserData
    {
        public string nickname;
        public string email;
        public string phoneNumber;
        public string city;
        public int spent;
    }
}
