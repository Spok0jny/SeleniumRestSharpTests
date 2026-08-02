using System;
using System.Collections.Generic;
using System.Text;

namespace Final2
{
    internal class TodoRequest
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; } = null!;
        public bool Completed { get; set; }

    }
}
