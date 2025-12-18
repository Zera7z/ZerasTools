namespace ZerasTools.Services
{
    public interface IImageConverter
    {
        string Name { get; }
        void Convert(string input, string output);
    }
}
