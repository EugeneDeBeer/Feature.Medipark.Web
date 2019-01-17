using Feature.OHS.Web.ViewModels;
using System.Threading.Tasks;
using Feature.OHS.Web.ViewModels.Response;
using System;

namespace Feature.OHS.Web.Interfaces
{
    public interface IAccountHandler
    {
        //  REGISTRATION/LOGIN STARTS HERE
        Task<PersonViewModel> Register(PersonViewModel person);
        Task<APIResponse> Login(LoginViewModel model);

        //  Roles
        Task<APIResponse> GetAllRoles();

        //  FORGOT PASSWORD STARTS HERE
        //Task<APIResponse> FindUserByEmail(ForgotPasswordViewModel model);
        Task<UserViewModel> FindUserByEmail(ForgotPasswordViewModel model);
        Task<APIResponse> SetUserPasswordResetToken(UpdatePasswordResetTokenModel model);
        Task<APIResponse> ResetPasswordAsync(ResetPasswordViewModel model);
        String GeneratePasswordResetToken();
        dynamic SendEmail(MailViewModel mailViewModel);

    }
}
