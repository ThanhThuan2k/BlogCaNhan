using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BlogCaNhan.Web.Common
    public class PasswordHelper
    {
        // LUÔN GIỮ ĐỘ DÀI CHUỖI = 256
        // KHÔNG ĐƯỢC XÓA/THÊM GÌ VÀO DÒNG NÀY
        // KHÔNG ĐƯỢC ĐỂ XUẤT HIỆN 2 GIÁ TRỊ GIỐNG NHAU
        const string COLLECTION_CHARS = @"ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789`~!@#$%^&*()_-+={[}]\|;:""\'<,>.?/abcdefghijklmnopqrstuvwxyzđáàảãạăắằẵẳặâấầẩẫậíìỉĩịúùủũụéèẻẽẹêếềễểệóòỏõọôốồổỗộơớờởỡợưứừửữựýỳỷỹỵĐÁÀẢÃẠĂẮẰẴẲẶÂẤẦẨẪẬÍÌỈĨỊÚÙỦŨỤÉÈẺẼẸÊẾỀỄỂỆÓÒỎÕỌÔỐỒỔỖỘƠỚỜỞỠỢƯỨỪỬỮỰÝỲỶỸỴƵƶẐẑĎďĆćĈĉČčḨḩḤḥḪḫṰṱṮṯŦŧȾⱦț";

        public static string CreateSalt(int min, int max)
        {
            const string mailCOLLECTION_CHARS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random rand = new Random();
            char[] salt = new char[rand.Next(min, max)];
            for (int i = 0; i < salt.Length; i++)
            {
                salt[i] = mailCOLLECTION_CHARS[rand.Next(mailCOLLECTION_CHARS.Length)];
            }

            string result = new String(salt);
            return result;
        }

        /// <summary>
        /// Mã hóa mật khẩu theo phương pháp SHA512
        /// </summary>
        /// <param name="plainText">Mật khẩu cần được mã hóa</param>
        /// <param name="salt">Chuỗi bổ sung tăng độ mạnh</param>
        /// <returns>Mật khẩu sau khi mã hóa có độ dài cố định 64 ký tự</returns>
        public static string EncryptSHA512(string plainText, string salt = "")
        {
            var sha512Hash = new SHA512Managed();
            string mixedPassword = plainText + salt + salt.Length.ToString();
            byte[] crypto = sha512Hash.ComputeHash(Encoding.UTF8.GetBytes(mixedPassword));
            string encodedPassword = string.Empty;
            foreach (byte theByte in crypto)
            {
                encodedPassword += COLLECTION_CHARS[(int)theByte % COLLECTION_CHARS.Length];
            }
            return encodedPassword;
        }

        public static string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                + "_" + Guid.NewGuid().ToString().Substring(0, 4)
                + Path.GetExtension(fileName);
        }
    }
}
