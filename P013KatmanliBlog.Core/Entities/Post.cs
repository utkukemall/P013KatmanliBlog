using System.ComponentModel.DataAnnotations;

namespace P013KatmanliBlog.Core.Entities
{
    public class Post : IEntity
    {
        public int Id { get; set; }
        [Display(Name = "Başlık")]
        public string Title { get; set; }
        [Display(Name = "İçerik")]
        public string Content { get; set; }
        [Display(Name = "Kategori")]
        public int CategoryId { get; set; }
        [Display(Name = "Kategori")]
        public Category? Category { get; set; }
        [Display(Name = "Yazar")]
        public int AppUserId { get; set; }
        [Display(Name = "Yazar")]
        public AppUser? AppUser { get; set; }
        [Display(Name = "Eklenme Tarihi"), ScaffoldColumn(false)]
        public DateTime? CreateDate { get; set; } = DateTime.Now;

    }
}
