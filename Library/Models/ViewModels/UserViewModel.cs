namespace Library.Models.ViewModels
{
    public class UserViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        internal static UserViewModel FromDTO(Library.Models.DTO.UserDTO user)
        {
            return new UserViewModel
            {
                Name = user.Name,
                Surname = user.Surname
            };
        }
    }
}