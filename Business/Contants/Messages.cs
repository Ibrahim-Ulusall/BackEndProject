using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Contants
{
	public static class Messages
	{
		public static string AddedMessage = "Product Added";
		public static string ProductNameInvalid = "Product name invalid";
		public static string ProductListed = "All Product Listed!";
		public static string ProductDeleted = "Product deleted";
		public static string ProductUpdated = "Product Updated.";
		public static string AuthorizationDenied = "Yetkiniz yok";
		public static string CheckIfProductCountOfCategoryCorrect = "Bir Kategoride en fazla on ürün olabilir.";
		public static string CheckIfProductNameExists = "Aynı isimde ürün sistemde mevcut!";
		public static string CheckIfCategoryCountError = "Mevcut Kategori Sayısı 15\'i Geçemez!";
		public static string FirstNameNotEmpty = "Adı alanı boş geçilemez";
		public static string LastNameNotEmpty = "Soyadı alanı boş geçilemez";
		public static string EmailNotEmpty = "Email alanı boş geçilemez";
		public static string NotEmailFormat = "Email Format Hatası";
	}
}
