using System;
using System.Collections.Generic;
using System.Text;
using CloudSecurity.Core.Entities;

namespace CloudSecurity.Core.SharedKernel
{
    public class FilesHandler : IFilesHandler
    {
        public string GetUserConfigurationPathByUser(User user)
        {
            throw new NotImplementedException();
        }

        public string[] GetUserSignaturesPathsByUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
