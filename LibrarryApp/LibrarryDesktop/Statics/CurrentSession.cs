using LibraryDesktop.Models.ApiResponceModels;

namespace LibraryDesktop.Statics
{
    public static class CurrentSession
    {
        public static Employee CurrentEmployee { get; set; }
        public static Post CurrentPost { get; set; }
    }
}
