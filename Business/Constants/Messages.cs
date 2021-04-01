using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
	public class Messages
	{
		public static string CarAdded = "Araba eklendi";
		public static string CarAddedError = "Araba Eklenemedi";
		public static string CarNameInvalid = "Araba ismi geçersiz"; 
		public static string CarPriceInvalid = "Araba fiyatı 0 veya 0 dan küçük olamaz.";
		public static string CarDeleted = "Araba silindi";
		public static string CarUpdated = "Araba bilgileri güncellendi";
		public static string CarUpdatedError = "Araba bilgileri güncellenemedi";
		public static string CarListed = "Arabalar Listelendi";

		public static string ColorAdded = "Renk Eklendi";
		public static string ColorUpdated = "Renk Güncellendi";
		public static string ColorDeleted = "Renk Silindi";

		public static string BrandAdded = "Marka Eklendi";
		public static string BrandAddedError = "Marka ismi en az 2 karakterden olmalı";
		public static string BrandNameInvalid = "Marka İsmi Geçersiz";		
		public static string BrandUpdated = "Marka İsmi Güncellendi";
		public static string BrandUpdatedError = "Marka ismi en az 2 karakter olmalı";
		public static string BrandDeleted = "Marka İsmi Silindi";

		public static string MaintenanceTime = "Sistem Bakımda";

		public static string CustomerAdded = "Müşteri Eklendi";
		public static string CustomerUpdated = "Müşteri GÜncellendi";
		public static string CustomerDeleted = "Müşteri Silindi";

		public static string UserAdded = "Kullanıcı Eklendi";
		public static string UserUpdated = "Kulllanıcı Güncellendi";
		public static string UserDeleted = "Kullanıcı Silindi";

		public static string RentalAdded = "Araba Kiralama İşlemi Gerçekleşti";
		public static string RentalUpdated = "Araba Kiralama İşlemi Güncellendi";
		public static string RentalDeleted = "Araba Kiralama İşlemi İptal Edildi";
		public static string FailedRentalAddOrUpdate = "Araba teslim edilmediği için kiralayamazsınız.";
		public static string ReturnedRental = "Kiraladığınız araç teslim edildi.";


		public static string CarImageCountError = " Bir araba için maksimum 5 resim yüklenebilir.";
		public static string CarImagesAdded = "Araba fotoğrafı eklendi";
		public static string CarImagesListed = "Araba fotoğrafları listelendi";
		public static string CarImagesUpdated = "Araba fotoğrafları güncellendi";
		public static string CarImageDeleted = "Araba fotoğrafı silindi";
		public static string CarImagesNotFound = "Araba resmi sistemde bulunmamaktadır";

		public static string AuthorizationDenied = "Yetkiniz yok";
		public static string UserNotFound = "Kullanıcı bulunamadı";
		public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";
		public static string AccessTokenCreated = "Access token başarıyla oluşturuldu";
		public static string PasswordError = "Şifre hatalı";
		public static string SuccessfulLogin = "Sisteme giriş başarılı";
		public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
	}
}
