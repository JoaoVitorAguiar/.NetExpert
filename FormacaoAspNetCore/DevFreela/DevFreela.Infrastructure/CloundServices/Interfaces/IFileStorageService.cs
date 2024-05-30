namespace DevFreela.Infrastructure.CloundServices.Interfaces;

public interface IFileStorageService
{
    void UploadFile(byte[] file, string fileName);
}
