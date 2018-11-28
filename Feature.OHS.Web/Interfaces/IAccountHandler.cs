using Feature.OHS.Web.ViewModels;
using System.Threading.Tasks;
using Feature.OHS.Web.ViewModels.Response;

namespace Feature.OHS.Web.Interfaces
{
    public interface IAccountHandler
    {
        Task<PersonViewModel> Register(PersonViewModel person);
        Task<APIResponse> Login(LoginViewModel model);
        Task<APIResponse> FindUserByEmail(ForgotPasswordViewModel model);
        Task<APIResponse> SetUserPasswordResetToken(UpdatePasswordResetTokenModel model);
        Task<APIResponse> ResetPasswordAsync(ResetPasswordViewModel model);
    }
}
