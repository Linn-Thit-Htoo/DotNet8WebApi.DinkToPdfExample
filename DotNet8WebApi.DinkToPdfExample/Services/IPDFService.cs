using DotNet8WebApi.DinkToPdfExample.Models;

namespace DotNet8WebApi.DinkToPdfExample.Services
{
    public interface IPDFService
    {
        public Task<string> GetHtml(UserModel user);
        public Task<byte[]> GeneratePdf()l+;
    }
}
