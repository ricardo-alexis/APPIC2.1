using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Globalization;
using Newtonsoft.Json.Converters;

namespace PSMA
{
    public partial class Form1 : Form
    {
        HttpClient client = new HttpClient();
        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await GetTodoItems();

        }
        private async Task GetTodoItems()
        {
            string response = await client.GetStringAsync("https://covid-19.dataflowkit.com/v1");
            List<Model> covid = JsonConvert.DeserializeObject<List<Model>>(response);
            foreach (var datos in covid)
            {
                string parsedActiveCasesText = datos.ActiveCasesText;
                string parsedCountryText = datos.CountryText;
                string parsedLastUpdate = datos.LastUpdate;
                string parsedNewCasesText = datos.NewCasesText;
                string parsedNewDeathsText = datos.NewDeathsText;
                string parsedTotalCasesText = datos.TotalCasesText;
                string parsedTotalDeathsText = datos.TotalDeathsText;
                string parsedTotalRecoveredText = datos.TotalRecoveredText;
                


                string[] row = { parsedActiveCasesText, parsedCountryText, parsedLastUpdate,parsedNewCasesText,parsedNewDeathsText,parsedTotalCasesText,parsedTotalDeathsText,parsedTotalRecoveredText };
                var listViewItems = new ListViewItem(row);
                listView1.Items.Add(listViewItems);
            }
        }

        private  void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
           

        }
        public partial class Model
        {
            [JsonProperty("Active Cases_text", NullValueHandling = NullValueHandling.Ignore)]
            public string ActiveCasesText { get; set; }

            [JsonProperty("Country_text", NullValueHandling = NullValueHandling.Ignore)]
            public string CountryText { get; set; }

            [JsonProperty("Last Update", NullValueHandling = NullValueHandling.Ignore)]
            public string LastUpdate { get; set; }

            [JsonProperty("New Cases_text", NullValueHandling = NullValueHandling.Ignore)]
            public string NewCasesText { get; set; }

            [JsonProperty("New Deaths_text", NullValueHandling = NullValueHandling.Ignore)]
            public string NewDeathsText { get; set; }

            [JsonProperty("Total Cases_text", NullValueHandling = NullValueHandling.Ignore)]
            public string TotalCasesText { get; set; }

            [JsonProperty("Total Deaths_text", NullValueHandling = NullValueHandling.Ignore)]
            public string TotalDeathsText { get; set; }

            [JsonProperty("Total Recovered_text", NullValueHandling = NullValueHandling.Ignore)]
            public string TotalRecoveredText { get; set; }
        }
    }
}
