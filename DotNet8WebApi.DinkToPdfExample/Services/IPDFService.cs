namespace DotNet8WebApi.DinkToPdfExample.Services;

public interface IPDFService
{
    public Task<string> GetHtml(UserModel user);
    public Task<byte[]> GeneratePdf(string htmlContent);
}
