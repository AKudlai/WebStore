namespace WebStore.Services
{
    public class EmailSettings
    {
        public string MailToAddress { get; set; } = "akudlay@hotmail.com";

        public string MailFromAddress { get; set; } = "market@kudlai.com";

        public bool UseSsl { get; set; } = true;

        public string Username { get; set; } = "MySmtpUsername";

        public string Password { get; set; } = "MySmtpPassword";

        public string ServerName { get; set; } = "smtp.example.com";

        public int ServerPort { get; set; } = 587;

        public bool WriteAsFile { get; set; } = true;

        public string FileLocation { get; set; } = @"c:\web_store_emails";
    }
}
