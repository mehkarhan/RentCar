using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constant
{
    public class Messages
    {
        public static string MaintenanceTime = "Sistem Bakımda";

        public static string CarAdded = "Araç Eklendi";
        public static string CarDescriptionInvalid = "En az 5 karakter olmalı";
        public static string CarListed="Araçlar listelendi";
        public static string CarDeleted="Araç silindi";
        public static string CarUpdated="Araç güncellemesi yapıldı";

        public static string BrandAdded = "Marka Eklendi";
        public static string BrandDeleted = "Marka silindi";
        public static string BrandUpdated = "Marka güncellemesi yapıldı";
        public static string BrandListed = "Araçlar listelendi";
        public static string BrandinvalidName = "En az 3 karakter olmalı";

        public static string ColorAdded = "Renk Eklendi";
        public static string ColorDeleted = "Renk silindi";
        public static string ColorUpdated = "Renk güncellemesi yapıldı";
        public static string ColorInvalidName = "En az 3 karakter olmalı";
        public static string ColorListed = "Araçlar listelendi";
        
        public static string CustomerAdded = "Müşteri Eklendi";
        public static string CustomerDeleted = "Müşteri Silindi";
        public static string CustomerUpdated = "Müşteri Güncellendi";
        public static string CustomerListed = "Müşteri Listelendi";

        public static string UserAdded = "Kullanıcı eklendi.";
        public static string UserDeleted = "Kullanıcı silindi.";
        public static string UserUpdated = "Kullanıcı güncellendi.";
        public static string UserListed = "Kullanıcı listelendi.";

        public static string RentalAdded = "Araç kiralandı.";
        public static string RentalDeleted = "Araç kiralama bilgileri silindi.";
        public static string RentalAddedInvalid = "Araç kiralanamaz.";
        public static string RentalListed = "Araç kiralama bilgileri listelendi.";
        public static string RentalUpdated = "Araç kiralama bilgileri güncellendi.";
    }
}
