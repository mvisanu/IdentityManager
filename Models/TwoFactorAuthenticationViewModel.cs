namespace IdentityManager.Models
{
    public class TwoFactorAuthenticationViewModel
    {
        //user to login
        public string Code { get; set; }

        //use to register
        public string Token { get; set; }

        public string QRCodeUrl { get; set; }
    }
}
