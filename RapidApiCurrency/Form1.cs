using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;
using System.Windows.Forms;

namespace RapidApiCurrency
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        decimal dolar = 0;
        decimal euro = 0;
        decimal sterlin = 0;
        #region Dollar
        private async void Form1_Load(object sender, EventArgs e)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://currency-conversion-and-exchange-rates.p.rapidapi.com/convert?from=USD&to=TRY&amount=1"),
                Headers =
    {
        { "x-rapidapi-key", "b8aa8b5f1emsh04184a6f31c146cp142076jsn0c0742a95b28" },
        { "x-rapidapi-host", "currency-conversion-and-exchange-rates.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var json = JObject.Parse(body);
                var value = json["result"].ToString();
                lblDollar.Text = "Dolar: " +value;
                dolar = decimal.Parse(value);
                Console.WriteLine(body);
            }
            #endregion
        #region Euro
            var client2 = new HttpClient();
    var request2 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://currency-conversion-and-exchange-rates.p.rapidapi.com/convert?from=EUR&to=TRY&amount=1"),
                Headers =
    {
        { "x-rapidapi-key", "b8aa8b5f1emsh04184a6f31c146cp142076jsn0c0742a95b28" },
        { "x-rapidapi-host", "currency-conversion-and-exchange-rates.p.rapidapi.com" },
    },
            };
            using (var response2 = await client2.SendAsync(request2))
            {
                response2.EnsureSuccessStatusCode();
                var body = await response2.Content.ReadAsStringAsync();
                var json2 = JObject.Parse(body);
                var value2 = json2["result"].ToString();
                lblEuro.Text = "Euro: "+ value2;
                euro = decimal.Parse(value2);
                Console.WriteLine(body);
            }
            #endregion
        #region Sterlin
    var client3 = new HttpClient();
    var request3 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://currency-conversion-and-exchange-rates.p.rapidapi.com/convert?from=GBP&to=TRY&amount=1"),
                Headers =
    {
        { "x-rapidapi-key", "b8aa8b5f1emsh04184a6f31c146cp142076jsn0c0742a95b28" },
        { "x-rapidapi-host", "currency-conversion-and-exchange-rates.p.rapidapi.com" },
    },
            };
            using (var response3 = await client3.SendAsync(request3))
            {
                response3.EnsureSuccessStatusCode();
                var body = await response3.Content.ReadAsStringAsync();
                var json3 = JObject.Parse(body);
                var value3= json3["result"].ToString();
                lblPound.Text = "Sterlin: "+ value3;
                sterlin = decimal.Parse(value3);
                Console.WriteLine(body);
            }
            #endregion
            txtTotalPrice.Enabled = false;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            decimal unitPrice = decimal.Parse(txtUnitPrice.Text);
            decimal totalPrice = 0;

            if (rdbDollar.Checked)
            {
                totalPrice = unitPrice * dolar;
            }
            if (rdbEuro.Checked)
            {
                totalPrice = unitPrice * euro;
            }
            if (rdbPound.Checked)
            {
                totalPrice = unitPrice * sterlin;
            }
            txtTotalPrice.Text = totalPrice.ToString();
        }
    }
}
