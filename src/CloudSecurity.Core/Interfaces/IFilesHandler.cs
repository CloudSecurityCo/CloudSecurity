using CloudSecurity.Core.Entities;

namespace CloudSecurity.Core.SharedKernel
{
    public interface IFilesHandler
    {
        string[] GetUserSignaturesPathsByUser(User user);
        string GetUserConfigurationPathByUser(User user);
    }
}