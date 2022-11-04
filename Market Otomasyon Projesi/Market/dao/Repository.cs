using Market.enumeration;
using Market.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.dao
{
    public class Repository
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        int returnValue;

        List<LoginTable> loginTableList;
        public Repository()
        {
            //3-Bu yapıcı metot ile SqlConnection bağlantımızı sağladık.
            con = new SqlConnection("Data Source=DESKTOP-CMDAG63\\SQLEXPRESS;Initial Catalog=MarketDatabase;User ID=sa;password=1");           
        }

        public void baglantiAyarla()
        {
            if(con.State == System.Data.ConnectionState.Closed)
            //benim eğer ki connection bağlantım kapalıysa 
            {
                con.Open(); //bu bağlantıyı Open()'la aç.
            }
            else
            {
                con.Close(); //açıksa da Close()' ile kapat.
            }
        }

        public User login(string kullaniciAdi, string sifre)
        {

            con.Open();
            cmd = new SqlCommand("select * from loginTable where kullaniciAdi=@kulad and sifre=@sifre", con);
            cmd.Parameters.AddWithValue("@kulad", kullaniciAdi);
            cmd.Parameters.AddWithValue("@sifre", sifre);
            dr = cmd.ExecuteReader();

            if(dr.Read())
            {
                User user = new User();

                user.id = int.Parse(dr["id"].ToString());
                user.kullaniciAdi = dr["kullaniciAdi"].ToString();
                user.sifre = dr["sifre"].ToString();
                user.yetki = dr["yetki"].ToString();
                user.emailAdres = dr["emailAdres"].ToString();
                user.guvenlikSorusu = dr["guvenlikSorusu"].ToString();
                user.guvenlikCevabi = dr["guvenlikCevabi"].ToString();
                user.status = LoginStatus.basarili;

                return user;
            }
            else
            {
                User user = new User();
                user.status = LoginStatus.basarisiz;
                return user;
            }
        }

        public List<LoginTable> getLoginTable()
        {
            loginTableList = new List<LoginTable>();

            con.Open();
            cmd = new SqlCommand("guvenlikSorusuGetir_sp", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            dr = cmd.ExecuteReader();

            while(dr.Read())
            {
                LoginTable loginTable = new LoginTable();
                loginTable.id = int.Parse(dr["id"].ToString());
                loginTable.kullaniciAdi = dr["kullaniciAdi"].ToString();
                loginTable.sifre = dr["sifre"].ToString();
                loginTable.yetki = dr["yetki"].ToString();
                loginTable.emailAdres = dr["emailAdres"].ToString();
                loginTable.guvenlikSorusu = dr["guvenlikSorusu"].ToString();
                loginTable.guvenlikCevabi = dr["guvenlikCevabi"].ToString();

                loginTableList.Add(loginTable);
            }
            con.Close();
            return loginTableList;
        }

        public LoginStatus doAuthentication(string kullaniciAdi, string guvenlikSorusu, string guvenlikCevabi)
        {
            con.Open();
            cmd = new SqlCommand("select count(*) from loginTable where kullaniciAdi=@kulad and guvenlikSorusu=@guvSorusu and guvenlikCevabi=@guvCevap", con);
            cmd.Parameters.AddWithValue("@kulad", kullaniciAdi);
            cmd.Parameters.AddWithValue("@guvSorusu", guvenlikSorusu);
            cmd.Parameters.AddWithValue("@guvCevap", guvenlikCevabi);
            returnValue = (int)cmd.ExecuteScalar();

            con.Close();

            if (returnValue == 1)           
                return LoginStatus.basarili;          
            else
                return LoginStatus.basarisiz;
        }

        public LoginStatus changePassword(string kullaniciAdi, string sifre)
        {
            con.Open();

            cmd = new SqlCommand("sifreGuncelle_sp",con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@kullaniciAdi", kullaniciAdi);
            cmd.Parameters.AddWithValue("@sifre", sifre);

            returnValue = cmd.ExecuteNonQuery();
       
            con.Close();

            return LoginStatus.basarili;
        }

        public string checkEmailAddress(string kullaniciAdi)
        {
            con.Open();
            cmd = new SqlCommand("select emailAdres from loginTable where kullaniciAdi = @kulad", con);
            cmd.Parameters.AddWithValue("@kulad", kullaniciAdi);
            string emailAdres = (string)cmd.ExecuteScalar();
            con.Close();

            return emailAdres;
        }

        public Urun urunuGetir(string barkod)
        {
            con.Open();
            Urun urun = new Urun();

            cmd = new SqlCommand("select * from urun where barkodKod = @code", con);
            cmd.Parameters.AddWithValue("@code", barkod);
            dr = cmd.ExecuteReader();
            
            while(dr.Read())
            {
                urun.id = dr["id"].ToString();
                urun.qrKod = dr["qrKod"].ToString();
                urun.barkodKod = dr["barkodKod"].ToString();               
                urun.urunIsim = dr["urunIsim"].ToString();
                urun.kilo = int.Parse(dr["kilo"].ToString());
                urun.fiyat = int.Parse(dr["fiyat"].ToString());
            }
            con.Close();

            return urun;
        }

        public List<User> tumKullanicilariGetir()
        {
            List<User> userList = new List<User>(); 
            con.Open();
            cmd = new SqlCommand("select * from loginTable", con);
            dr = cmd.ExecuteReader();

            while (dr.Read()) 
            { 
                User user = new User();
                user.id = int.Parse(dr["id"].ToString());
                user.kullaniciAdi = dr["kullaniciAdi"].ToString();
                user.sifre = dr["sifre"].ToString();
                user.yetki = dr["yetki"].ToString();
                user.bolge = dr["bolge"].ToString();
                user.emailAdres = dr["emailAdres"].ToString();
                user.guvenlikSorusu = dr["guvenlikSorusu"].ToString();
                user.guvenlikCevabi = dr["guvenlikCevabi"].ToString();
                userList.Add(user);
            }

            con.Close();
            return userList;
        }

        public LoginStatus kullaniciEkle(User user)
        {
            con.Open();
            cmd = new SqlCommand("sp_kullaniciEkle", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@kullaniciAdi", user.kullaniciAdi);
            cmd.Parameters.AddWithValue("@sifre", user.sifre);
            cmd.Parameters.AddWithValue("@yetki", user.yetki);
            cmd.Parameters.AddWithValue("@bolge", user.bolge);
            cmd.Parameters.AddWithValue("@emailAdres", user.emailAdres);
            cmd.Parameters.AddWithValue("@guvenlikSorusu", user.guvenlikSorusu);
            cmd.Parameters.AddWithValue("@guvenlikCevabi", user.guvenlikCevabi);

            int returnValue = cmd.ExecuteNonQuery();

            con.Close();

            if (returnValue == 1)
                return LoginStatus.basarili;
            else
                return LoginStatus.basarisiz;
            
            
        }

        public LoginStatus kullaniciGuncelle(User user)
        {
            con.Open();
            cmd = new SqlCommand("sp_kullaniciGuncelle", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", user.id);
            cmd.Parameters.AddWithValue("@kullaniciAdi", user.kullaniciAdi);
            cmd.Parameters.AddWithValue("@sifre", user.sifre);
            cmd.Parameters.AddWithValue("@yetki", user.yetki);
            cmd.Parameters.AddWithValue("@bolge", user.bolge);
            cmd.Parameters.AddWithValue("@emailAdres", user.emailAdres);
            cmd.Parameters.AddWithValue("@guvenlikSorusu", user.guvenlikSorusu);
            cmd.Parameters.AddWithValue("@guvenlikCevabi", user.guvenlikCevabi);

            int returnValue = cmd.ExecuteNonQuery();
            con.Close();

            if (returnValue == 1)
                return LoginStatus.basarili;
            else
                return LoginStatus.basarisiz;

            
        }
        public LoginStatus kullaniciSil(int id)
        {
            con.Open();
            cmd = new SqlCommand("delete from loginTable where id=@id", con);
            cmd.Parameters.AddWithValue("@id", id);
            int returnValue = cmd.ExecuteNonQuery();
            con.Close();

            if (returnValue == 1)
            {
                return LoginStatus.basarili;
            }
            else
                return LoginStatus.basarisiz;
        }
        public List<Urun> tumUrunleriGetir( )
        {
            con.Open();
            List<Urun> urunList = new List<Urun>();

            cmd = new SqlCommand("select * from urun", con);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Urun urun = new Urun();
                urun.id = dr["id"].ToString();
                urun.qrKod = dr["qrkod"].ToString();
                urun.barkodKod = dr["barkodKod"].ToString();
                urun.olusturulmaTarih = DateTime.Parse(dr["olusturulma_Tarih"].ToString());

                if (!string.IsNullOrEmpty(dr["guncellenme_Tarih"].ToString()))
                {
                    urun.guncellenmeTarih = DateTime.Parse(dr["guncellenme_Tarih"].ToString());
                }
                urun.urunIsim = dr["urunIsim"].ToString();
                urun.kilo = int.Parse(dr["kilo"].ToString());
                urun.fiyat = int.Parse(dr["fiyat"].ToString());
                urun.ciro = int.Parse(dr["ciro"].ToString());
                urunList.Add(urun);
            }
            con.Close();

            return urunList;
        }
        public LoginStatus urunEkle(Urun urun)
        {
            con.Open();
            cmd = new SqlCommand("sp_urunEkle", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", urun.id);
            cmd.Parameters.AddWithValue("@qrkod", urun.qrKod);
            cmd.Parameters.AddWithValue("@barkodKod", urun.barkodKod);
            cmd.Parameters.AddWithValue("@olusturulma_Tarih", urun.olusturulmaTarih);
            cmd.Parameters.AddWithValue("@guncellenme_Tarih", urun.guncellenmeTarih);
            cmd.Parameters.AddWithValue("@urunIsim", urun.urunIsim);
            cmd.Parameters.AddWithValue("@kilo", urun.kilo);
            cmd.Parameters.AddWithValue("@fiyat", urun.fiyat);
            cmd.Parameters.AddWithValue("@ciro", urun.ciro);
            int returnValue = cmd.ExecuteNonQuery();
            con.Close();

            if (returnValue == 1)
                return LoginStatus.basarili;
            return LoginStatus.basarisiz;
        }
        public LoginStatus urunGuncelle(Urun urun)
        {
            con.Open();
            cmd = new SqlCommand("sp_urunGuncelle", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", urun.id);
            cmd.Parameters.AddWithValue("@qrkod", urun.qrKod);
            cmd.Parameters.AddWithValue("@barkodKod", urun.barkodKod);
            cmd.Parameters.AddWithValue("@olusturulma_Tarih", urun.olusturulmaTarih);
            cmd.Parameters.AddWithValue("@guncellenme_Tarih", urun.guncellenmeTarih);
            cmd.Parameters.AddWithValue("@urunIsim", urun.urunIsim);
            cmd.Parameters.AddWithValue("@kilo", urun.kilo);
            cmd.Parameters.AddWithValue("@fiyat", urun.fiyat);
            cmd.Parameters.AddWithValue("@ciro", urun.ciro);
            int returnValue = cmd.ExecuteNonQuery();
            con.Close();

            if (returnValue == 1)
                return LoginStatus.basarili;
            return LoginStatus.basarisiz;
        }

        public LoginStatus urunSil(string id)
        {
            con.Open();
            cmd = new SqlCommand("delete from urun where id=@id", con);
            cmd.Parameters.AddWithValue("@id",id);
            int returnValue = cmd.ExecuteNonQuery();
            con.Close();

            if (returnValue == 1)
                return LoginStatus.basarili;
            return LoginStatus.basarisiz;
        }
    }
}
