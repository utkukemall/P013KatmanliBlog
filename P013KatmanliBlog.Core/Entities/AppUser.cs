﻿using System.ComponentModel.DataAnnotations;

namespace P013KatmanliBlog.Core.Entities
{
    public class AppUser : IEntity
    {
        public int Id { get; set; }
        [Display(Name = "Ad"), Required(ErrorMessage ="{0} Alanı Gereklidir!")]
        public string Name { get; set; }
        [Display(Name = "Soyad")]
        public string? Surname { get; set; }
        [Required(ErrorMessage = "{0} Alanı Gereklidir!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "{0} Alanı Gereklidir!")]
        [Display(Name = "Şifre")]
        public string Password { get; set; }
        [Display(Name = "Kullanıcı Adı")]
        public string? UserName { get; set; }
        [Display(Name = "Kullanıcı Profil Fotoğrafı")]
        public string? ProfilePhoto { get; set; }
        [Display(Name = "Telefon")]
        public string? Phone { get; set; }
        [Display(Name = "Durum?")]
        public bool IsActive { get; set; }
        [Display(Name = "Admin?")]
        public bool IsAdmin { get; set; }
        [Display(Name = "Eklenme Tarihi"), ScaffoldColumn(false)]
        public DateTime? CreateDate { get; set; } = DateTime.Now;
        [ScaffoldColumn(false)]
        public Guid? UserGuid { get; set; }
    }
}
