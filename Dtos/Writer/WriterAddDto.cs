namespace Dtos.Writer
{
    public class WriterAddDto
    {
        public int WriterId { get; set; }

        public string Name { get; set; }

        public string About { get; set; }

        public string Image { get; set; }

        public string Mail { get; set; }

        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
        public bool Status { get; set; }

    }
}
