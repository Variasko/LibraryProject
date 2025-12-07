using LibrarryDesktop.Models.ApiResponceModels;

namespace LibrarryDesktop.Statics
{
    public static class CurrentSession
    {
        public static Employee CurrentEmployee { get; set; }
        public static Post CurrentPost { get; set; }
    }
}
