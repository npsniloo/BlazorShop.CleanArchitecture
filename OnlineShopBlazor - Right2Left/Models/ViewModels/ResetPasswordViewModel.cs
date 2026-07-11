namespace OnlineShopBlazor.Models.ViewModels
{
    public class ResetPasswordViewModel
    {
        public string Email { get; set; }
        public string NewPassword { get; set; }
        public int RecoveryCode { get; set; }
    }
}
