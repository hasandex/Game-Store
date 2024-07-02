namespace GameZone.ViewModel
{
    public class EditGameFormViewModel : GameForm
    {
        public int Id { get; set; }
        public string? CurrentCover { get; set; }
        public IFormFile? Cover { get; set; }
    }
}
