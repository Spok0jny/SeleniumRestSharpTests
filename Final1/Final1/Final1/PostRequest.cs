using System;
using System.Collections.Generic;
using System.Text;

namespace Final1
{
    //Ta klasa reprezentuje strukturę danych dla żądania POST w API. 
    public class PostRequest
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public int UserId { get; set; }
    }
}
