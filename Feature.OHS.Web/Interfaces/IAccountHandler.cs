using Feature.OHS.Web.ViewModels;
using System.Threading.Tasks;
using Feature.OHS.Web.ViewModels.Response;

namespace Feature.OHS.Web.Interfaces
{
    public interface IAccountHandler
    {
        //  REGISTRATION/LOGIN STARTS HERE
        Task<PersonViewModel> Register(PersonViewModel person);
        Task<APIResponse> Login(LoginViewModel model);

        //  FORGOT PASSWORD STARTS HERE
        //Task<APIResponse> FindUserByEmail(ForgotPasswordViewModel model);
        Task<UserViewModel> FindUserByEmail(ForgotPasswordViewModel model);
        Task<APIResponse> SetUserPasswordResetToken(UpdatePasswordResetTokenModel model);
        Task<APIResponse> ResetPasswordAsync(ResetPasswordViewModel model);
    }
}
