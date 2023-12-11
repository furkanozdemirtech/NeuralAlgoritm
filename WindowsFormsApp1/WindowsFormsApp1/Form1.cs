using Accord.Neuro;
using Accord.Neuro.Learning;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static List<Movie> VerileriOku(string dosyaYolu)
        {
            List<Movie> filmler = new List<Movie>();
            try
            {
                using (StreamReader sr = new StreamReader(dosyaYolu))
                {
                    string baslikSatiri = sr.ReadLine();
                    while (!sr.EndOfStream)
                    {
                        string satir = sr.ReadLine();
                        string[] veri = satir.Split(',');
                        Movie movie = new Movie
                        {
                            Img_Url = veri[0],
                            Title = veri[1],
                            Year = veri[2],
                            Certificate = veri[3],
                            Duration = veri[4],
                            Genre = veri[5],
                            Imdb = veri[6],
                            Metascore = veri[7],
                            Overview = veri[8],
                            Director = veri[9],
                            Actors = veri[10],
                        };
                        filmler.Add(movie);
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
            return filmler;
        }
        static double[][] GetInputsFromMovies(List<Movie> movies)
        {
            return movies.Select(movie => new double[] { movie.Title.Length, movie.Genre.Length }).ToArray();
        }

        static double[] GetOutputsFromMovies(List<Movie> movies)
        {

            Random random = new Random();
            return movies.Select(movie => random.NextDouble()).ToArray();
        }
        public double[] StringArrayToDoubleArray(string[] input)
        {
            return input.Select(c => (double)c[0]).ToArray();
        }
        static double GenerateRandomOutput()
        {
            Random random = new Random();
            return random.NextDouble();
        }
        private async void Form1_Load(object sender, EventArgs e)
        {
            string dosyaYolu = "/DataList/data.csv";
            List<Movie> movies = new List<Movie>();
            movies = VerileriOku(dosyaYolu);
            double[][] inputs = movies.Select(movie => new double[] { movie.Duration.Length, movie.Genre.Length }).ToArray();
            double[][] outputs = movies.Select(movie => new double[] { GenerateRandomOutput() }).ToArray();


            ActivationNetwork network = new ActivationNetwork(
                new SigmoidFunction(),
                2,
                2,
                1
                );
            BackPropagationLearning teacher = new BackPropagationLearning(network);
            int iterations = 1000;
            double erororTolerance = 0.01;
            double error = double.MaxValue;
            List<string> erorlist = new List<string>();
            for (int i = 0; i < iterations && error > erororTolerance; i++)
            {
                error = teacher.RunEpoch(inputs, outputs);
                erorlist.Add($"Iteration {i + 1}, Error: {error}");

            }
            List<KeyValuePair<string, double>> topMovies = GetTopNOutputsFromMovies(movies, network, 5);

            //string name = "john";
            //string secim = "1";

            //string apiUrl = $"http://127.0.0.1:5000/getdata?name={name}&secim={secim}";

            //using (HttpClient client = new HttpClient())
            //{
            //    try
            //    {
            //        HttpResponseMessage response = await client.GetAsync(apiUrl);
            //        if (response.IsSuccessStatusCode)
            //        {
            //            string responseBody = await response.Content.ReadAsStringAsync();
            //            JsonData jsonData = JsonConvert.DeserializeObject<JsonData>(responseBody);
            //            columnValues = new Dictionary<string, string>();
            //            int top = 10;
            //            foreach (var columnName in jsonData.Columns)
            //            {
            //                // Label'u form üzerine ekleyin
            //                Label label = new Label();
            //                label.Text = columnName + ":";
            //                label.Location = new System.Drawing.Point(10, top);
            //                label.Size = new System.Drawing.Size(100, 20);
            //                this.Controls.Add(label);

            //                // TextBox'u form üzerine ekleyin
            //                TextBox textBox = new TextBox();
            //                textBox.Location = new System.Drawing.Point(120, top);
            //                textBox.Size = new System.Drawing.Size(200, 20);
            //                textBox.Tag = columnName; // TextBox'ın hangi özelliği temsil ettiğini belirtmek için Tag özelliğini kullanıyoruz
            //                this.Controls.Add(textBox);
            //                top += 30;
            //                columnValues.Add(columnName, textBox.Text);
            //            }
            //            Button submitButton = new Button();
            //            submitButton.Location = new System.Drawing.Point(10, top);
            //            submitButton.Size = new System.Drawing.Size(75, 23);
            //            submitButton.Text = "Gönder";
            //            submitButton.Click += SubmitButton_Click;
            //            this.Controls.Add(submitButton);
            //            var tableData = Newtonsoft.Json.JsonConvert.DeserializeObject<JsonData>(responseBody);
            //            foreach (var column in tableData.Columns)
            //            {

            //            }
            //            List<string> list = new List<string>();

            //            MessageBox.Show("Ulaşmak istegimiz string değer" + responseBody);
            //        }
            //        else
            //        {
            //            MessageBox.Show("İşleminiz Gerçekleştirilemi" + response.ReasonPhrase);
            //        }
            //    }
            //    catch (HttpRequestException a)
            //    {
            //        string mesaj = a.Message;
            //        throw;
            //    }
            //}
        }



        public class DataRsponse
        {
            public IList<string> Columns { get; set; }
        }
        Dictionary<string, object> row = new Dictionary<string, object>
        {
            { "Feature1", "Value1" },
            { "Feature2", "Value2" }
        };
        List<string> selectedFeatures = new List<string> { "Feature1", "Feature2" };
        public string CreateCombinedFeatures(Dictionary<string, object> row, List<string> selectedFeatures)
        {

            string result = string.Join(" ", selectedFeatures.Select(feature => row[feature]));

            return result;
        }
        public class JsonData
        {
            public string[] Columns { get; set; }
        }
        public Dictionary<string, string> columnValues;
        public class RecommendationResponse
        {
            public List<List<string>> Recommendations { get; set; }
            public List<double> Scores { get; set; }
        }
        public Dictionary<string, string> Constract_String()
        {
            Dictionary<string, string> columnValues = new Dictionary<string, string>();

            foreach (Control control in this.Controls)
            {
                if (control is TextBox textBox && textBox.Tag != null)
                {
                    // Her bir TextBox için Tag özelliği kullanarak değeri ekleyin
                    columnValues.Add(textBox.Tag.ToString(), textBox.Text);
                }
            }

            // Önceki değerleri temizleme (isteğe bağlı)
            // columnValues.Clear();

            return columnValues;
        }
        public class Movie
        {
            public string Title { get; set; }
            public string Genre { get; set; }
            public string Director { get; set; }
            public string Year { get; set; }
            public string Img_Url { get; set; }
            public string Certificate { get; set; }
            public string Duration { get; set; }
            public string Imdb { get; set; }
            public string Metascore { get; set; }
            public string Overview { get; set; }
            public string Actors { get; set; }
            public double Scores { get; set; }
            public string[] StringArrayData { get; set; }
        }

        private async void SubmitButton_Click(object sender, EventArgs e)
        {


        }
        public class MovieOutput
        {
            public string Title { get; set; }
            public double Output { get; set; }
        }
        static List<KeyValuePair<string, double>> GetTopNOutputsFromMovies(List<Movie> movies, ActivationNetwork network, int n)
        {
            List<KeyValuePair<string, double>> outputs = new List<KeyValuePair<string, double>>();
            foreach (var movie in movies)
            {
                double output = network.Compute(new double[] { movie.Duration.Length, movie.Genre.Length })[0];
                outputs.Add(new KeyValuePair<string, double>(movie.Duration, output));
            }
            outputs.Sort((x, y) => y.Value.CompareTo(y.Value));
            List<KeyValuePair<string, double>> topNOutputs = outputs.Take(n).ToList();
            return topNOutputs;
        }
        static List<MovieOutput> GetOutputsFromMoviesRandom(List<Movie> movies, int n)
        {
            Random random = new Random();

            var outputs = new List<MovieOutput>();

            for (int i = 0; i < n; i++)
            {
                var movie = movies[random.Next(movies.Count)];
                outputs.Add(new MovieOutput { Title = movie.Title, Output = random.NextDouble() });
            }

            return outputs;
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                string title = textBox_filmadı.Text.Trim();
                string year = textBox_yili.Text.Trim().Trim();
                string genre = textBox_tur.Text.Trim();
                string imdb = textBox_puan.Text.Trim();
                string director = textBox_yonetmen.Text.Trim();
                string apiUrl = $"http://localhost:5000/get_recommendations?title={title}&year={year}&genre={genre}&imdb={imdb}&director={director}";
                columnValues = Constract_String();
                columnValues = columnValues.Where(p => !string.IsNullOrEmpty(p.Value)).ToDictionary(p => p.Key, p => p.Value);
                string requestUrl = $"{apiUrl}?&{string.Join("&", columnValues.Select(p => $"{p.Key}={p.Value}"))}";
                HttpResponseMessage response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    string responseData = await response.Content.ReadAsStringAsync();
                    var recommendations = JsonConvert.DeserializeObject<RecommendationResponse>(responseData);
                    var list_movie = new List<Movie>();
                    foreach (var recommendation in recommendations.Recommendations)
                    {
                        int i = 0;
                        string[] lines = recommendation.ToArray();
                        var node_movie = new Movie { Title = lines[0].ToString(), Director = lines[2].ToString(), Genre = lines[1].ToString(), Year = lines[3].ToString(), Img_Url = lines[4].ToString(), Certificate = lines[5].ToString(), Duration = lines[6].ToString(), Imdb = lines[7].ToString(), Metascore = lines[8], Overview = lines[9], Actors = lines[10], Scores = recommendations.Scores[i] };
                        list_movie.Add(node_movie);
                        i++;
                    }
                    dataGridView1.DataSource = list_movie.ToList();
                }
                else
                {
                    MessageBox.Show($"Hata kodu: {response.StatusCode}");
                }
            }
        }
    }
}
