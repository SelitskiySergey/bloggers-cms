namespace Pds.Core.Exceptions
{
    public static class ExceptionHelper
    {
        public static NotFoundException CreateNotFoundException(string resourceName)
        {
            return new(resourceName);
        }
    }
}