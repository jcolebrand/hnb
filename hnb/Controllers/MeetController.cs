using System;
using System.IO;
using System.Text;
using System.Web.Mvc;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace hnb.Controllers
{
    public class MeetController : Controller
    {
        public ActionResult Index()
        {
            ParseResults();
            return View();
        }

        public ActionResult WhereAreOurDogsFrom() {
            return View();
        }

        public void ParseResults() {
            var results = @"
{""returned_pets"":9,""pets"":[{""results_photo_height"":90,""age"":""young"",""size"":""Small 25 lbs (11 kg) or less"",""addr_state_code"":""TX"",""large_results_photo_width"":200,""order"":1,""results_photo_width"":60,""pet_id"":""18403697"",""pet_name"":""Harris"",""primary_breed"":""Anatolian Shepherd"",""species"":""dog"",""sex"":""m"",""details_url"":""http://api.adoptapet.com/search/limited_pet_details?pet_id=18403697&key=dc618ad6fe052fe942eff360409180c6&v=1&output=json"",""large_results_photo_url"":""https://d1n3ar4lqtlydb.cloudfront.net/f/c/c/268827992.jpg"",""addr_city"":""Dallas"",""results_photo_url"":""https://d1n3ar4lqtlydb.cloudfront.net/5/e/6/268827990.jpg"",""large_results_photo_height"":200,""secondary_breed"":null},{""results_photo_height"":68,""age"":""puppy"",""size"":""Small 25 lbs (11 kg) or less"",""addr_state_code"":""TX"",""large_results_photo_width"":200,""order"":2,""results_photo_width"":90,""pet_id"":""18300796"",""pet_name"":""Marley"",""primary_breed"":""Hound (Unknown Type)"",""species"":""dog"",""sex"":""m"",""details_url"":""http://api.adoptapet.com/search/limited_pet_details?pet_id=18300796&key=dc618ad6fe052fe942eff360409180c6&v=1&output=json"",""large_results_photo_url"":""https://d1n3ar4lqtlydb.cloudfront.net/8/0/7/270467806.jpg"",""addr_city"":""Dallas"",""results_photo_url"":""https://d1n3ar4lqtlydb.cloudfront.net/d/7/c/270467804.jpg"",""large_results_photo_height"":200,""secondary_breed"":""Chihuahua""},{""results_photo_height"":90,""age"":""puppy"",""size"":""Small 25 lbs (11 kg) or less"",""addr_state_code"":""TX"",""large_results_photo_width"":200,""order"":3,""results_photo_width"":72,""pet_id"":""18300789"",""pet_name"":""Olive"",""primary_breed"":""Hound (Unknown Type)"",""species"":""dog"",""sex"":""f"",""details_url"":""http://api.adoptapet.com/search/limited_pet_details?pet_id=18300789&key=dc618ad6fe052fe942eff360409180c6&v=1&output=json"",""large_results_photo_url"":""https://d1n3ar4lqtlydb.cloudfront.net/0/5/2/270467762.jpg"",""addr_city"":""Dallas"",""results_photo_url"":""https://d1n3ar4lqtlydb.cloudfront.net/2/9/e/270467760.jpg"",""large_results_photo_height"":200,""secondary_breed"":""Chihuahua""},{""results_photo_height"":68,""age"":""puppy"",""size"":""Small 25 lbs (11 kg) or less"",""addr_state_code"":""TX"",""large_results_photo_width"":200,""order"":4,""results_photo_width"":90,""pet_id"":""18300822"",""pet_name"":""Ella"",""primary_breed"":""Hound (Unknown Type)"",""species"":""dog"",""sex"":""f"",""details_url"":""http://api.adoptapet.com/search/limited_pet_details?pet_id=18300822&key=dc618ad6fe052fe942eff360409180c6&v=1&output=json"",""large_results_photo_url"":""https://d1n3ar4lqtlydb.cloudfront.net/3/5/f/270467632.jpg"",""addr_city"":""Dallas"",""results_photo_url"":""https://d1n3ar4lqtlydb.cloudfront.net/6/1/4/270467630.jpg"",""large_results_photo_height"":200,""secondary_breed"":""Chihuahua""},{""results_photo_height"":89,""age"":""puppy"",""size"":""Small 25 lbs (11 kg) or less"",""addr_state_code"":""TX"",""large_results_photo_width"":200,""order"":5,""results_photo_width"":90,""pet_id"":""18300732"",""pet_name"":""Hera"",""primary_breed"":""Hound (Unknown Type)"",""species"":""dog"",""sex"":""f"",""details_url"":""http://api.adoptapet.com/search/limited_pet_details?pet_id=18300732&key=dc618ad6fe052fe942eff360409180c6&v=1&output=json"",""large_results_photo_url"":""https://d1n3ar4lqtlydb.cloudfront.net/0/3/b/266713956.jpg"",""addr_city"":""Dallas"",""results_photo_url"":""https://d1n3ar4lqtlydb.cloudfront.net/2/9/4/266713953.jpg"",""large_results_photo_height"":200,""secondary_breed"":""Terrier (Unknown Type, Small)""},{""results_photo_height"":68,""age"":""puppy"",""size"":""Small 25 lbs (11 kg) or less"",""addr_state_code"":""TX"",""large_results_photo_width"":200,""order"":6,""results_photo_width"":90,""pet_id"":""18300719"",""pet_name"":""Aura"",""primary_breed"":""Hound (Unknown Type)"",""species"":""dog"",""sex"":""f"",""details_url"":""http://api.adoptapet.com/search/limited_pet_details?pet_id=18300719&key=dc618ad6fe052fe942eff360409180c6&v=1&output=json"",""large_results_photo_url"":""https://d1n3ar4lqtlydb.cloudfront.net/d/a/8/266713091.jpg"",""addr_city"":""Dallas"",""results_photo_url"":""https://d1n3ar4lqtlydb.cloudfront.net/b/c/8/266713089.jpg"",""large_results_photo_height"":200,""secondary_breed"":""Terrier (Unknown Type, Small)""},{""results_photo_height"":90,""age"":""puppy"",""size"":""Small 25 lbs (11 kg) or less"",""addr_state_code"":""TX"",""large_results_photo_width"":200,""order"":7,""results_photo_width"":87,""pet_id"":""18300422"",""pet_name"":""Artemis"",""primary_breed"":""Hound (Unknown Type)"",""species"":""dog"",""sex"":""f"",""details_url"":""http://api.adoptapet.com/search/limited_pet_details?pet_id=18300422&key=dc618ad6fe052fe942eff360409180c6&v=1&output=json"",""large_results_photo_url"":""https://d1n3ar4lqtlydb.cloudfront.net/9/4/e/266708402.jpg"",""addr_city"":""Dallas"",""results_photo_url"":""https://d1n3ar4lqtlydb.cloudfront.net/4/8/4/266708400.jpg"",""large_results_photo_height"":200,""secondary_breed"":""Terrier (Unknown Type, Small)""},{""results_photo_height"":90,""age"":""puppy"",""size"":""Small 25 lbs (11 kg) or less"",""addr_state_code"":""TX"",""large_results_photo_width"":200,""order"":8,""results_photo_width"":90,""pet_id"":""18299653"",""pet_name"":""Apollo"",""primary_breed"":""Hound (Unknown Type)"",""species"":""dog"",""sex"":""m"",""details_url"":""http://api.adoptapet.com/search/limited_pet_details?pet_id=18299653&key=dc618ad6fe052fe942eff360409180c6&v=1&output=json"",""large_results_photo_url"":""https://d1n3ar4lqtlydb.cloudfront.net/9/d/0/266691559.jpg"",""addr_city"":""Dallas"",""results_photo_url"":""https://d1n3ar4lqtlydb.cloudfront.net/4/a/2/266691557.jpg"",""large_results_photo_height"":200,""secondary_breed"":""Terrier (Unknown Type, Small)""},{""results_photo_height"":90,""age"":""young"",""size"":""Small 25 lbs (11 kg) or less"",""addr_state_code"":""TX"",""large_results_photo_width"":200,""order"":9,""results_photo_width"":68,""pet_id"":""18184508"",""pet_name"":""Athena"",""primary_breed"":""German Shepherd Dog"",""species"":""dog"",""sex"":""f"",""details_url"":""http://api.adoptapet.com/search/limited_pet_details?pet_id=18184508&key=dc618ad6fe052fe942eff360409180c6&v=1&output=json"",""large_results_photo_url"":""https://d1n3ar4lqtlydb.cloudfront.net/0/4/8/264235123.jpg"",""addr_city"":""Dallas"",""results_photo_url"":""https://d1n3ar4lqtlydb.cloudfront.net/8/e/e/264235121.jpg"",""large_results_photo_height"":200,""secondary_breed"":""Terrier (Unknown Type, Small)""}],""status"":""ok"",""total_pets"":9}
";
            var x = JsonConvert.DeserializeObject<AdoptAPetResults>(results);
        }
    }

    [JsonObject("result")]
    public class AdoptAPetResults
    {
        [JsonProperty("returned_pets")]
        public int Count { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("total_pets")]
        public int TotalPets { get; set; }

        [XmlArrayItem("pets")]
        public List<PetResult> Pets { get; set; }
    }

    [JsonObject("pets")]
    public class PetResult {
        
        [JsonProperty("addr_city")]
        public string City { get; set; }

        [JsonProperty("addr_state_code")]
        public string State { get; set; }

        [JsonProperty("age")]
        public string Age { get; set; }

        [JsonProperty("details_url")]
        public Uri DetailsUrl { get; set; }

        [JsonProperty("results_photo_height")]
        public int ResultsPhotoHeight { get; set; }

        [JsonProperty("results_photo_width")]
        public int ResultsPhotoWidth { get; set; }

        [JsonProperty("results_photo_url")]
        public string ResultsPhotoUrl { get; set; }

        [JsonProperty("large_results_photo_height")]
        public int LargePhotoHeight { get; set; }

        [JsonProperty("large_results_photo_width")]
        public int LargePhotoWidth { get; set; }

        [JsonProperty("large_results_photo_url")]
        public string LargePhotoUrl { get; set; }

        [JsonProperty("order")]
        public int DisplayOrder { get; set; }

        [JsonProperty("pet_id")]
        public int Id { get; set; }

        [JsonProperty("pet_name")]
        public string Name { get; set; }

        [JsonProperty("primary_breed")]
        public string PrimaryBreed { get; set; }

        [JsonProperty("secondary_breed")]
        public string SecondaryBreed { get; set; }

        [JsonProperty("sex")]
        public string Sex { get; set; }

        [JsonProperty("size")]
        public string Size { get; set; }

        [JsonProperty("species")]
        public string Species { get; set; }
    }

    public class Photo {
        
        public Uri Url { get; set; }

        public int Height { get; set; }

        public int Width { get; set; }
    }

    public class Pet { 
        public List<string> States { get; set; }
        public string Name { get; set; }
        public List<int> IDs { get; set; }
        public Photo LargePhoto { get; set; }
    }
}
