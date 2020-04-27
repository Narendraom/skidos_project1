namespace ServerManagment
{
    /// <summary>
    /// Interface for API Response
    /// </summary>
    public interface IResponse
    {

        void Success(string response);

        void Failed(string error);
    }

}