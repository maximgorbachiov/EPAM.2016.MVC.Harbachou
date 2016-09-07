using System.ComponentModel.DataAnnotations;

namespace Task.Models
{
    public class PersonInfoModel
    {
        //[Required(ErrorMessage = "Put person name")]
        public string Name { get; set; }

        //[Required(ErrorMessage = "Put person age")]
        public int Age { get; set; }

        //[Required(ErrorMessage = "Put person rank")]
        public string Rank { get; set; }

        //[Required(ErrorMessage = "Put person side")]
        public bool Side { get; set; }

        public int Id { get; set; }
    }
}