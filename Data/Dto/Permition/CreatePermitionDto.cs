using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Dto.Permition
{
    public class CreatePermitionDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
    } 
    public class UpdatePermitionDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
    public class DeletePermitionDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
