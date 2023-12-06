using Service.DTOs.Requests;

namespace Service.Extensions
{
    public static class ValidateJobApplicationRequest
    {
        public static JobApplicationRequest ValidadeJobRequest(this JobApplicationRequest entity)
        {
            entity.Status ??= (int)Enums.Status.Applied;
            entity.Type ??= (int)Enums.Types.Remote;


            if (string.IsNullOrEmpty(entity.CompanyName))
                throw new Exception("Company name is required");

            if (string.IsNullOrEmpty(entity.Role))
                throw new Exception("Role is required");

            if (entity.UserId == 0)
                throw new Exception("UserId is required");

            if (entity.Type >= 3 || entity.Type < 0)
                throw new IndexOutOfRangeException("The type must be between 0 and 2");

            return entity;
        }
    }
}